using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Ratio : IQuantity<Ratio>,
        IMultiplyOperators<Ratio, Ratio, Ratio>,
        IMultiplyOperators<Ratio, Acceleration, Acceleration>,
        IMultiplyOperators<Ratio, Angle, Angle>,
        IMultiplyOperators<Ratio, Density, Density>,
        IMultiplyOperators<Ratio, Distance, Distance>,
        IMultiplyOperators<Ratio, Luminance, Luminance>,
        IMultiplyOperators<Ratio, Mass, Mass>,
        IMultiplyOperators<Ratio, Pressure, Pressure>,
        IMultiplyOperators<Ratio, Temperature, Temperature>,
        IMultiplyOperators<Ratio, Time, Time>,
        IMultiplyOperators<Ratio, Torque, Torque>,
        IMultiplyOperators<Ratio, Velocity, Velocity>,
        IMultiplyOperators<Ratio, Current, Current>,
        IMultiplyOperators<Ratio, Resistance, Resistance>,
        IMultiplyOperators<Ratio, Voltage, Voltage>
    {
        #region ESSENTIALS

        // this section can be simply left as is

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Ratio(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Ratio other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Ratio other) { return BaseValue.CompareTo(other.BaseValue); }

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
        public Unit<Ratio> DefaultUnit { get { return RatioValue; } }

        /// <inheritdoc/>
        public string QuantityFamily => string.Empty;

        // define actual units for the quantity (excluding SI units which are automatic)

        public static readonly Unit<Ratio> RatioValue = new Unit<Ratio>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { "" }, new string[] { "" });

        public static readonly Unit<Ratio> Percent = new Unit<Ratio>(1.0 / 100.0,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " %" }, new string[] { " percent" });

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public static Ratio Create(double baseVal) => new(baseVal);

        [Obsolete("Use System.Numerics interfaces")]
        public Ratio Multiply(Ratio a, Ratio r) => a * r;

        public static Ratio Parse(string str, Unit<Ratio>? defaultUnit = null) => Unit<Ratio>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Ratio q, Unit<Ratio>? defaultUnit = null) => Unit<Ratio>.TryParse(str, out q, defaultUnit);

        public static Ratio operator +(Ratio a, Ratio b) => new(a.BaseValue + b.BaseValue);
        public static Ratio operator -(Ratio a, Ratio b) => new(a.BaseValue - b.BaseValue);
        public static Ratio operator *(Ratio a, double n) => new(a.BaseValue * n);
        public static Ratio operator *(Ratio a, Ratio b) => new(a.BaseValue * b.BaseValue);
        public static Ratio operator /(Ratio a, double n) => new(a.BaseValue / n);
        public static Ratio operator /(Ratio a, Ratio b) => new(a.BaseValue / b.BaseValue);
        public static Ratio operator -(Ratio a) => a * -1;
        public static Ratio AdditiveIdentity => new(0);
        public static Ratio MultiplicativeIdentity => new(1);

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        // Basic
        public static Acceleration operator *(Ratio r, Acceleration a) => a * r.BaseValue;
        public static Angle operator *(Ratio r, Angle a) => a * r.BaseValue;
        public static Density operator *(Ratio r, Density a) => a * r.BaseValue;
        public static Distance operator *(Ratio r, Distance a) => a * r.BaseValue;
        public static Luminance operator *(Ratio r, Luminance a) => a * r.BaseValue;
        public static Mass operator *(Ratio r, Mass a) => a * r.BaseValue;
        public static Pressure operator *(Ratio r, Pressure a) => a * r.BaseValue;
        public static Temperature operator *(Ratio r, Temperature a) => a * r.BaseValue;
        public static Time operator *(Ratio r, Time a) => a * r.BaseValue;
        public static Torque operator *(Ratio r, Torque a) => a * r.BaseValue;
        public static Velocity operator *(Ratio r, Velocity a) => a * r.BaseValue;

        // Electronic
        public static Current operator *(Ratio r, Current a) => a * r.BaseValue;
        public static Resistance operator *(Ratio r, Resistance a) => a * r.BaseValue;
        public static Voltage operator *(Ratio r, Voltage a) => a * r.BaseValue;

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
