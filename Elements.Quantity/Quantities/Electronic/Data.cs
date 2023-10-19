using System;

namespace Elements.Quantity
{
    public readonly struct Data : IQuantitySI<Data>
    {
        #region ESSENTIALS

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Data(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Data other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Data other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        public string[] GetShortBaseNames() { return new string[] { "B" }; }
        public string[] GetLongBaseNames() { return new string[] { "bytes", "byte" }; }

        #endregion

        /* *********************************************** */

        #region SI UNIT DEFINITIONS

        public double SIPower { get { return 1; } }

        public IUnit[] GetCommonSIUnits()
        {
            return new IUnit[]
            {
                SI<Data>.Yotta,
                SI<Data>.Zetta,
                SI<Data>.Exa,
                SI<Data>.Peta,
                SI<Data>.Tera,
                SI<Data>.Giga,
                SI<Data>.Mega,
                SI<Data>.Kilo,
                Byte,
            };
        }

        public IUnit[] GetExludedSIUnits()
        {
            return new IUnit[]
            {
                SI<Data>.Deca,
                SI<Data>.Hecto,
                SI<Data>.Milli,
                SI<Data>.Centi,
                SI<Data>.Deci,
                SI<Data>.Yocto,
                SI<Data>.Zepto,
                SI<Data>.Atto,
                SI<Data>.Femto,
                SI<Data>.Pico,
                SI<Data>.Nano,
                SI<Data>.Micro,
            };
        }

        #endregion

        /* *********************************************** */

        #region UNITS

        public Unit<Data> DefaultUnit { get { return Byte; } }

        public static readonly Unit<Data> Byte = new UnitSI<Data>(0, "", "");

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Data New(double baseVal) { return new Data(baseVal); }

        public Data Add(Data q) { return new Data(BaseValue + q.BaseValue); }
        public Data Subtract(Data q) { return new Data(BaseValue - q.BaseValue); }

        public Data Multiply(double n) { return new Data(BaseValue * n); }
        public Data Multiply(Data a, Ratio r) { return a * r.BaseValue; }
        public Data Multiply(Ratio r, Data a) { return a * r.BaseValue; }

        public Data Divide(double n) { return new Data(BaseValue / n); }
        public Ratio Divide(Data q) { return new Ratio(BaseValue / q.BaseValue); }

        public static Data Parse(string str, Unit<Data> defaultUnit = null) { return Unit<Data>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Data q, Unit<Data> defaultUnit = null) { return Unit<Data>.TryParse(str, out q, defaultUnit); }

        public static Data operator +(Data a, Data b) { return a.Add(b); }
        public static Data operator -(Data a, Data b) { return a.Subtract(b); }
        public static Data operator *(Data a, double n) { return a.Multiply(n); }
        public static Data operator /(Data a, double n) { return a.Divide(n); }
        public static Ratio operator /(Data a, Data b) { return a.Divide(b); }
        public static Data operator -(Data a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
