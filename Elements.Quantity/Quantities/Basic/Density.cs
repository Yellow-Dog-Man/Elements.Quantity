using System;

namespace Elements.Quantity
{
    public readonly struct Density : IQuantity<Density>
    {
        #region ESSENTIALS

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Density(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Density other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Density other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        #region QUANTITY NAME DEFINITIONS

        public string[] GetShortBaseNames() { return new string[] { "kg/m³" }; }
        public string[] GetLongBaseNames() { return new string[] { "kilograms per cubic meter", "kilogram per cubic meter" }; }

        #endregion

        #region UNITS

        public Unit<Density> DefaultUnit { get { return KilogramPerCubicMeter; } }

        public static readonly Unit<Density> KilogramPerCubicMeter = new Unit<Density>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " kg/m³" }, new string[] { "kilograms per cubic meter" });

        public static readonly Unit<Density> GramPerCubicCentimeter = new Unit<Density>(1000,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " g/cm³" }, new string[] { "grams per cubic centimeter" });

        public static readonly Unit<Density> PoundPerCubicFoot = new Unit<Density>(16.0185,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " lb/ft³" }, new string[] { "pounds per cubic foot" });

        #endregion

        #region OPERATORS

        public Density New(double baseVal) { return new Density(baseVal); }

        public Density Add(Density q) { return new Density(BaseValue + q.BaseValue); }
        public Density Subtract(Density q) { return new Density(BaseValue - q.BaseValue); }

        public Density Multiply(double n) { return new Density(BaseValue * n); }
        public Density Multiply(Density a, Ratio r) { return a * r.BaseValue; }
        public Density Multiply(Ratio r, Density a) { return a * r.BaseValue; }

        public Density Divide(double n) { return new Density(BaseValue / n); }
        public Ratio Divide(Density q) { return new Ratio(BaseValue / q.BaseValue); }

        public static Density Parse(string str) { return Unit<Density>.Parse(str); }
        public static bool TryParse(string str, out Density q) { return Unit<Density>.TryParse(str, out q); }

        public static Density operator +(Density a, Density b) { return a.Add(b); }
        public static Density operator -(Density a, Density b) { return a.Subtract(b); }
        public static Density operator *(Density a, double n) { return a.Multiply(n); }
        public static Density operator /(Density a, double n) { return a.Divide(n); }
        public static Ratio operator /(Density a, Density b) { return a.Divide(b); }
        public static Density operator -(Density a) { return a.Multiply(-1); }

        #endregion
    }
}
