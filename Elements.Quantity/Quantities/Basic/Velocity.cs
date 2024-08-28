using System;

namespace Elements.Quantity
{
    public readonly struct Velocity : IQuantity<Velocity>
    {
        #region ESSENTIALS

        // this section can be simply left as is

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Velocity(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Velocity other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Velocity other) { return BaseValue.CompareTo(other.BaseValue); }

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
        public Unit<Velocity> DefaultUnit { get { return MetersPerSecond; } }

        // define actual units for the quantity (excluding SI units which are automatic)

        public static readonly Unit<Velocity> MetersPerSecond = new Unit<Velocity>(1,
            new UnitGroup[] { UnitGroup.Common, UnitGroup.Metric },
            new string[] { " m/s", " mps" }, new string[] { " meters per second", " meter per second" });

        public static readonly Unit<Velocity> KilometersPerHour = new Unit<Velocity>(1/3.6,
            new UnitGroup[] { UnitGroup.Common, UnitGroup.Metric },
            new string[] { " km/h", " kmh" }, new string[] { " kilometers per hour", " kilometer per hour" });

        public static readonly Unit<Velocity> MilesPerHour = new Unit<Velocity>(0.44704,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " mph" }, new string[] { " miles per hour", " mile per hour" });

        public static readonly Unit<Velocity> FeetPerSecond = new Unit<Velocity>(0.3048,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " ft/s" }, new string[] { " feet per second", " foot per second" });

        public static readonly Unit<Velocity> Knots = new Unit<Velocity>(0.514444,
            new UnitGroup[] { UnitGroup.Meteorological, UnitGroup.Aviation, UnitGroup.Maritime },
            new string[] { " kn", " kt" }, new string[] { " knots", " knot" });

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Velocity New(double baseVal) { return new Velocity(baseVal); }

        public Velocity Add(Velocity q) { return new Velocity(BaseValue + q.BaseValue); }
        public Velocity Subtract(Velocity q) { return new Velocity(BaseValue - q.BaseValue); }

        public Velocity Multiply(double n) { return new Velocity(BaseValue * n); }
        public Velocity Multiply(Velocity a, Ratio r) { return a * r.BaseValue; }
        public Velocity Multiply(Ratio r, Velocity a) { return a * r.BaseValue; }

        public Velocity Divide(double n) { return new Velocity(BaseValue / n); }
        public Ratio Divide(Velocity q) { return new Ratio(BaseValue / q.BaseValue); }

        // these should be defined as convenience, but cannot be forced by interface
        public static Velocity Parse(string str, Unit<Velocity> defaultUnit = null) { return Unit<Velocity>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Velocity q, Unit<Velocity> defaultUnit = null) { return Unit<Velocity>.TryParse(str, out q, defaultUnit); }

        public static Velocity operator +(Velocity a, Velocity b) { return a.Add(b); }
        public static Velocity operator -(Velocity a, Velocity b) { return a.Subtract(b); }
        public static Velocity operator *(Velocity a, double n) { return a.Multiply(n); }
        public static Velocity operator /(Velocity a, double n) { return a.Divide(n); }
        public static Ratio operator /(Velocity a, Velocity b) { return a.Divide(b); }
        public static Velocity operator -(Velocity a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
