using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Time : IQuantity<Time>,
        IDivisionOperators<Time, Ratio, Time>,
        IMultiplyOperators<Time, Velocity, Distance>,
        IMultiplyOperators<Time, Acceleration, Velocity>
    {
        #region ESSENTIALS

        // this section can be simply left as is

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Time(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Time other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Time other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        // Provide at least one short and one long name for the quantity
        // The first entry will be used for formatting, all will be used for parsing

        public string[] GetShortBaseNames() { return new string[] { "" }; }
        public string[] GetLongBaseNames()
        { return new string[] { "" }; }

        #endregion

        /* *********************************************** */

        #region UNITS

        // provide a default unit for the quantity - used when no explicit unit specified
        public Unit<Time> DefaultUnit { get { return Second; } }

        /// <inheritdoc/>
        public string QuantityFamily => string.Empty;

        public static readonly Unit<Time> Millisecond = new Unit<Time>(1.0 / 1000.0,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " ms" }, new string[] { " milliseconds", " millisecond" });
        public static readonly Unit<Time> Second = new Unit<Time>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " s" }, new string[] { " seconds", " second" });
        public static readonly Unit<Time> Minute = new Unit<Time>(60,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " m" }, new string[] { " minutes", " minute" });
        public static readonly Unit<Time> Hour = new Unit<Time>(60*60,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " h" }, new string[] { " hours", " hour" });

        public static readonly Unit<Time> Day = new Unit<Time>(60 * 60 * 24,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " d" }, new string[] { " days", " day" });

        // define actual units for the quantity (excluding SI units which are automatic)
        // Parameters:

        #endregion

        /* *********************************************** */

        #region COMPOUND FORMATING TEMPLATES

        public static readonly CompoundFormatInfo<Time> MinuteSecond =
            new CompoundFormatInfo<Time>(":", "00", CompoundZeroHandling.LeaveAll, false, true,
            new CompoundFormatInfo<Time>.Info(Minute, "", null, "00"),
            new CompoundFormatInfo<Time>.Info(Second, "", null, "00")
            );

        public static readonly CompoundFormatInfo<Time> HourMinuteSecond =
            new CompoundFormatInfo<Time>(":", "00", CompoundZeroHandling.LeaveAll, false, true,
            new CompoundFormatInfo<Time>.Info(Hour, ""),
            new CompoundFormatInfo<Time>.Info(Minute, "", null, "00"),
            new CompoundFormatInfo<Time>.Info(Second, "", null, "00")
            );

        public static readonly CompoundFormatInfo<Time> HourMinuteSecond_Trimmed =
            new CompoundFormatInfo<Time>(":", "00", CompoundZeroHandling.TrimBeginning, false, true,
            new CompoundFormatInfo<Time>.Info(Hour, ""),
            new CompoundFormatInfo<Time>.Info(Minute, "", null, "00", CompoundZeroHandling.LeaveAll),
            new CompoundFormatInfo<Time>.Info(Second, "", null, "00", CompoundZeroHandling.LeaveAll)
            );

        public static readonly CompoundFormatInfo<Time> DayHourMinuteSecond_Long =
            new CompoundFormatInfo<Time>(" ", null, CompoundZeroHandling.TrimBeginning, true, true,
            new CompoundFormatInfo<Time>.Info(Day),
            new CompoundFormatInfo<Time>.Info(Hour),
            new CompoundFormatInfo<Time>.Info(Minute),
            new CompoundFormatInfo<Time>.Info(Second)
            );

        public static readonly CompoundFormatInfo<Time> DayHourMinute_Long =
            new CompoundFormatInfo<Time>(" ", null, CompoundZeroHandling.TrimBeginning, true, true,
            new CompoundFormatInfo<Time>.Info(Day),
            new CompoundFormatInfo<Time>.Info(Hour),
            new CompoundFormatInfo<Time>.Info(Minute)
    );

        public static readonly CompoundFormatInfo<Time> DayHourMinuteSecond_Trimmed =
            new CompoundFormatInfo<Time>(":", "00", CompoundZeroHandling.TrimBeginning, false, true,
            new CompoundFormatInfo<Time>.Info(Day, "day"),
            new CompoundFormatInfo<Time>.Info(Hour, ""),
            new CompoundFormatInfo<Time>.Info(Minute, "", null, "00", CompoundZeroHandling.LeaveAll),
            new CompoundFormatInfo<Time>.Info(Second, "", null, "00", CompoundZeroHandling.LeaveAll)
    );

        public static readonly CompoundFormatInfo<Time> HourMinuteSecond_Symbol =
            new CompoundFormatInfo<Time>(" ", "00", CompoundZeroHandling.TrimBeginning, false, true,
            new CompoundFormatInfo<Time>.Info(Hour),
            new CompoundFormatInfo<Time>.Info(Minute),
            new CompoundFormatInfo<Time>.Info(Second)
            );

        public static readonly CompoundFormatInfo<Time> StopWatch =
            new CompoundFormatInfo<Time>(":", "00", CompoundZeroHandling.LeaveAll, false, true,
            new CompoundFormatInfo<Time>.Info(Hour, "", null, null, CompoundZeroHandling.TrimBeginning),
            new CompoundFormatInfo<Time>.Info(Minute, "", null, "00"),
            new CompoundFormatInfo<Time>.Info(Second, "", null, "00"),
            new CompoundFormatInfo<Time>.Info(Millisecond, "", null, "000")
            );

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public static Time Create(double baseVal) => new(baseVal);

        [Obsolete("Use System.Numerics interfaces")]
        public Time Multiply(Time a, Ratio r) { return a * r.BaseValue; }
        
        [Obsolete("Use System.Numerics interfaces")]
        public Time Multiply(Ratio r, Time a) { return a * r.BaseValue; }

        public static Time Parse(string str, Unit<Time>? defaultUnit = null) => Unit<Time>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Time q, Unit<Time>? defaultUnit = null) => Unit<Time>.TryParse(str, out q, defaultUnit);

        public static Time operator +(Time a, Time b) => new(a.BaseValue + b.BaseValue);
        public static Time operator -(Time a, Time b) => new(a.BaseValue - b.BaseValue);
        public static Time operator *(Time a, double n) => new(a.BaseValue * n);
        public static Time operator *(Time a, Ratio r) => r * a;
        public static Time operator /(Time a, double n) => new(a.BaseValue / n);
        public static Time operator /(Time a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Time a, Time b) => new(a.BaseValue / b.BaseValue);
        public static Time operator -(Time a) => a * -1;
        public static Time AdditiveIdentity => new(0);
        public static Ratio MultiplicativeIdentity => Ratio.MultiplicativeIdentity;

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        public static Distance operator *(Time t, Velocity v) => v * t;
        public static Velocity operator *(Time t, Acceleration a) => a * t;

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
