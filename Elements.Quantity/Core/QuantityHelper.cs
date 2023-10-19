using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Reflection;

namespace Elements.Quantity
{
    public static class QuantityHelper
    {
        // CONFIGURATION

        public static CultureInfo Culture = System.Globalization.CultureInfo.InvariantCulture;

        // EXTENSION METHODS

        public static double ConvertTo<T>(this T q, Unit<T> unit) where T : unmanaged, IQuantity<T>
        {
            return unit.ConvertTo(q);
        }

        public static string FormatAs<T>(this T q, Unit<T> unit, string formatNum = null,
            bool longName = false, string overrideName = null) where T : unmanaged, IQuantity<T>
        {
            return unit.FormatAs(q, formatNum, longName, overrideName);
        }

        public static string FormatAs<T>(this T q, string unitName, string formatNum = null,
            bool longName = false) where T : unmanaged, IQuantity<T>
        {
            // find the unit
            var unit = GetUnitByName<T>(unitName);

            if (unit == null)
                throw new UnitNameNotFoundException(unitName);

            return q.FormatAs((Unit<T>)unit, formatNum, longName, unitName);
        }

        public static string FormatAuto<T>(this T q, string formatNum, bool longName,
            UnitGroup unitGroup, Unit<T> defaultUnit = null) where T : unmanaged, IQuantity<T>
        {
            return FormatAuto(q, formatNum, longName, new List<UnitGroup> { unitGroup }, defaultUnit);
        }

        public static string FormatAuto<T>(this T q, string formatNum = null,
            bool longName = false, List<UnitGroup> groups = null, Unit<T> defaultUnit = null) where T : unmanaged, IQuantity<T>
        {
            Unit<T> selectedUnit = null;

            if (q.BaseValue == 0)
                selectedUnit = defaultUnit ?? q.DefaultUnit;
            else
                selectedUnit = SelectBestUnit(q, groups ?? UnitGroup.DefaultUnitGroups);

            return FormatAs(q, selectedUnit, formatNum, longName);
        }

        public static string FormatCompound<T>(this T q, ICollection<Unit<T>> units,
            string separator = " ",
            CompoundZeroHandling zeroHandling = CompoundZeroHandling.RemoveAny,
            string lastNumberFormat = null, bool longNames = false, bool discardLastFraction = false) where T : unmanaged, IQuantity<T>
        {
            // compose info array
            var infolist = new List<CompoundFormatInfo<T>.Info>();

            foreach(var unit in units)
                infolist.Add(new CompoundFormatInfo<T>.Info(unit));

            var formatInfo = new CompoundFormatInfo<T>(separator,
                lastNumberFormat, zeroHandling, longNames, discardLastFraction, infolist.ToArray());

            return q.FormatCompound(formatInfo);
        }

