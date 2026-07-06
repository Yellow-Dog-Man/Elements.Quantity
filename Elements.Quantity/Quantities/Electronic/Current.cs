using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Current : IQuantitySI<Current>,
        IDivisionOperators<Current, Ratio, Current>,
        IMultiplyOperators<Current, Resistance, Voltage>
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

        /// <inheritdoc/>
        public string QuantityFamily => "Electronic";

        // define actual units for the quantity (excluding SI units which are automatic)
        // Parameters:

        public static readonly Unit<Current> Ampere = new UnitSI<Current>(0, "", "");

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public static Current Create(double baseVal) => new(baseVal);

        [Obsolete("Use System.Numerics interfaces")]
        public Current Multiply(Current a, Ratio r) => r * a;

        [Obsolete("Use System.Numerics interfaces")]
        public Current Multiply(Ratio r, Current a) => r * a;

        public static Current Parse(string str, Unit<Current>? defaultUnit = null) => Unit<Current>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Current q, Unit<Current>? defaultUnit = null) => Unit<Current>.TryParse(str, out q, defaultUnit);

        public static Current operator +(Current a, Current b) => new(a.BaseValue + b.BaseValue);
        public static Current operator -(Current a, Current b) => new(a.BaseValue - b.BaseValue);
        public static Current operator *(Current a, double n) => new(a.BaseValue * n);
        public static Current operator *(Current a, Ratio r) => r * a;
        public static Current operator /(Current a, double n) => new(a.BaseValue / n);
        public static Current operator /(Current a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Current a, Current b) => new(a.BaseValue / b.BaseValue);
        public static Current operator -(Current a) => a * -1;
        public static Current AdditiveIdentity => new(0);
        public static Ratio MultiplicativeIdentity => Ratio.MultiplicativeIdentity;

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        public static Voltage operator *(Current i, Resistance r) => new(r.BaseValue * i.BaseValue);

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
