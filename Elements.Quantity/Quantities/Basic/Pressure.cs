using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Pressure : IQuantitySI<Pressure>,
        IDivisionOperators<Pressure, Ratio, Pressure>
    {
        #region ESSENTIALS

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Pressure(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Pressure other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Pressure other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        public string[] GetShortBaseNames() { return new string[] { "Pa" }; }
        public string[] GetLongBaseNames()
        { return new string[] { "pascals", "pascal" }; }

        #endregion

        /* *********************************************** */

        #region SI UNIT DEFINITIONS

        public double SIPower { get { return 1; } }

        public IUnit[] GetCommonSIUnits()
        {
            return new IUnit[] {
                SI<Pressure>.Pico,
                SI<Pressure>.Nano,
                SI<Pressure>.Micro,
                SI<Pressure>.Milli,
                SI<Pressure>.Centi,
                SI<Pressure>.Deci,
                SI<Pressure>.Kilo,
                SI<Pressure>.Mega,
                SI<Pressure>.Giga,
                SI<Pressure>.Tera,
                SI<Pressure>.Peta,
                SI<Pressure>.Exa,
                SI<Pressure>.Zetta,
                SI<Pressure>.Yotta
            };
        }

        public IUnit[] GetExludedSIUnits()
        {
            return new IUnit[] {
                SI<Pressure>.Quecto,
                SI<Pressure>.Ronto,
                SI<Pressure>.Yocto,
                SI<Pressure>.Zepto,
                SI<Pressure>.Atto,
                SI<Pressure>.Femto,
                SI<Pressure>.Deca,
                SI<Pressure>.Hecto,
                SI<Pressure>.Ronna,
                SI<Pressure>.Quetta
            };
        }

        #endregion

        /* *********************************************** */

        #region UNITS

        public Unit<Pressure> DefaultUnit { get { return Pascal; } }

        /// <inheritdoc/>
        public string QuantityFamily => string.Empty;

        public static readonly Unit<Pressure> Pascal = new UnitSI<Pressure>(0, "", "");
        public static readonly Unit<Pressure> Bar = new Unit<Pressure>(1e5,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " bar" }, new string[] { " bars", " bar" });
        public static readonly Unit<Pressure> Atmosphere = new Unit<Pressure>(1.01325e5,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " atm" }, new string[] { " standard atmospheres", " standard atmosphere", " atmospheres", " atmosphere" });
        public static readonly Unit<Pressure> Torr = new Unit<Pressure>(1.01325e5 / 760,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " Torr" }, new string[] { " torrs", " torr" });
        public static readonly Unit<Pressure> Millibar = new Unit<Pressure>(100,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " mbar" }, new string[] { " millibars", " millibar" });
        public static readonly Unit<Pressure> PoundPerSquareInch = new Unit<Pressure>(1.450377e-4,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " psi", " lbf/in²", " lbf/in^2" }, new string[] { " pounds per square inch", " pound per square inch", "pound-forces per square inch", "pound-force per square inch" });

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public static Pressure Create(double baseVal) => new(baseVal);

        public static Pressure Parse(string str, Unit<Pressure>? defaultUnit = null) => Unit<Pressure>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Pressure q, Unit<Pressure>? defaultUnit = null) => Unit<Pressure>.TryParse(str, out q, defaultUnit);

        public static Pressure operator +(Pressure a, Pressure b) => new(a.BaseValue + b.BaseValue);
        public static Pressure operator -(Pressure a, Pressure b) => new(a.BaseValue - b.BaseValue);
        public static Pressure operator *(Pressure a, double n) => new(a.BaseValue * n);
        public static Pressure operator *(Pressure a, Ratio r) => r * a;
        public static Pressure operator /(Pressure a, double n) => new(a.BaseValue / n);
        public static Pressure operator /(Pressure a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Pressure a, Pressure b) => new(a.BaseValue / b.BaseValue);
        public static Pressure operator -(Pressure a) => a * -1;
        public static Pressure AdditiveIdentity => new(0);
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
