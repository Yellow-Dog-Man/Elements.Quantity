using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Luminance : IQuantity<Luminance>,
        IDivisionOperators<Luminance, Ratio, Luminance>
    {
        #region ESSENTIALS

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Luminance(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Luminance other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Luminance other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        public string[] GetShortBaseNames() { return new string[] { "" }; }
        public string[] GetLongBaseNames() { return new string[] { "" }; }

        #endregion

        /* *********************************************** */

        #region UNITS

        public Unit<Luminance> DefaultUnit { get { return CandelaPerSquareMeter; } }

        /// <inheritdoc/>
        public string QuantityFamily => string.Empty;

        public static readonly Unit<Luminance> CandelaPerSquareMeter = new Unit<Luminance>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " cd/m²", " cd/m^2" }, new string[] { " candelas per square meter", " candela per square meter" });

        public static readonly Unit<Luminance> Nit = new Unit<Luminance>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " nt" }, new string[] { " nits", " nit" }); // Nit is a non-SI name for cd/m²

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public static Luminance Create(double baseVal) => new(baseVal);

        [Obsolete("Use System.Numerics interfaces")]
        public Luminance Multiply(Luminance a, Ratio r) => r * a;

        [Obsolete("Use System.Numerics interfaces")]
        public Luminance Multiply(Ratio r, Luminance a) => r * a;

        public static Luminance Parse(string str, Unit<Luminance>? defaultUnit = null) => Unit<Luminance>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Luminance q, Unit<Luminance>? defaultUnit = null) => Unit<Luminance>.TryParse(str, out q, defaultUnit);

        public static Luminance operator +(Luminance a, Luminance b) => new(a.BaseValue + b.BaseValue);
        public static Luminance operator -(Luminance a, Luminance b) => new(a.BaseValue - b.BaseValue);
        public static Luminance operator *(Luminance a, double n) => new(a.BaseValue * n);
        public static Luminance operator *(Luminance a, Ratio r) => r * a;
        public static Luminance operator /(Luminance a, double n) => new(a.BaseValue / n);
        public static Luminance operator /(Luminance a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Luminance a, Luminance b) => new(a.BaseValue / b.BaseValue);
        public static Luminance operator -(Luminance a) => a * -1;
        public static Luminance AdditiveIdentity => new(0);
        public static Ratio MultiplicativeIdentity => Ratio.MultiplicativeIdentity;

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
