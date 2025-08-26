using System;

namespace Elements.Quantity
{
    public readonly struct Temperature : IQuantity<Temperature>
    {
        #region ESSENTIALS

        // this section can be simply left as is, but rename Temperature

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Temperature(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Temperature other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Temperature other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        // Provide at least one short and one long name for the quantity
        // The first entry will be used for formatting, all will be used for parsing

        public string[] GetShortBaseNames() { return new string[] { "" }; }
        public string[] GetLongBaseNames()
        { return new string[] { "" }; }

        #endregion

        /* *********************************************** */

        #region UNITS

        // provide a default unit for the quantity - used when no explicit unit specified
        public Unit<Temperature> DefaultUnit { get { return Kelvin; } }

        // define actual units for the quantity (excluding SI units which are automatic)
        // Parameters:

        public static readonly Unit<Temperature> Kelvin = new Unit<Temperature>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " K" }, new string[] { " Kelvins", " Kelvin" });

        public static readonly Unit<Temperature> Celsius = new UnitNonLinear<Temperature>(
            (K)=>(K-273.15), (C)=>(C+273.15),
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " °C" }, new string[] { " Celsius", " degrees Celsius"});

        public static readonly Unit<Temperature> Fahrenheit = new UnitNonLinear<Temperature>(
            (K) => (K * (9.0 / 5.0) - 459.67), (F) => ((F + 459.67)*(5.0 / 9.0)),
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " °F" }, new string[] { " Fahrenheit", " degrees Fahrenheit" });

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Temperature New(double baseVal) { return new Temperature(baseVal); }

        public Temperature Add(Temperature q) { return new Temperature(BaseValue + q.BaseValue); }
        public Temperature Subtract(Temperature q) { return new Temperature(BaseValue - q.BaseValue); }

        public Temperature Multiply(double n) { return new Temperature(BaseValue * n); }
        public Temperature Multiply(Temperature a, Ratio r) { return a * r.BaseValue; }
        public Temperature Multiply(Ratio r, Temperature a) { return a * r.BaseValue; }

        public Temperature Divide(double n) { return new Temperature(BaseValue / n); }
        public Ratio Divide(Temperature q) { return new Ratio(BaseValue / q.BaseValue); }

        // these should be defined as convenience, but cannot be forced by interface
        public static Temperature Parse(string str, Unit<Temperature>? defaultUnit = null) { return Unit<Temperature>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Temperature q, Unit<Temperature>? defaultUnit = null) { return Unit<Temperature>.TryParse(str, out q, defaultUnit); }

        public static Temperature operator +(Temperature a, Temperature b) { return a.Add(b); }
        public static Temperature operator -(Temperature a, Temperature b) { return a.Subtract(b); }
        public static Temperature operator *(Temperature a, double n) { return a.Multiply(n); }
        public static Temperature operator /(Temperature a, double n) { return a.Divide(n); }
        public static Ratio operator /(Temperature a, Temperature b) { return a.Divide(b); }
        public static Temperature operator -(Temperature a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
