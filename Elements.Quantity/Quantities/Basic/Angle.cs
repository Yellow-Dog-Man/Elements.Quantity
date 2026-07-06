using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Angle : IQuantitySI<Angle>,
        IDivisionOperators<Angle, Ratio, Angle>
    {
        #region ESSENTIALS

        // this section can be simply left as is, but rename Angle

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        /// <summary>
        ///
        /// </summary>
        /// <param name="baseValue">Base value, using <see cref="DefaultUnit"/>'s value as the unit.</param>
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

        /// <inheritdoc/>
        public string QuantityFamily => string.Empty;

        // define actual units for the quantity (excluding SI units which are automatic)
        // Parameters:

        public static readonly Unit<Angle> Radian = new UnitSI<Angle>(0, "", "");

        public static readonly Unit<Angle> Degree = new Unit<Angle>(Math.PI / 180.0,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { "°" }, new string[] { " degrees", " degree", " deg" });

        public static readonly Unit<Angle> ArcMinute = new Unit<Angle>((Math.PI / 180.0) / 60.0,
            new UnitGroup[] { UnitGroup.Common },
            new string[] { "′" }, new string[] { " arcminutes", " arcminute", " arcmin", " amin" });

        public static readonly Unit<Angle> ArcSecond = new Unit<Angle>((Math.PI / 180.0) / (60.0 * 60.0),
            new UnitGroup[] { UnitGroup.Common },
            new string[] { "″" }, new string[] { " arcseconds", " arcsecond", " arcsec", " asec" });

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

        public static Angle Create(double baseValue) => new(baseValue);

        [Obsolete("Use System.Numerics interfaces")]
        public Angle Multiply(Angle a, Ratio r) => r * a;

        [Obsolete("Use System.Numerics interfaces")]
        public Angle Multiply(Ratio r, Angle a) => r * a;

        public static Angle Parse(string str, Unit<Angle>? defaultUnit = null) => Unit<Angle>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Angle q, Unit<Angle>? defaultUnit = null) => Unit<Angle>.TryParse(str, out q, defaultUnit);

        public static Angle operator +(Angle a, Angle b) => new(a.BaseValue + b.BaseValue);
        public static Angle operator -(Angle a, Angle b) => new(a.BaseValue - b.BaseValue);
        public static Angle operator *(Angle a, double n) => new(a.BaseValue * n);
        public static Angle operator *(Angle a, Ratio r) => r * a;
        public static Angle operator /(Angle a, double n) => new(a.BaseValue / n);
        public static Angle operator /(Angle a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Angle a, Angle b) => new(a.BaseValue / b.BaseValue);
        public static Angle operator -(Angle a) => a * -1;
        public static Angle AdditiveIdentity => new(0);
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
