using System;

namespace Elements.Quantity
{
    public readonly struct Current : IQuantitySI<Current>
    {
        #region ESSENTIALS

        // this section can be simply left as is, but rename Current

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Current(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Current other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Current other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        // Provide at least one short and one long name for the quantity
        // The first entry will be used for formatting, all will be used for parsing

        public string[] GetShortBaseNames() { return new string[] { "A" }; }
        public string[] GetLongBaseNames()
        { return new string[] { "amperes", "ampere" }; }

        #endregion

        /* *********************************************** */

        #region SI UNIT DEFINITIONS

        // the SI factor will be adjusted for this
        public double SIPower { get { return 1; } }

        // these units will be automatically registered in the Common groups
        public IUnit[] GetCommonSIUnits()
        {
            return new IUnit[] {
                SI<Current>.Quecto,
                SI<Current>.Ronto,
                SI<Current>.Yocto,
                SI<Current>.Zepto,
                SI<Current>.Atto,
                SI<Current>.Femto,
                SI<Current>.Pico,
                SI<Current>.Nano,
                SI<Current>.Micro,
                SI<Current>.Milli,
                SI<Current>.Kilo,
                SI<Current>.Mega,
                SI<Current>.Giga,
                SI<Current>.Tera,
                SI<Current>.Peta,
                SI<Current>.Exa,
                SI<Current>.Zetta,
                SI<Current>.Yotta,
                SI<Current>.Ronna,
                SI<Current>.Quetta,
            };
        }

        // these SI units will never be used for formatting, unless used explicitly
        public IUnit[] GetExludedSIUnits()
        {
            return new IUnit[] {
                SI<Current>.Centi,
                SI<Current>.Deci,
                SI<Current>.Deca,
                SI<Current>.Hecto,
            };
        }

        #endregion

        /* *********************************************** */

        #region UNITS

        // provide a default unit for the quantity - used when no explicit unit specified
        public Unit<Current> DefaultUnit { get { return Ampere; } }

        // define actual units for the quantity (excluding SI units which are automatic)
        // Parameters:

        public static readonly Unit<Current> Ampere = new UnitSI<Current>(0, "", "");

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Current New(double baseVal) { return new Current(baseVal); }

        public Current Min(Current q) { return new Current(Math.Min(BaseValue, q.BaseValue)); }
        public Current Max(Current q) { return new Current(Math.Max(BaseValue, q.BaseValue)); }

        public Current Add(Current q) { return new Current(BaseValue + q.BaseValue); }
        public Current Subtract(Current q) { return new Current(BaseValue - q.BaseValue); }

        public Current Multiply(double n) { return new Current(BaseValue * n); }
        public Current Multiply(Current a, Ratio r) { return a * r.BaseValue; }
        public Current Multiply(Ratio r, Current a) { return a * r.BaseValue; }

        public Current Divide(double n) { return new Current(BaseValue / n); }
        public Ratio Divide(Current q) { return new Ratio(BaseValue / q.BaseValue); }

        public Current Lerp(Current q, double lerp)
        {
            if (lerp <= 0.0)
            {
                return this;
            }
            if (lerp >= 1.0)
            {
                return q;
            }
            return LerpUnclamped(q, lerp);
        }
        public Current LerpUnclamped(Current q, double lerp) { return new Current(BaseValue + (q.BaseValue - BaseValue) * lerp); }

        // these should be defined as convenience, but cannot be forced by interface
        public static Current Parse(string str, Unit<Current> defaultUnit = null) { return Unit<Current>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Current q, Unit<Current> defaultUnit = null) { return Unit<Current>.TryParse(str, out q, defaultUnit); }

        public static Current operator +(Current a, Current b) { return a.Add(b); }
        public static Current operator -(Current a, Current b) { return a.Subtract(b); }
        public static Current operator *(Current a, double n) { return a.Multiply(n); }
        public static Current operator /(Current a, double n) { return a.Divide(n); }
        public static Ratio operator /(Current a, Current b) { return a.Divide(b); }
        public static Current operator -(Current a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
