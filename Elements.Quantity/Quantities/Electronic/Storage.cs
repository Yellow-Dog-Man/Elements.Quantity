using System;

namespace Elements.Quantity
{
    public readonly struct Storage : IQuantitySI<Storage>
    {
        #region ESSENTIALS

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Storage(double baseValue = 0) : this() { this.BaseValue = baseValue; }

        public bool Equals(Storage other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Storage other) { return BaseValue.CompareTo(other.BaseValue); }

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
                SI<Storage>.Yotta,
                SI<Storage>.Zetta,
                SI<Storage>.Exa,
                SI<Storage>.Peta,
                SI<Storage>.Tera,
                SI<Storage>.Giga,
                SI<Storage>.Mega,
                SI<Storage>.Kilo,
                Byte,
            };
        }

        public IUnit[] GetExludedSIUnits()
        {
            return new IUnit[]
            {
                SI<Storage>.Deca,
                SI<Storage>.Hecto,
                SI<Storage>.Milli,
                SI<Storage>.Centi,
                SI<Storage>.Deci,
                SI<Storage>.Yocto,
                SI<Storage>.Zepto,
                SI<Storage>.Atto,
                SI<Storage>.Femto,
                SI<Storage>.Pico,
                SI<Storage>.Nano,
                SI<Storage>.Micro,
            };
        }

        #endregion

        /* *********************************************** */

        #region UNITS

        public Unit<Storage> DefaultUnit { get { return Byte; } }

        public static readonly Unit<Storage> Byte = new UnitSI<Storage>(0, "B", "byte");

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Storage New(double baseVal) { return new Storage(baseVal); }

        public Storage Add(Storage q) { return new Storage(BaseValue + q.BaseValue); }
        public Storage Subtract(Storage q) { return new Storage(BaseValue - q.BaseValue); }

        public Storage Multiply(double n) { return new Storage(BaseValue * n); }
        public Storage Multiply(Storage a, Ratio r) { return a * r.BaseValue; }
        public Storage Multiply(Ratio r, Storage a) { return a * r.BaseValue; }

        public Storage Divide(double n) { return new Storage(BaseValue / n); }
        public Ratio Divide(Storage q) { return new Ratio(BaseValue / q.BaseValue); }

        public static Storage Parse(string str, Unit<Storage> defaultUnit = null) { return Unit<Storage>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Storage q, Unit<Storage> defaultUnit = null) { return Unit<Storage>.TryParse(str, out q, defaultUnit); }

        public static Storage operator +(Storage a, Storage b) { return a.Add(b); }
        public static Storage operator -(Storage a, Storage b) { return a.Subtract(b); }
        public static Storage operator *(Storage a, double n) { return a.Multiply(n); }
        public static Storage operator /(Storage a, double n) { return a.Divide(n); }
        public static Ratio operator /(Storage a, Storage b) { return a.Divide(b); }
        public static Storage operator -(Storage a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
