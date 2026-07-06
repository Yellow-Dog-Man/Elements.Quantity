using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Torque : IQuantity<Torque>,
        IDivisionOperators<Torque, Ratio, Torque>
    {
        #region ESSENTIALS

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Torque(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Torque other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Torque other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        #region QUANTITY NAME DEFINITIONS

        public string[] GetShortBaseNames() { return new string[] { "" }; }
        public string[] GetLongBaseNames() { return new string[] { "" }; }

        #endregion

        #region UNITS

        public Unit<Torque> DefaultUnit { get { return NewtonMeter; } }

        /// <inheritdoc/>
        public string QuantityFamily => string.Empty;

        public static readonly Unit<Torque> NewtonMeter = new Unit<Torque>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " N m", " N·m" }, new string[] { " newton meters", " newton meter", " newton metres", " newton metre" });

        public static readonly Unit<Torque> PoundFoot = new Unit<Torque>(1.35582,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " lb·ft", " lb-ft", " lbf·ft", " lbf-ft" }, new string[] { " pound-feet", " pound-foot" });

        #endregion

        #region OPERATORS

        public static Torque Create(double baseVal) => new(baseVal);

        [Obsolete("Use System.Numerics interfaces")]
        public Torque Multiply(Torque a, Ratio r) => r * a;

        [Obsolete("Use System.Numerics interfaces")]
        public Torque Multiply(Ratio r, Torque a) => r * a;

        public static Torque Parse(string str, Unit<Torque>? defaultUnit = null) { return Unit<Torque>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Torque q, Unit<Torque>? defaultUnit = null) { return Unit<Torque>.TryParse(str, out q, defaultUnit); }

        public static Torque operator +(Torque a, Torque b) => new(a.BaseValue + b.BaseValue);
        public static Torque operator -(Torque a, Torque b) => new(a.BaseValue - b.BaseValue);
        public static Torque operator *(Torque a, double n) => new(a.BaseValue * n);
        public static Torque operator *(Torque a, Ratio r) => r * a;
        public static Torque operator /(Torque a, double n) => new(a.BaseValue / n);
        public static Torque operator /(Torque a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Torque a, Torque b) => new(a.BaseValue / b.BaseValue);
        public static Torque operator -(Torque a) => a * -1;
        public static Torque AdditiveIdentity => new(0);
        public static Ratio MultiplicativeIdentity => Ratio.MultiplicativeIdentity;

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
