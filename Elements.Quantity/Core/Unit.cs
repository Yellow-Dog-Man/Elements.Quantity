using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Elements.Quantity.Core.Internal;


namespace Elements.Quantity
{
    public interface IUnit : IComparable<IUnit>
    {
        double Ratio { get; }
        Type ValueType { get; }

        ICollection<string> GetUnitNames();
    }

    public class Unit<T> : IUnit where T : unmanaged, IQuantity<T>
    {
        private const byte DEFAULT_SHORT_UNIT_NAME_INDEX = 0;
        private const byte DEFAULT_LONG_UNIT_NAME_PLURAL_FORM_INDEX = 0;
        private const byte DEFAULT_LONG_UNIT_NAME_SINGULAR_FORM_INDEX = 1;

        public double Ratio { get; protected set; }

        private string[] _shortNames = [];
        private string[] _longNames = [];

        private string defaultShortUnitName = string.Empty;
        private string defaultLongUnitNamePluralForm = string.Empty;
        private string defaultLongUnitNameSingularForm = string.Empty;

        public Type ValueType => typeof(T);

        public int CompareTo(IUnit? other) => other == null ? 1 : Ratio.CompareTo(other.Ratio);

        public ICollection<string> GetUnitNames() => ShortUnitNames.Union(LongUnitNames).ToArray();

        private string[] ShortUnitNames
        {
            get => _shortNames;
            set
            {
                var unitNames = GenerateUnitNames(value, default(T).GetShortBaseNames());
                defaultShortUnitName = unitNames[DEFAULT_SHORT_UNIT_NAME_INDEX];

                _shortNames = unitNames.TrimStrings();
            }
        }

        private string[] LongUnitNames
        {
            get => _longNames;
            set
            {
                var unitNames = GenerateUnitNames(value, default(T).GetLongBaseNames());

                defaultLongUnitNamePluralForm = unitNames[DEFAULT_LONG_UNIT_NAME_PLURAL_FORM_INDEX];

                var longUnitNameSingularFormIndex = Math.Min(DEFAULT_LONG_UNIT_NAME_SINGULAR_FORM_INDEX, unitNames.Length - 1);
                defaultLongUnitNameSingularForm = unitNames[longUnitNameSingularFormIndex];

                _longNames = unitNames.TrimStrings();
            }
        }

        public Unit(double baseRatio, ICollection<UnitGroup> unitGroups,
            string[] shortNames,
            string[] longNames)
        {
            this.Ratio = baseRatio;
            ShortUnitNames = shortNames;
            LongUnitNames = longNames;

            if(unitGroups != null)
                foreach (var unitGroup in unitGroups)
                    unitGroup.RegisterUnit(this);
        }

        public virtual double ConvertTo(T q)
        {
            return q.BaseValue / Ratio;
        }

        public T ConvertFrom(T q)
        {
            return ConvertFrom(q.BaseValue);
        }

        public virtual T ConvertFrom(double val)
        {
            return default(T).New(val * Ratio);
        }

        public static T Parse(string str, NumberStyles numberStyles, IFormatProvider formatProvider, Unit<T>? defaultUnit = null)
        {
            ParseIntern(str, numberStyles, formatProvider, out T quantity, defaultUnit, true);
            return quantity;
        }

        public static T Parse(string str, Unit<T>? defaultUnit = null)
        {
            return Parse(str, NumberStyles.Any, QuantityHelper.Culture, defaultUnit);
        }

        public static bool TryParse(string str, out T quantity, Unit<T>? defaultUnit = null)
        {
            return TryParse(str, NumberStyles.Any, QuantityHelper.Culture, out quantity, defaultUnit);
        }

        public static bool TryParse(string str, NumberStyles numberStyles, IFormatProvider formatProvider, out T quantity,
            Unit<T>? defaultUnit = null)
        {
            return ParseIntern(str, numberStyles, formatProvider, out quantity, defaultUnit, false);
        }

        static bool ParseIntern(string str, NumberStyles numberStyles, IFormatProvider formatProvider, out T quantity,
            Unit<T>? defaultUnit, bool throwOnFail)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                quantity = default;
                return false;
            }

            // separate unit and number
            int splitIndex = IndexOfNumberEnd(str);

            var valstr = str.Substring(0, splitIndex);
            var unitstr = str.Substring(splitIndex);

