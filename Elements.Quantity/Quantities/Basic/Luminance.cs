using System;

namespace Elements.Quantity
{
    public readonly struct Luminance : IQuantity<Luminance>
    {
        #region ESSENTIALS

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Luminance(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Luminance other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Luminance other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        #region QUANTITY NAME DEFINITIONS

        public string[] GetShortBaseNames() { return new string[] { "cd/m²" }; }
        public string[] GetLongBaseNames() { return new string[] { "candelas per square meter", "candela per square meter" }; }

        #endregion

        #region UNITS

        public Unit<Luminance> DefaultUnit { get { return CandelaPerSquareMeter; } }

        public static readonly Unit<Luminance> CandelaPerSquareMeter = new Unit<Luminance>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " cd/m²" }, new string[] { "candelas per square meter" });

        public static readonly Unit<Luminance> Nit = new Unit<Luminance>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " nit" }, new string[] { "nits" }); // Nit is a non-SI name for cd/m²

        #endregion

        #region OPERATORS

        public Luminance New(double baseVal) { return new Luminance(baseVal); }

        public Luminance Add(Luminance q) { return new Luminance(BaseValue + q.BaseValue); }
        public Luminance Subtract(Luminance q) { return new Luminance(BaseValue - q.BaseValue); }

        public Luminance Multiply(double n) { return new Luminance(BaseValue * n); }
        public Luminance Multiply(Luminance a, Ratio r) { return a * r.BaseValue; }
        public Luminance Multiply(Ratio r, Luminance a) { return a * r.BaseValue; }

        public Luminance Divide(double n) { return new Luminance(BaseValue / n); }
        public Ratio Divide(Luminance q) { return new Ratio(BaseValue / q.BaseValue); }

        public static Luminance Parse(string str) { return Unit<Luminance>.Parse(str); }
        public static bool TryParse(string str, out Luminance q) { return Unit<Luminance>.TryParse(str, out q); }

        public static Luminance operator +(Luminance a, Luminance b) { return a.Add(b); }
        public static Luminance operator -(Luminance a, Luminance b) { return a.Subtract(b); }
        public static Luminance operator *(Luminance a, double n) { return a.Multiply(n); }
        public static Luminance operator /(Luminance a, double n) { return a.Divide(n); }
        public static Ratio operator /(Luminance a, Luminance b) { return a.Divide(b); }
        public static Luminance operator -(Luminance a) { return a.Multiply(-1); }

        #endregion
    }
}
