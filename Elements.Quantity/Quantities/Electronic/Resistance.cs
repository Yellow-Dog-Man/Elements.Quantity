using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Resistance : IQuantitySI<Resistance>,
        IDivisionOperators<Resistance, Ratio, Resistance>,
        IMultiplyOperators<Resistance, Current, Voltage>
    {
        #region ESSENTIALS

        // this section can be simply left as is, but rename Resistance

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Resistance(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Resistance other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Resistance other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        // Provide at least one short and one long name for the quantity
        // The first entry will be used for formatting, all will be used for parsing

        public string[] GetShortBaseNames() { return new string[] { "Ω" }; }
        public string[] GetLongBaseNames()
        { return new string[] { "ohms", "ohm" }; }

        #endregion

        /* *********************************************** */

        #region SI UNIT DEFINITIONS

        // the SI factor will be adjusted for this
        public double SIPower { get { return 1; } }

        // these units will be automatically registered in the Common groups
        public IUnit[] GetCommonSIUnits()
        {
            return new IUnit[] {
                SI<Resistance>.Quecto,
                SI<Resistance>.Ronto,
                SI<Resistance>.Yocto,
                SI<Resistance>.Zepto,
                SI<Resistance>.Atto,
                SI<Resistance>.Femto,
                SI<Resistance>.Pico,
                SI<Resistance>.Nano,
                SI<Resistance>.Micro,
                SI<Resistance>.Milli,
                SI<Resistance>.Kilo,
                SI<Resistance>.Mega,
                SI<Resistance>.Giga,
                SI<Resistance>.Tera,
                SI<Resistance>.Peta,
                SI<Resistance>.Exa,
                SI<Resistance>.Zetta,
                SI<Resistance>.Yotta,
                SI<Resistance>.Ronna,
                SI<Resistance>.Quetta,
            };
        }

        // these SI units will never be used for formatting, unless used explicitly
        public IUnit[] GetExludedSIUnits()
        {
            return new IUnit[] {
                SI<Resistance>.Centi,
                SI<Resistance>.Deci,
                SI<Resistance>.Deca,
                SI<Resistance>.Hecto,
            };
        }

        #endregion

        /* *********************************************** */

        #region UNITS

        // provide a default unit for the quantity - used when no explicit unit specified
        public Unit<Resistance> DefaultUnit { get { return Ohm; } }

        /// <inheritdoc/>
        public string QuantityFamily => "Electronic";

        // define actual units for the quantity (excluding SI units which are automatic)
        // Parameters:

        public static readonly Unit<Resistance> Ohm = new UnitSI<Resistance>(0, "", "");

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public static Resistance Create(double baseVal) => new(baseVal);

        [Obsolete("Use System.Numerics interfaces")]
        public Resistance Multiply(Resistance a, Ratio r) => r * a;

        [Obsolete("Use System.Numerics interfaces")]
        public Resistance Multiply(Ratio r, Resistance a) => r * a;

        public static Resistance Parse(string str, Unit<Resistance>? defaultUnit = null) => Unit<Resistance>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Resistance q, Unit<Resistance>? defaultUnit = null) => Unit<Resistance>.TryParse(str, out q, defaultUnit);

        public static Resistance operator +(Resistance a, Resistance b) => new(a.BaseValue + b.BaseValue);
        public static Resistance operator -(Resistance a, Resistance b) => new(a.BaseValue - b.BaseValue);
        public static Resistance operator *(Resistance a, double n) => new(a.BaseValue * n);
        public static Resistance operator *(Resistance a, Ratio r) => r * a;
        public static Resistance operator /(Resistance a, double n) => new(a.BaseValue / n);
        public static Resistance operator /(Resistance a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Resistance a, Resistance b) => new(a.BaseValue / b.BaseValue);
        public static Resistance operator -(Resistance a) => a * -1;
        public static Resistance AdditiveIdentity => new(0);
        public static Ratio MultiplicativeIdentity => Ratio.MultiplicativeIdentity;

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        public static Voltage operator *(Resistance r, Current i) => new(r.BaseValue * i.BaseValue);

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
