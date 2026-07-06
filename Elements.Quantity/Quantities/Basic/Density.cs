using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Density : IQuantity<Density>,
        IDivisionOperators<Density, Ratio, Density>
    {
        #region ESSENTIALS

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Density(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Density other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Density other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        public string[] GetShortBaseNames() { return new string[] { "" }; }
        public string[] GetLongBaseNames() { return new string[] { "" }; }

        #endregion

        /* *********************************************** */

        #region UNITS

        public Unit<Density> DefaultUnit { get { return KilogramPerCubicMeter; } }

        /// <inheritdoc/>
        public string QuantityFamily => string.Empty;

        public static readonly Unit<Density> KilogramPerCubicMeter = new Unit<Density>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " kg/m³", " kg/m^3" }, new string[] { " kilograms per cubic meter", " kilogram per cubic meter" });

        public static readonly Unit<Density> GramPerCubicCentimeter = new Unit<Density>(1000,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " g/cm³", " g/cm^3" }, new string[] { " grams per cubic centimeter", " gram per cubic centimeter" });

        public static readonly Unit<Density> PoundPerCubicFoot = new Unit<Density>(16.0185,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " lb/ft³", " lb/ft^3" }, new string[] { " pounds per cubic foot", " pound per cubic foot" });

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public static Density Create(double baseVal) => new(baseVal);

        [Obsolete("Use System.Numerics interfaces")]
        public Density Multiply(Density a, Ratio r) => r * a;

        [Obsolete("Use System.Numerics interfaces")]
        public Density Multiply(Ratio r, Density a) => r * a;

        public static Density Parse(string str, Unit<Density>? defaultUnit = null) => Unit<Density>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Density q, Unit<Density>? defaultUnit = null) => Unit<Density>.TryParse(str, out q, defaultUnit);

        public static Density operator +(Density a, Density b) => new(a.BaseValue + b.BaseValue);
        public static Density operator -(Density a, Density b) => new(a.BaseValue - b.BaseValue);
        public static Density operator *(Density a, double n) => new(a.BaseValue * n);
        public static Density operator *(Density a, Ratio r) => r * a;
        public static Density operator /(Density a, double n) => new(a.BaseValue / n);
        public static Density operator /(Density a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Density a, Density b) => new(a.BaseValue / b.BaseValue);
        public static Density operator -(Density a) => a * -1;
        public static Density AdditiveIdentity => new(0);
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
