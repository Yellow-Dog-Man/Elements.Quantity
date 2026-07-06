using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Acceleration : IQuantity<Acceleration>,
        IDivisionOperators<Acceleration, Ratio, Acceleration>,
        IMultiplyOperators<Acceleration, Time, Velocity>
    {
        #region ESSENTIALS

        // this section can be simply left as is

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Acceleration(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Acceleration other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Acceleration other) { return BaseValue.CompareTo(other.BaseValue); }

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
        public Unit<Acceleration> DefaultUnit { get { return MetersPerSecondPerSecond; } }

        /// <inheritdoc/>
        public string QuantityFamily => string.Empty;

        // define actual units for the quantity (excluding SI units which are automatic)

        public static readonly Unit<Acceleration> MetersPerSecondPerSecond = new Unit<Acceleration>(1,
            new UnitGroup[] { UnitGroup.Common, UnitGroup.Metric },
            new string[] { " m/s^2", " m/s/s" }, new string[] { " meters per second squared", " meter per second squared", " meters per second per second", " meter per second per second" });

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public static Acceleration Create(double baseValue) => new(baseValue);

        [Obsolete("Use System.Numerics interfaces")]
        public Acceleration Multiply(Acceleration a, Ratio r) => r * a;

        [Obsolete("Use System.Numerics interfaces")]
        public Acceleration Multiply(Ratio r, Acceleration a) => r * a;

        public static Acceleration Parse(string str, Unit<Acceleration>? defaultUnit = null) => Unit<Acceleration>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Acceleration q, Unit<Acceleration>? defaultUnit = null) => Unit<Acceleration>.TryParse(str, out q, defaultUnit);

        public static Acceleration operator +(Acceleration a, Acceleration b) => new(a.BaseValue + b.BaseValue);
        public static Acceleration operator -(Acceleration a, Acceleration b) => new(a.BaseValue - b.BaseValue);
        public static Acceleration operator *(Acceleration a, double n) => new(a.BaseValue * n);
        public static Acceleration operator *(Acceleration a, Ratio r) => r * a;
        public static Acceleration operator /(Acceleration a, double n) => new(a.BaseValue / n);
        public static Acceleration operator /(Acceleration a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Acceleration a, Acceleration b) => new(a.BaseValue / b.BaseValue);
        public static Acceleration operator -(Acceleration a) => a * -1;
        public static Acceleration AdditiveIdentity => new(0);
        public static Ratio MultiplicativeIdentity => Ratio.MultiplicativeIdentity;

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        public static Velocity operator *(Acceleration a, Time t) { return new Velocity(a.BaseValue * t.BaseValue); }

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
