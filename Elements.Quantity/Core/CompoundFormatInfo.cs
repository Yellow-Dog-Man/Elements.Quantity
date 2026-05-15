using System;
using System.Collections.Generic;

using System.Text;

namespace Elements.Quantity
{
    public enum CompoundZeroHandling { LeaveAll, TrimBeginning, RemoveAny };

    public class CompoundFormatInfo<T> where T : unmanaged, IQuantity<T>
    {
        public string? LastNumberFormat { get; private set; }

        public string NumberFormat { get; private set; } = string.Empty;

        public CompoundZeroHandling ZeroHandling { get; private set; }
        public bool UseLongNames { get; private set; }
        public bool DiscardLastFraction { get; private set; }

        public int UnitCount { get { return formatInfo.Length; } }

        string defaultSeparator;
        Info[] formatInfo;

        public CompoundFormatInfo(string defaultSeparator,
            string? lastNumberFormat, CompoundZeroHandling zeroHandling, bool useLongNames, bool discardLastFraction,
            params Info[] formatInfo) : this(defaultSeparator, lastNumberFormat, zeroHandling, useLongNames, discardLastFraction,
                (IEnumerable<Info>)formatInfo )
        {

        }

        public CompoundFormatInfo(string defaultSeparator,
            string? lastNumberFormat, CompoundZeroHandling zeroHandling, bool useLongNames, bool discardLastFraction,
            IEnumerable<Info> formatInfo)
        {
            this.ZeroHandling = zeroHandling;
            this.UseLongNames = useLongNames;
            this.LastNumberFormat = lastNumberFormat;
            this.DiscardLastFraction = discardLastFraction;
            this.defaultSeparator = defaultSeparator;

            // sort the units by their ratio, from biggest to smallest
            var formatInfoList = new List<Info>(formatInfo);
            formatInfoList.Sort((a, b) => a.Unit.CompareTo(b.Unit));
            formatInfoList.Reverse();
            this.formatInfo = formatInfoList.ToArray();
        }

        public Unit<T> GetUnit(int index) { return formatInfo[index].Unit; }

        public string GetSeparator(int index)
            { return formatInfo[index].OverrideSeparator ?? defaultSeparator; }

        public string? GetUnitName(int index)
            { return formatInfo[index].OverrideUnitName; }

        public string GetNumberFormat(int index)
            { return formatInfo[index].OverrideNumberFormat ?? "0"; }

        public CompoundZeroHandling GetZeroHandling(int index)
            { return formatInfo[index].OverrideZeroHandling ?? ZeroHandling; }

        public class Info
        {
            public Info(Unit<T> unit, string? overrideUnitName = null,
                string? overrideSeparator = null, string? overrideNumberFormat = null,
                CompoundZeroHandling? overrideZeroHandling = null)
            {
                this.Unit = unit;
                this.OverrideUnitName = overrideUnitName;
                this.OverrideSeparator = overrideSeparator;
                this.OverrideNumberFormat = overrideNumberFormat;
                this.OverrideZeroHandling = overrideZeroHandling;
            }

            public Unit<T> Unit { get; private set; }
            public string? OverrideUnitName { get; private set; }
            public string? OverrideSeparator { get; private set; }
            public string? OverrideNumberFormat { get; private set; }
            public CompoundZeroHandling? OverrideZeroHandling { get; private set; }
        }

        // overrides of properties - creates a clone
        public CompoundFormatInfo<T> OverrideLastNumberFormat(string format)
        {
            var copy = (CompoundFormatInfo<T>)this.MemberwiseClone();
            copy.NumberFormat = format;
            return copy;
        }

        public CompoundFormatInfo<T> OverrideSeparator(string separator)
        {
            var copy = (CompoundFormatInfo<T>)this.MemberwiseClone();
            copy.defaultSeparator = separator;
            return copy;
        }
    }
}
