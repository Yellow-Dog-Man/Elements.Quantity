using System;

namespace Elements.Quantity
{
    public readonly struct Ratio : IQuantity<Ratio>
    {
        #region ESSENTIALS

        // this section can be simply left as is

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Ratio(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Ratio other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Ratio other) { return BaseValue.CompareTo(other.BaseValue); }

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
        public Unit<Ratio> DefaultUnit { get { return RatioValue; } }

        // define actual units for the quantity (excluding SI units which are automatic)

        public static readonly Unit<Ratio> RatioValue = new Unit<Ratio>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { "" }, new string[] { "" });

        public static readonly Unit<Ratio> Percent = new Unit<Ratio>(1.0/100.0,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " %" }, new string[] { " percent" });

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Ratio New(double baseVal) { return new Ratio(baseVal); }

        public Ratio Min(Ratio q) { return new Ratio(Math.Min(BaseValue, q.BaseValue)); }
        public Ratio Max(Ratio q) { return new Ratio(Math.Max(BaseValue, q.BaseValue)); }

        public Ratio Add(Ratio q) { return new Ratio(BaseValue + q.BaseValue); }
        public Ratio Subtract(Ratio q) { return new Ratio(BaseValue - q.BaseValue); }

        public Ratio Multiply(double n) { return new Ratio(BaseValue * n); }
        public Ratio Multiply(Ratio a, Ratio r) { return a * r.BaseValue; }

        public Ratio Divide(double n) { return new Ratio(BaseValue / n); }
        public Ratio Divide(Ratio q) { return new Ratio(BaseValue / q.BaseValue); }

        public Ratio Lerp(Ratio q, double lerp)
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
        public Ratio LerpUnclamped(Ratio q, double lerp) { return new Ratio(BaseValue + (q.BaseValue - BaseValue) * lerp); }

        // these should be defined as convenience, but cannot be forced by interface
        public static Ratio Parse(string str, Unit<Ratio> defaultUnit = null) { return Unit<Ratio>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Ratio q, Unit<Ratio> defaultUnit = null) { return Unit<Ratio>.TryParse(str, out q, defaultUnit); }

        public static Ratio operator +(Ratio a, Ratio b) { return a.Add(b); }
        public static Ratio operator -(Ratio a, Ratio b) { return a.Subtract(b); }
        public static Ratio operator *(Ratio a, double n) { return a.Multiply(n); }
        public static Ratio operator /(Ratio a, double n) { return a.Divide(n); }
        public static Ratio operator /(Ratio a, Ratio b) { return a.Divide(b); }
        public static Ratio operator -(Ratio a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
