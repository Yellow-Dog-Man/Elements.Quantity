using System;

namespace Elements.Quantity
{
    public readonly struct Voltage : IQuantitySI<Voltage>
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

        // define actual units for the quantity (excluding SI units which are automatic)
        // Parameters:

        public static readonly Unit<Voltage> Volt = new UnitSI<Voltage>(0, "", "");

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Voltage New(double baseVal) { return new Voltage(baseVal); }

        public Voltage Add(Voltage q) { return new Voltage(BaseValue + q.BaseValue); }
        public Voltage Subtract(Voltage q) { return new Voltage(BaseValue - q.BaseValue); }

        public Voltage Multiply(double n) { return new Voltage(BaseValue * n); }
        public Voltage Multiply(Voltage a, Ratio r) { return a * r.BaseValue; }
        public Voltage Multiply(Ratio r, Voltage a) { return a * r.BaseValue; }

        public Voltage Divide(double n) { return new Voltage(BaseValue / n); }
        public Ratio Divide(Voltage q) { return new Ratio(BaseValue / q.BaseValue); }

        // these should be defined as convenience, but cannot be forced by interface
        public static Voltage Parse(string str, Unit<Voltage>? defaultUnit = null) { return Unit<Voltage>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Voltage q, Unit<Voltage>? defaultUnit = null) { return Unit<Voltage>.TryParse(str, out q, defaultUnit); }

        public static Voltage operator +(Voltage a, Voltage b) { return a.Add(b); }
        public static Voltage operator -(Voltage a, Voltage b) { return a.Subtract(b); }
        public static Voltage operator *(Voltage a, double n) { return a.Multiply(n); }
        public static Voltage operator /(Voltage a, double n) { return a.Divide(n); }
        public static Ratio operator /(Voltage a, Voltage b) { return a.Divide(b); }
        public static Voltage operator -(Voltage a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        public static Current operator /(Voltage v, Resistance r) { return new Current(v.BaseValue / r.BaseValue); }
        public static Resistance operator /(Voltage v, Current c) { return new Resistance(v.BaseValue / c.BaseValue); }

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
