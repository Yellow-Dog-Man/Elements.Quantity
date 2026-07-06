using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Voltage : IQuantitySI<Voltage>,
        IDivisionOperators<Voltage, Ratio, Voltage>,
        IDivisionOperators<Voltage, Resistance, Current>,
        IDivisionOperators<Voltage, Current, Resistance>
    {
        #region ESSENTIALS

        // this section can be simply left as is, but rename Voltage

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Voltage(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Voltage other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Voltage other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        // Provide at least one short and one long name for the quantity
        // The first entry will be used for formatting, all will be used for parsing

        public string[] GetShortBaseNames() { return new string[] { "V" }; }
        public string[] GetLongBaseNames()
        { return new string[] { "volts", "volt" }; }

        #endregion

        /* *********************************************** */

        #region SI UNIT DEFINITIONS

        // the SI factor will be adjusted for this
        public double SIPower { get { return 1; } }

        // these units will be automatically registered in the Common groups
        public IUnit[] GetCommonSIUnits()
        {
            return new IUnit[] {
                SI<Voltage>.Quecto,
                SI<Voltage>.Ronto,
                SI<Voltage>.Yocto,
                SI<Voltage>.Zepto,
                SI<Voltage>.Atto,
                SI<Voltage>.Femto,
                SI<Voltage>.Pico,
                SI<Voltage>.Nano,
                SI<Voltage>.Micro,
                SI<Voltage>.Milli,
                SI<Voltage>.Kilo,
                SI<Voltage>.Mega,
                SI<Voltage>.Giga,
                SI<Voltage>.Tera,
                SI<Voltage>.Peta,
                SI<Voltage>.Exa,
                SI<Voltage>.Zetta,
                SI<Voltage>.Yotta,
                SI<Voltage>.Ronna,
                SI<Voltage>.Quetta,
            };
        }

        // these SI units will never be used for formatting, unless used explicitly
        public IUnit[] GetExludedSIUnits()
        {
            return new IUnit[] {
                SI<Voltage>.Centi,
                SI<Voltage>.Deci,
                SI<Voltage>.Deca,
                SI<Voltage>.Hecto,
            };
        }

        #endregion

        /* *********************************************** */

        #region UNITS

        // provide a default unit for the quantity - used when no explicit unit specified
        public Unit<Voltage> DefaultUnit { get { return Volt; } }

        /// <inheritdoc/>
        public string QuantityFamily => "Electronic";

        // define actual units for the quantity (excluding SI units which are automatic)
        // Parameters:

        public static readonly Unit<Voltage> Volt = new UnitSI<Voltage>(0, "", "");

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public static Voltage Create(double baseVal) => new(baseVal);

        [Obsolete("Use System.Numerics interfaces")]
        public Voltage Multiply(Voltage a, Ratio r) => r * a;

        [Obsolete("Use System.Numerics interfaces")]
        public Voltage Multiply(Ratio r, Voltage a) => r * a;

        public static Voltage Parse(string str, Unit<Voltage>? defaultUnit = null) => Unit<Voltage>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Voltage q, Unit<Voltage>? defaultUnit = null) => Unit<Voltage>.TryParse(str, out q, defaultUnit);

        public static Voltage operator +(Voltage a, Voltage b) => new(a.BaseValue + b.BaseValue);
        public static Voltage operator -(Voltage a, Voltage b) => new(a.BaseValue - b.BaseValue);
        public static Voltage operator *(Voltage a, double n) => new(a.BaseValue * n);
        public static Voltage operator *(Voltage a, Ratio r) => r * a;
        public static Voltage operator /(Voltage a, double n) => new(a.BaseValue / n);
        public static Voltage operator /(Voltage a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Voltage a, Voltage b) => new(a.BaseValue / b.BaseValue);
        public static Voltage operator -(Voltage a) => a * -1;
        public static Voltage AdditiveIdentity => new(0);
        public static Ratio MultiplicativeIdentity => Ratio.MultiplicativeIdentity;

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        public static Current operator /(Voltage v, Resistance r) => new(v.BaseValue / r.BaseValue);
        public static Resistance operator /(Voltage v, Current c) => new(v.BaseValue / c.BaseValue);

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
