using System;

namespace Elements.Quantity
{
    public readonly struct Distance : IQuantitySI<Distance>
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
        { return new string[] { "meters", "metres", "meter", "metre" }; }

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

        public static readonly Unit<Distance> Meter = new UnitSI<Distance>(0, "", "");

        // Scientific
        public static readonly Unit<Distance> Angstrom = new Unit<Distance>(1e-10,
            new UnitGroup[] { UnitGroup.Molecular },
            new string[] { " Å" }, new string[] { " ångströms", " ångström" });

        public static readonly Unit<Distance> SolarRadius = new Unit<Distance>(6.957e8,
            new UnitGroup[] { UnitGroup.Astronomical },
            new string[] { " R☉" }, new string[] { " Solar radii", " Solar radius", });

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
            new string[] { " pc" }, new string[] { " parsecs", " persec" });

        // Imperial
        public static readonly Unit<Distance> Thou = new Unit<Distance>(0.0000254,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " th" }, new string[] { " thou" });
            
        public static readonly Unit<Distance> Inch = new Unit<Distance>(0.0254,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " in", "\"" }, new string[] { " inches", " inch" });
            
        public static readonly Unit<Distance> Foot = new Unit<Distance>(0.3048,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " ft", "'" }, new string[] { " feet" });
            
        public static readonly Unit<Distance> Yard = new Unit<Distance>(0.9144,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " yd" }, new string[] { " yards", " yard" });
            
        public static readonly Unit<Distance> Mile = new Unit<Distance>(1609.344,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " mi" }, new string[] { " miles", " mile" });

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

        public Distance New(double baseVal) { return new Distance(baseVal); }

        public Distance Add(Distance q) { return new Distance(BaseValue + q.BaseValue); }
        public Distance Subtract(Distance q) { return new Distance(BaseValue - q.BaseValue); }

        public Distance Multiply(double n) { return new Distance(BaseValue * n); }
        public Distance Multiply(Distance a, Ratio r) { return a * r.BaseValue; }
        public Distance Multiply(Ratio r, Distance a) { return a * r.BaseValue; }

        public Distance Divide(double n) { return new Distance(BaseValue / n); }
        public Ratio Divide(Distance q) { return new Ratio(BaseValue / q.BaseValue); }

        // these should be defined as convenience, but cannot be forced by interface
        public static Distance Parse(string str, Unit<Distance> defaultUnit = null) { return Unit<Distance>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Distance q, Unit<Distance> defaultUnit = null) { return Unit<Distance>.TryParse(str, out q, defaultUnit); }

        public static Distance operator +(Distance a, Distance b) { return a.Add(b); }
        public static Distance operator -(Distance a, Distance b) { return a.Subtract(b); }
        public static Distance operator *(Distance a, double n) { return a.Multiply(n); }
        public static Distance operator /(Distance a, double n) { return a.Divide(n); }
        public static Ratio operator /(Distance a, Distance b) { return a.Divide(b); }
        public static Distance operator -(Distance a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        public static Velocity operator /(Distance l, Time t)
        { return Velocity.MetersPerSecond * (l.BaseValue / t.BaseValue); }

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
