using System;

namespace Elements.Quantity
{
    public readonly struct Acceleration : IQuantity<Acceleration>
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

        public string QuantityFamily => string.Empty;

        // define actual units for the quantity (excluding SI units which are automatic)

        public static readonly Unit<Acceleration> MetersPerSecondPerSecond = new Unit<Acceleration>(1,
            new UnitGroup[] { UnitGroup.Common, UnitGroup.Metric },
            new string[] { " m/s^2", " m/s/s" }, new string[] { " meters per second squared", " meter per second squared", " meters per second per second", " meter per second per second" });

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Acceleration New(double baseVal) { return new Acceleration(baseVal); }

        public Acceleration Add(Acceleration q) { return new Acceleration(BaseValue + q.BaseValue); }
        public Acceleration Subtract(Acceleration q) { return new Acceleration(BaseValue - q.BaseValue); }

        public Acceleration Multiply(double n) { return new Acceleration(BaseValue * n); }
        public Acceleration Multiply(Acceleration a, Ratio r) { return a * r.BaseValue; }
        public Acceleration Multiply(Ratio r, Acceleration a) { return a * r.BaseValue; }

        public Acceleration Divide(double n) { return new Acceleration(BaseValue / n); }
        public Ratio Divide(Acceleration q) { return new Ratio(BaseValue / q.BaseValue); }

        // these should be defined as convenience, but cannot be forced by interface
        public static Acceleration Parse(string str, Unit<Acceleration>? defaultUnit = null) { return Unit<Acceleration>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Acceleration q, Unit<Acceleration>? defaultUnit = null) { return Unit<Acceleration>.TryParse(str, out q, defaultUnit); }

        public static Acceleration operator +(Acceleration a, Acceleration b) { return a.Add(b); }
        public static Acceleration operator -(Acceleration a, Acceleration b) { return a.Subtract(b); }
        public static Acceleration operator *(Acceleration a, double n) { return a.Multiply(n); }
        public static Acceleration operator /(Acceleration a, double n) { return a.Divide(n); }
        public static Ratio operator /(Acceleration a, Acceleration b) { return a.Divide(b); }
        public static Acceleration operator -(Acceleration a) { return a.Multiply(-1); }

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
