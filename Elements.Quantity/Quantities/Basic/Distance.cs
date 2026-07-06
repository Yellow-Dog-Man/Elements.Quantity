using System;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct Distance : IQuantitySI<Distance>,
        IDivisionOperators<Distance, Ratio, Distance>,
        IDivisionOperators<Distance, Time, Velocity>,
        IDivisionOperators<Distance, Velocity, Time>
    {
        #region ESSENTIALS

        // this section can be simply left as is

        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Distance(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Distance other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Distance other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        public string[] GetShortBaseNames() { return new string[] { "m" }; }
        public string[] GetLongBaseNames()
        { return new string[] { "meters", "meter", "metres", "metre" }; }

        #endregion

        /* *********************************************** */

        #region SI UNIT DEFINITIONS

        public double SIPower { get { return 1; } }

        public IUnit[] GetCommonSIUnits()
        {
            return new IUnit[] {
                SI<Distance>.Kilo,
                Meter,
                SI<Distance>.Centi,
                SI<Distance>.Milli,
                SI<Distance>.Micro,
                SI<Distance>.Nano,
                SI<Distance>.Pico,
                SI<Distance>.Femto,
                SI<Distance>.Atto,
            };
        }

        public IUnit[] GetExludedSIUnits()
        {
            return new IUnit[] {
                SI<Distance>.Deca,
                SI<Distance>.Hecto,
            };
        }

        #endregion

        /* *********************************************** */

        #region UNITS

        public Unit<Distance> DefaultUnit { get { return Meter; } }

        /// <inheritdoc/>
        public string QuantityFamily => string.Empty;

        public static readonly Unit<Distance> Meter = new UnitSI<Distance>(0, "", "");

        // Scientific
        public static readonly Unit<Distance> Angstrom = new Unit<Distance>(1e-10,
            new UnitGroup[] { UnitGroup.Molecular },
            new string[] { " Å" }, new string[] { " ångströms", " ångström" });

        public static readonly Unit<Distance> SolarRadius = new Unit<Distance>(6.957e8,
            new UnitGroup[] { UnitGroup.Astronomical },
            new string[] { " R☉" }, new string[] { " Solar radii", " Solar radius" });

        public static readonly Unit<Distance> AU = new Unit<Distance>(149597871464,
            new UnitGroup[] { UnitGroup.Astronomical, UnitGroup.Common },
            new string[] { " AU" }, new string[] { " Astronomical Units", " Astronomical Unit", });

        public static readonly Unit<Distance> Lightyear = new Unit<Distance>(9.4607304725808e15,
            new UnitGroup[] { UnitGroup.Astronomical, UnitGroup.Common },
            new string[] { " ly" }, new string[] { " lightyears", " lightyear" });

        public static readonly Unit<Distance> Lightsecond = new Unit<Distance>(299792458,
            new UnitGroup[] { UnitGroup.Astronomical },
            new string[] { " ls" }, new string[] { " lightseconds", " lightsecond" });

        public static readonly Unit<Distance> Parsec = new Unit<Distance>(3.0857e16,
            new UnitGroup[] { UnitGroup.Astronomical },
            new string[] { " pc" }, new string[] { " parsecs", " parsec" });

        // Imperial
        public static readonly Unit<Distance> Thou = new Unit<Distance>(0.0000254,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " th" }, new string[] { " thous", " thou" });

        public static readonly Unit<Distance> Inch = new Unit<Distance>(0.0254,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " in", "\"" }, new string[] { " inches", " inch" });

        public static readonly Unit<Distance> Foot = new Unit<Distance>(0.3048,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " ft", "'" }, new string[] { " feet", " foot" });

        public static readonly Unit<Distance> Yard = new Unit<Distance>(0.9144,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " yd" }, new string[] { " yards", " yard" });

        public static readonly Unit<Distance> Mile = new Unit<Distance>(1609.344,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " mi" }, new string[] { " miles", " mile" });

        //Marine
        public static readonly Unit<Distance> NauticalMile = new Unit<Distance>(1852,
            new UnitGroup[] { UnitGroup.Maritime },
            new string[] { " NM" }, new string[] { " nautical miles", " nautical mile" });

        public static readonly Unit<Distance> Fathom = new Unit<Distance>(1.8288,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " ftm" }, new string[] { " fathoms", " fathom" });


        //Surveying

        /// <summary>
        /// <seealso href="https://en.wikipedia.org/wiki/Chain_(unit)"/>Chains</seealso> are used in various niche applications like tires and surveying.
        /// </summary>
        public static readonly Unit<Distance> Chain = new Unit<Distance>(20.1168,
            new UnitGroup[] { UnitGroup.Surveying },
            new string[] { " ch" }, new string[] { " chains", " chain" });

        /// <summary>
        /// <seealso href="https://en.wikipedia.org/wiki/Rod_(unit)"/>Rods</seealso> are used in various niche applications such as surveying.
        /// </summary>
        public static readonly Unit<Distance> Rod = new Unit<Distance>(5.0292,
            new UnitGroup[] { UnitGroup.Surveying },
            new string[] { " rd" }, new string[] { " rods", " rod" });
        #endregion

        /* *********************************************** */

        #region COMPOUND FORMATING TEMPLATES

        public static readonly CompoundFormatInfo<Distance> FeetInches =
            new CompoundFormatInfo<Distance>("", "0", CompoundZeroHandling.RemoveAny, false, false,
            new CompoundFormatInfo<Distance>.Info(Foot, "'"),
            new CompoundFormatInfo<Distance>.Info(Inch, "\"")
            );

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public static Distance Create(double baseVal) => new(baseVal);

        [Obsolete("Use System.Numerics interfaces")]
        public Distance Multiply(Distance a, Ratio r) => r * a;

        [Obsolete("Use System.Numerics interfaces")]
        public Distance Multiply(Ratio r, Distance a) => r * a;

        public static Distance Parse(string str, Unit<Distance>? defaultUnit = null) => Unit<Distance>.Parse(str, defaultUnit);
        public static bool TryParse(string str, out Distance q, Unit<Distance>? defaultUnit = null) => Unit<Distance>.TryParse(str, out q, defaultUnit);

        public static Distance operator +(Distance a, Distance b) => new(a.BaseValue + b.BaseValue);
        public static Distance operator -(Distance a, Distance b) => new(a.BaseValue - b.BaseValue);
        public static Distance operator *(Distance a, double n) => new(a.BaseValue * n);
        public static Distance operator *(Distance a, Ratio r) => r * a;
        public static Distance operator /(Distance a, double n) => new(a.BaseValue / n);
        public static Distance operator /(Distance a, Ratio r) => a / r.BaseValue;
        public static Ratio operator /(Distance a, Distance b) => new(a.BaseValue / b.BaseValue);
        public static Distance operator -(Distance a) => a * -1;
        public static Distance AdditiveIdentity => new(0);
        public static Ratio MultiplicativeIdentity => Ratio.MultiplicativeIdentity;

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        public static Velocity operator /(Distance l, Time t) => Velocity.MetersPerSecond * (l.BaseValue /* m */ / t.BaseValue /* s */);
        public static Time operator /(Distance l, Velocity v) => Time.Second * (l.BaseValue /* m */ / v.BaseValue /* m/s */);

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
