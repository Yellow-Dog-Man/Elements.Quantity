using System;
using System.Collections.Generic;
using System.Globalization;

using System.Text;


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
        public double Ratio { get; protected set; }

        string[] shortNames;
        string[] longNames;

        static string shortBaseName = string.Empty;
        static string longBaseName = string.Empty;

        public Type ValueType => typeof(T);

        public int CompareTo(IUnit? other) => other == null ? 1 : Ratio.CompareTo(other.Ratio);

        public ICollection<string> GetUnitNames()
        {
            var list = new List<string>();
            var t = default(T);
            var shortBaseNames = t.GetShortBaseNames();
            var longBaseNames  = t.GetLongBaseNames();

            // cache them - this function will be called by the library initializer
            shortBaseName = shortBaseNames[0];
            longBaseName = longBaseNames[0];

            for (int i = 0; i < 2; i++)
                foreach (var name in (i == 0) ? shortNames : longNames)
                    foreach (var basename in (i == 0) ? shortBaseNames : longBaseNames)
                    {
                        string unitName = string.Format(name, basename).Trim();

                        // need to check - some combinations result in identical names
                        if (!list.Contains(unitName)) 
                            list.Add(unitName);
                    }

            return list;
        }

        public Unit(double baseRatio, ICollection<UnitGroup> unitGroups,
            string[] shortNames,
            string[] longNames)
        {
            this.Ratio = baseRatio;
            this.shortNames = shortNames;
            this.longNames = longNames;

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

        public string FormatAs(T q, string? formatNum = null, bool longName = false,
            string? overrideName = null)
        {
            string number;

            if (string.IsNullOrEmpty(formatNum))
                number = ConvertTo(q).ToString();
            else
                number = ConvertTo(q).ToString(formatNum);

            return number + (overrideName ?? string.Format(longName ? longNames[0] : shortNames[0],
                longName ? longBaseName : shortBaseName));
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
