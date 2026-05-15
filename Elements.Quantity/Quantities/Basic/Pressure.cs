using System;

namespace Elements.Quantity
{
    public readonly struct Pressure : IQuantitySI<Pressure>
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

        public IUnit[] GetExcludedSIUnits()
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

        public static readonly Unit<Pressure> Pascal = new UnitSI<Pressure>(0, "Pa", "pascal");
        public static readonly Unit<Pressure> Bar = new Unit<Pressure>(1e5,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " bar" }, new string[] { " bars" });
        public static readonly Unit<Pressure> Atmosphere = new Unit<Pressure>(1.01325e5,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " atm" }, new string[] { " atmospheres" });
        public static readonly Unit<Pressure> Torr = new Unit<Pressure>(1.01325e5 / 760,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " Torr" }, new string[] { " torrs" });

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Pressure New(double baseVal) { return new Pressure(baseVal); }

        public Pressure Add(Pressure q) { return new Pressure(BaseValue + q.BaseValue); }
        public Pressure Subtract(Pressure q) { return new Pressure(BaseValue - q.BaseValue); }

        public Pressure Multiply(double n) { return new Pressure(BaseValue * n); }

        public Pressure Divide(double n) { return new Pressure(BaseValue / n); }
        public Ratio Divide(Pressure q) { return new Ratio(BaseValue / q.BaseValue); }

        public static Pressure Parse(string str, Unit<Pressure> defaultUnit = null) { return Unit<Pressure>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Pressure q, Unit<Pressure> defaultUnit = null) { return Unit<Pressure>.TryParse(str, out q, defaultUnit); }

        public static Pressure operator +(Pressure a, Pressure b) { return a.Add(b); }
        public static Pressure operator -(Pressure a, Pressure b) { return a.Subtract(b); }
        public static Pressure operator *(Pressure a, double n) { return a.Multiply(n); }
        public static Pressure operator /(Pressure a, double n) { return a.Divide(n); }
        public static Ratio operator /(Pressure a, Pressure b) { return a.Divide(b); }
        public static Pressure operator -(Pressure a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // ...any necessary conversions

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
