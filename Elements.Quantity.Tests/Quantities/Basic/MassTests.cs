using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Basic;

using MassTestData = (Unit<Mass> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class MassTests
{
    internal static MassTestData[] MassTestDataTuples
    {
        get => new MassTestData[]
        {
            new (Mass.Gram, "{0} g", "1 gram", "{0} grams"),
            new (Mass.Ton, "{0} t", "1 tonne", "{0} tonnes"),
            new (Mass.Tonne, "{0} t", "1 tonne", "{0} tonnes"),
            new (Mass.Grain, "{0} gr", "1 grain", "{0} grains"),
            new (Mass.Drachm, "{0} dr", "1 drachm", "{0} drachms"),
            new (Mass.Ounce, "{0} oz", "1 ounce", "{0} ounces"),
            new (Mass.Pound, "{0} lb", "1 pound", "{0} pounds"),
            new (Mass.Stone, "{0} st", "1 stone", "{0} stones"),
            new (Mass.Quarter, "{0} qr", "1 quarter", "{0} quarters"),
            new (Mass.HundredWeight, "{0} cwt", "1 hundredweight", "{0} hundredweights"),
            new (Mass.ImperialTon, "{0} LT", "1 imperial ton", "{0} imperial tons"),
            new (Mass.ShortTon, "{0} tn", "1 ton", "{0} tons"),
            new (Mass.Slug, "{0} slug", "1 slug", "{0} slugs"),
            new (SI<Mass>.Kilo, "{0} kg", "1 kilogram", "{0} kilograms"),
            new (SI<Mass>.Milli, "{0} mg", "1 milligram", "{0} milligrams"),
            new (SI<Mass>.Micro, "{0} µg", "1 microgram", "{0} micrograms"),
            new (SI<Mass>.Nano, "{0} ng", "1 nanogram", "{0} nanograms"),
            new (SI<Mass>.Pico, "{0} pg", "1 picogram", "{0} picograms"),
        };
    }

    internal static IEnumerable<object[]> MassShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            MassTestDataTuples.Select(massUnitArgs => new object[] {
                massUnitArgs.unit, numValue, string.Format(massUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> MassLongNameSingularFormArgs
    {
        get => MassTestDataTuples.Select(massUnitArgs => new object[] {
            massUnitArgs.unit, massUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> MassLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            MassTestDataTuples.Select(massUnitArgs => new object[] {
                massUnitArgs.unit, numValue, string.Format(massUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    [TestMethod]
    [DynamicData(nameof(MassShortNameArgs))]
    public void MassUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Mass> massUnit, double massValue, string expectedStr)
    {
        var mass = new Mass(massValue * massUnit.Ratio);
        var resultStr = mass.FormatAs(massUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(MassLongNameSingularFormArgs))]
    public void MassUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Mass> massUnit, string expectedStr)
    {
        var mass = new Mass(massUnit.Ratio);
        var resultStr = mass.FormatAs(massUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(MassLongNamePluralFormArgs))]
    public void MassUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Mass> massUnit, double massValue, string expectedStr)
    {
        var mass = new Mass(massValue * massUnit.Ratio);
        var resultStr = mass.FormatAs(massUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }
}