        public static string FormatCompound<T>(this T q,
            CompoundFormatInfo<T> formatInfo) where T : unmanaged, IQuantity<T>
        {
            var str = new StringBuilder();

            T remainder = q;

            if(remainder.BaseValue < 0)
            {
                remainder = remainder.Multiply(-1);
                str.Append("-");
            }

            bool writtenAnything = false;

            for (int i = 0; i < formatInfo.UnitCount; i++)
            {
                var unit = formatInfo.GetUnit(i);
                var zeroHandling = formatInfo.GetZeroHandling(i);
                bool isLast = i == formatInfo.UnitCount - 1;

                double val = unit.ConvertTo(remainder);
                double whole = Math.Floor(val);
                double frac = val - whole;

                if (!isLast)
                {
                    bool isZero = whole == 0.0;
                    bool take = true;

                    if (zeroHandling == CompoundZeroHandling.RemoveAny && isZero)
                        take = false;
                    else if (zeroHandling == CompoundZeroHandling.TrimBeginning
                        && isZero && !writtenAnything)
                        take = false;

                    if (take)
                    {
                        var wholeQ = unit.ConvertFrom(whole);
                        str.Append(wholeQ.FormatAs(unit, formatInfo.GetNumberFormat(i),
                            formatInfo.UseLongNames,
                            formatInfo.GetUnitName(i)));

                        str.Append(formatInfo.GetSeparator(i));

                        writtenAnything = true;
                    }

                    remainder = unit.ConvertFrom(frac);
                }
                else
                {
                    if(formatInfo.DiscardLastFraction)
                        remainder = unit.ConvertFrom(whole);

                    string last = remainder.FormatAs(unit, formatInfo.LastNumberFormat,
                        formatInfo.UseLongNames, formatInfo.GetUnitName(i));

                    if (zeroHandling != CompoundZeroHandling.RemoveAny
                        || last.IndexOfAny(
                        new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' }) >= 0)
                    {
                        str.Append(last);
                        writtenAnything = true;
                    }
                }
            }

            return str.ToString();
        }

        // Working with units

        public static IEnumerable<IUnit> GetUnits<T>()
        {
            return unitCache[typeof(T)];
        }

        public static Unit<T> SelectBestUnit<T>(this T q, List<UnitGroup> groups)
            where T : unmanaged, IQuantity<T>
        {
            // TODO - use a more efficient algorithm

            var units = unitCache[typeof(T)];

            IUnit selectedUnit = null;
            //int lastRating = int.MaxValue;

            double baseValue = Math.Abs(q.BaseValue);

            foreach(var group in groups)
            {
                foreach(var unit in group.GetSetForType(typeof(T)))
                {
                    // calculate ratio between values
                    double log = Math.Log10(baseValue / unit.Ratio);
                    /*int rating = Math.Abs(2 - (int)Math.Ceiling(log));*/

                    // check if it's better
                    if ((/*rating < lastRating &&*/ log >= 0) || selectedUnit == null)
                    {
                        // take it!
                        selectedUnit = unit;
                        //lastRating = rating;
                    }
                    else
                        break;  // not going to get better
                }
            }

            return (Unit<T>)selectedUnit;
        }

        static bool ContainsUnit(IUnit unit, List<UnitGroup> groups)
        {
            foreach (var group in groups)
                if (group.HasUnit(unit))
                    return true;
            return false;
        }

        public static IUnit GetUnitByName<T>(string name)
        {
            if (name == null)
                return null;

            var typeCache = unitNameCache[typeof(T)];

            if (!typeCache.ContainsKey(name))
                return null;

            return typeCache[name];
        }

        static Dictionary<Type, List<IUnit>> unitCache = new Dictionary<Type, List<IUnit>>();
        static Dictionary<Type, Dictionary<string, IUnit>> unitNameCache = new Dictionary<Type, Dictionary<string, IUnit>>();

        // Initialize the library
        static QuantityHelper()
        {
            var assembly = typeof(QuantityHelper).Assembly;

            foreach(var t in assembly.GetTypes())
            {
                if (typeof(IQuantity).IsAssignableFrom(t) && t.IsValueType)
                {
                    IQuantity quantity = (IQuantity)Activator.CreateInstance(t);  // make sure it's initialized first

                    var units = new List<IUnit>();
                    unitCache.Add(t, units);

                    // check if it's an SI quantity
                    bool isSI = false;
                    foreach(var i in t.GetInterfaces())
                        if(i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IQuantitySI<>))
                        {
                            isSI = true;
                            break;
                        }

                    // enumerate all units
                    var flags = BindingFlags.Static | BindingFlags.Public;

                    List<FieldInfo[]> fields = new List<FieldInfo[]>();
                    fields.Add(t.GetFields(flags));

                    // if an SI, get all SI units
                    if(isSI)
                    {
                        var tempInst = (IQuantitySI)quantity;

                        // register common SI units
                        foreach (var unit in tempInst.GetCommonSIUnits())
                        {
                            UnitGroup.Common.RegisterUnit(unit);
                            UnitGroup.CommonMetric.RegisterUnit(unit);
                        }

                        // remove exluded SI units
                        foreach (var unit in tempInst.GetExludedSIUnits())
                            UnitGroup.Metric.RemoveUnit(unit);

                        // get all the fields of the SI class which contain the units
                        var genT = typeof(SI<>).MakeGenericType(t);
                        fields.Add(genT.GetFields(flags));
                    }

                    // collect and add all units to the list
                    foreach(var ff in fields)
                        foreach(var f in ff)
                            if (typeof(IUnit).IsAssignableFrom(f.FieldType))
                                units.Add((IUnit)f.GetValue(null));

                    units.Sort();

                    // generate name cache
                    var names = new Dictionary<string, IUnit>();
                    unitNameCache.Add(t, names);

                    foreach (var unit in units)
                        foreach (var name in unit.GetUnitNames())
                            names.Add(name.Trim(), unit);
                }
            }
        }
    }
}
