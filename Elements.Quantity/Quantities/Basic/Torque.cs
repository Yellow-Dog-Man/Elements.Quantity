using System;

namespace Elements.Quantity
{
    public readonly struct Torque : IQuantity<Torque>
    {
        #region ESSENTIALS

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Torque(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Torque other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Torque other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        #region QUANTITY NAME DEFINITIONS

        public string[] GetShortBaseNames() { return new string[] { "Nm" }; }
        public string[] GetLongBaseNames() { return new string[] { "newton meters", "newton meter" }; }

        #endregion

        #region UNITS

        public Unit<Torque> DefaultUnit { get { return NewtonMeter; } }

        public static readonly Unit<Torque> NewtonMeter = new Unit<Torque>(1,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { " Nm" }, new string[] { "newton meters" });

        public static readonly Unit<Torque> PoundFoot = new Unit<Torque>(1.35582,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " lb·ft" }, new string[] { "pound-feet" });

        #endregion

        #region OPERATORS

        public Torque New(double baseVal) { return new Torque(baseVal); }

        public Torque Add(Torque q) { return new Torque(BaseValue + q.BaseValue); }
        public Torque Subtract(Torque q) { return new Torque(BaseValue - q.BaseValue); }

        public Torque Multiply(double n) { return new Torque(BaseValue * n); }
        public Torque Multiply(Torque a, Ratio r) { return a * r.BaseValue; }
        public Torque Multiply(Ratio r, Torque a) { return a * r.BaseValue; }

        public Torque Divide(double n) { return new Torque(BaseValue / n); }
        public Ratio Divide(Torque q) { return new Ratio(BaseValue / q.BaseValue); }

        public static Torque Parse(string str) { return Unit<Torque>.Parse(str); }
        public static bool TryParse(string str, out Torque q) { return Unit<Torque>.TryParse(str, out q); }

        public static Torque operator +(Torque a, Torque b) { return a.Add(b); }
        public static Torque operator -(Torque a, Torque b) { return a.Subtract(b); }
        public static Torque operator *(Torque a, double n) { return a.Multiply(n); }
        public static Torque operator /(Torque a, double n) { return a.Divide(n); }
        public static Ratio operator /(Torque a, Torque b) { return a.Divide(b); }
        public static Torque operator -(Torque a) { return a.Multiply(-1); }

        #endregion
    }
}
