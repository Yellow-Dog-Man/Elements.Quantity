using System;

namespace Elements.Quantity
{
    public readonly struct Angle : IQuantitySI<Angle>
    {
        #region ESSENTIALS

        // this section can be simply left as is, but rename Angle

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Angle(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Angle other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Angle other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        // Provide at least one short and one long name for the quantity
        // The first entry will be used for formatting, all will be used for parsing

        public string[] GetShortBaseNames() { return new string[] { "rad" }; }
        public string[] GetLongBaseNames()
        { return new string[] { "radians", "radian" }; }

        #endregion

        /* *********************************************** */

        #region SI UNIT DEFINITIONS

        // the SI factor will be adjusted for this
        public double SIPower { get { return 1; } }

        // these units will be automatically registered in the Common groups
        public IUnit[] GetCommonSIUnits()
        {
            return new IUnit[] {
            };
        }

        // these SI units will never be used for formatting, unless used explicitly
        public IUnit[] GetExludedSIUnits()
        {
            return new IUnit[] {
                SI<Angle>.Centi,
                SI<Angle>.Deca,
                SI<Angle>.Deci,
                SI<Angle>.Hecto
            };
        }

        #endregion

        /* *********************************************** */

        #region UNITS

        // provide a default unit for the quantity - used when no explicit unit specified
        public Unit<Angle> DefaultUnit { get { return Radian; } }

        // define actual units for the quantity (excluding SI units which are automatic)
        // Parameters:

        public static readonly Unit<Angle> Radian = new UnitSI<Angle>(0, "", "");

        public static readonly Unit<Angle> Degree = new Unit<Angle>(Math.PI/180,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { "°" }, new string[] { " degrees", " degree", " deg" });

        public static readonly Unit<Angle> ArcMinute = new Unit<Angle>((Math.PI/180)/60.0,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { "′" }, new string[] { " arcmin", " amin" });

        public static readonly Unit<Angle> ArcSecond = new Unit<Angle>((Math.PI/180)/(60.0*60.0),
            new UnitGroup[] { UnitGroup.Common },
            new string[] { "″" }, new string[] { " arcsec", " asec" });

        #endregion

        /* *********************************************** */

        #region COMPOUND FORMATING TEMPLATES

        // define any commonly used compound formating templates

        public static readonly CompoundFormatInfo<Angle> DegreeMinSec =
            new CompoundFormatInfo<Angle>("", "0", CompoundZeroHandling.RemoveAny, false, false,
            new CompoundFormatInfo<Angle>.Info(Degree),
            new CompoundFormatInfo<Angle>.Info(ArcMinute),
            new CompoundFormatInfo<Angle>.Info(ArcSecond)
            );

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Angle New(double baseVal) { return new Angle(baseVal); }

        public Angle Add(Angle q) { return new Angle(BaseValue + q.BaseValue); }
        public Angle Subtract(Angle q) { return new Angle(BaseValue - q.BaseValue); }

        public Angle Multiply(double n) { return new Angle(BaseValue * n); }
        public Angle Multiply(Angle a, Ratio r) { return a * r.BaseValue; }
        public Angle Multiply(Ratio r, Angle a) { return a * r.BaseValue; }

        public Angle Divide(double n) { return new Angle(BaseValue / n); }
        public Ratio Divide(Angle q) { return new Ratio(BaseValue / q.BaseValue); }

        // these should be defined as convenience, but cannot be forced by interface
        public static Angle Parse(string str, Unit<Angle> defaultUnit = null) { return Unit<Angle>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Angle q, Unit<Angle> defaultUnit = null) { return Unit<Angle>.TryParse(str, out q, defaultUnit); }

        public static Angle operator +(Angle a, Angle b) { return a.Add(b); }
        public static Angle operator -(Angle a, Angle b) { return a.Subtract(b); }
        public static Angle operator *(Angle a, double n) { return a.Multiply(n); }
        public static Angle operator /(Angle a, double n) { return a.Divide(n); }
        public static Ratio operator /(Angle a, Angle b) { return a.Divide(b); }
        public static Angle operator -(Angle a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