            bool noUnit = string.IsNullOrWhiteSpace(unitstr);

            if(!QuantityHelper.TryParse(valstr, numberStyles, formatProvider, out double val))
            {
                if (throwOnFail)
                    throw new FormatException("Number input string was not in a correct format");

                quantity = default;
                return false;
            }

            if (noUnit)
            {
                var unit = defaultUnit ?? default(T).DefaultUnit;
                quantity = unit.ConvertFrom(val);
                return true;
            }
            else
            {
                unitstr.Trim();

                // find the right unit in the dictionary
                Unit<T>? unit = GetUnitFromSubstring(unitstr, out int unitEndIndex) as Unit<T>;

                if (unit == null)
                {
                    if(throwOnFail)
                        throw new UnitNameNotFoundException(unitstr);

                    quantity = default;
                    return false;
                }

                quantity = unit.ConvertFrom(val);

                if(unitEndIndex < unitstr.Length)
                {
                    // parse the remainder recursively

                    if (ParseIntern(unitstr.Substring(unitEndIndex), numberStyles, formatProvider, out T subQuantity, defaultUnit, throwOnFail))
                        quantity = quantity.Add(subQuantity);
                    else
                        return false;
                }

                return true;
            }
        }

        static IUnit? GetUnitFromSubstring(string str, out int unitEndIndex, bool byLetter = false)
        {
            int length = str.Length;

            while(length > 0)
            {
                var substr = str.Substring(0, length).Trim();
                var unit = QuantityHelper.GetUnitByName<T>(substr);

                if(unit != null)
                {
                    unitEndIndex = length;
                    return unit;
                }

                // didn't find it, try shorten the string to the nearest space
                // TODO!!! this will parse same string multiple times if there's redundant spaces
                if (byLetter)
                    length--;
                else
                    length = substr.LastIndexOf(' ') + 1;
            }

            // didn't find any, try the more expensive but robust version by shortening by letter
            if (!byLetter)
                return GetUnitFromSubstring(str, out unitEndIndex, true);

            unitEndIndex = 0;
            return null;
        }

        static int IndexOfNumberEnd(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return -1;

            bool startedNumber = false;

            for(int i = 0; i < str.Length; i++)
            {
                var ch = str[i];

                if (char.IsWhiteSpace(ch) && !startedNumber)
                    continue;

                if (char.IsDigit(ch))
                {
                    startedNumber = true;
                    continue;
                }

                if (ch == '-' || ch == ',' || ch == '.')
                    continue;

                if (ch == 'e' && startedNumber)
                    continue;

                return i;
            }

            return str.Length;
        }

        public string FormatAs(T q, string? formatNum = null, bool useLongName = false,
            string? overrideName = null)
        {
            var quantityValue = ConvertTo(q);
            var numberText = quantityValue.ToString(formatNum);

            var unitName = overrideName != null ? overrideName : GetDefaultUnitNameByValue(quantityValue, useLongName);

            return $"{numberText}{unitName}";
        }

        private string GetDefaultUnitNameByValue(double quantityValue, bool useLongName)
        {
            if (useLongName)
            {
                return quantityValue.IsSingular() ? defaultLongUnitNameSingularForm : defaultLongUnitNamePluralForm;
            }

            return defaultShortUnitName;
        }

        private string[] GenerateUnitNames(string[] names, string[] baseNames)
        {
            var nameListSize = names.Length;
            var baseNamesListSize = baseNames.Length;
            var generatedNameListSize = nameListSize * baseNamesListSize;

            var namesList = new List<string>(generatedNameListSize);

            for (var i = 0; i < generatedNameListSize; i++)
            {
                var nameIndex = i / baseNamesListSize;
                var baseNameIndex = i % baseNamesListSize;

                var name = names[nameIndex];
                var baseName = baseNames[baseNameIndex];

                var unitName = string.Format(name, baseName);

                if (namesList.Contains(unitName)) { continue; }

                namesList.Add(unitName);
            }

            return namesList.ToArray();
        }

        public static T operator*(Unit<T> unit, double n)
        {
            return unit.ConvertFrom(n);
        }

        public static T operator *(double n, Unit<T> unit)
        {
            return unit.ConvertFrom(n);
        }
    }

    
}
