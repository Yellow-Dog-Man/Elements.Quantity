using System;

namespace Elements.Quantity
{
    public readonly struct Mass : IQuantitySI<Mass>
    {
        #region ESSENTIALS

        // this section can be simply left as is, but rename Mass

        // Base unit is gram!!!
        public readonly double BaseValue;

        double IQuantity.BaseValue => BaseValue;

        public Mass(double baseValue = 0) : this() { BaseValue = baseValue; }

        public bool Equals(Mass other) { return BaseValue == other.BaseValue; }
        public int CompareTo(Mass other) { return BaseValue.CompareTo(other.BaseValue); }

        #endregion

        /* *********************************************** */

        #region QUANTITY NAME DEFINITIONS

        // Provide at least one short and one long name for the quantity
        // The first entry will be used for formatting, all will be used for parsing

        public string[] GetShortBaseNames() { return new string[] { "g" }; }
        public string[] GetLongBaseNames()
        { return new string[] { "grams", "gram" }; }

        #endregion

        /* *********************************************** */

        #region SI UNIT DEFINITIONS

        // the SI factor will be adjusted for this
        public double SIPower { get { return 1; } }

        // these units will be automatically registered in the Common groups
        public IUnit[] GetCommonSIUnits()
        {
            return new IUnit[] {
                SI<Mass>.Kilo,
                Gram,
                SI<Mass>.Milli,
                SI<Mass>.Micro,
                SI<Mass>.Nano,
                SI<Mass>.Pico
            };
        }

        // these SI units will never be used for formatting, unless used explicitly
        public IUnit[] GetExludedSIUnits()
        {
            return new IUnit[] {
                SI<Mass>.Hecto,
                SI<Mass>.Mega,  // use Ton instead
            };
        }

        #endregion

        /* *********************************************** */

        #region UNITS

        // provide a default unit for the quantity - used when no explicit unit specified
        public Unit<Mass> DefaultUnit { get { return SI<Mass>.Kilo; } }

        // define actual units for the quantity (excluding SI units which are automatic)
        // Parameters:

        public static readonly Unit<Mass> Gram = new UnitSI<Mass>(0, "", "");

        public static readonly Unit<Mass> Tonne = new Unit<Mass>(1e6,
            new UnitGroup[] { UnitGroup.Common, UnitGroup.Metric },
            new string[] { " t" }, new string[] { " tonnes", " tonne" });

        [Obsolete("Use 'Mass.Tonne' instead.")]
        public static readonly Unit<Mass> Ton = Tonne;

        // Imperial
        public static readonly Unit<Mass> Grain = new Unit<Mass>(0.06479891,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " gr" }, new string[] { " grains", " grain" } );

        public static readonly Unit<Mass> Drachm = new Unit<Mass>(1.7718451953125,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " dr" }, new string[] { " drachms", " drachm" });

        public static readonly Unit<Mass> Ounce = new Unit<Mass>(28.349523125,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " oz" }, new string[] { " ounces", " ounce" });

        public static readonly Unit<Mass> Pound = new Unit<Mass>(453.59237,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " lb" }, new string[] { " pounds", " pound" });

        public static readonly Unit<Mass> Stone = new Unit<Mass>(6350.29318,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " st" }, new string[] { " stones", " stone" });

        public static readonly Unit<Mass> Quarter = new Unit<Mass>(12.70058636 * 1000,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " qr", " qtr" }, new string[] { " quarters", " quarter" });

        public static readonly Unit<Mass> HundredWeight = new Unit<Mass>(50.80234544 * 1000,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " cwt" }, new string[] { " hundredweights", " hundredweight" });

        public static readonly Unit<Mass> ImperialTon = new Unit<Mass>(1016.0469088 * 1000,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " LT" }, new string[] { " imperial tons", " imperial ton" });

        public static readonly Unit<Mass> Slug = new Unit<Mass>(14593.90294,
            new UnitGroup[] { UnitGroup.Imperial },
            new string[] { " slug" }, new string[] { " slugs", " slug" });

        #endregion

        /* *********************************************** */

        #region OPERATORS

        public Mass New(double baseVal) { return new Mass(baseVal); }

        public Mass Add(Mass q) { return new Mass(BaseValue + q.BaseValue); }
        public Mass Subtract(Mass q) { return new Mass(BaseValue - q.BaseValue); }

        public Mass Multiply(double n) { return new Mass(BaseValue * n); }
        public Mass Multiply(Mass a, Ratio r) { return a * r.BaseValue; }
        public Mass Multiply(Ratio r, Mass a) { return a * r.BaseValue; }

        public Mass Divide(double n) { return new Mass(BaseValue / n); }
        public Ratio Divide(Mass q) { return new Ratio(BaseValue / q.BaseValue); }

        // these should be defined as convenience, but cannot be forced by interface
        public static Mass Parse(string str, Unit<Mass> defaultUnit = null) { return Unit<Mass>.Parse(str, defaultUnit); }
        public static bool TryParse(string str, out Mass q, Unit<Mass> defaultUnit = null) { return Unit<Mass>.TryParse(str, out q, defaultUnit); }

        public static Mass operator +(Mass a, Mass b) { return a.Add(b); }
        public static Mass operator -(Mass a, Mass b) { return a.Subtract(b); }
        public static Mass operator *(Mass a, double n) { return a.Multiply(n); }
        public static Mass operator /(Mass a, double n) { return a.Divide(n); }
        public static Ratio operator /(Mass a, Mass b) { return a.Divide(b); }
        public static Mass operator -(Mass a) { return a.Multiply(-1); }

        #endregion

        /* *********************************************** */

        #region CONVERSIONS

        // provide various operators to convert between quantities or adjust the quantity

        #endregion

        /* *********************************************** */

        public override string ToString() => this.FormatAuto();
    }
}
