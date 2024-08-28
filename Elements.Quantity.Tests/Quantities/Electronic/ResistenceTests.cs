using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Electronic;

using ResistanceTestData = (Unit<Resistance> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class ResistanceTests
{
    internal static ResistanceTestData[] ResistanceTestDataTuples
    {
        get => new ResistanceTestData[]
        {
            new (Resistance.Ohm, "{0} Ω", "1 ohm", "{0} ohms"),
            new (SI<Resistance>.Quecto, "{0} qΩ", "1 quectoohm", "{0} quectoohms"),
            new (SI<Resistance>.Ronto, "{0} rΩ", "1 rontoohm", "{0} rontoohms"),
            new (SI<Resistance>.Yocto, "{0} yΩ", "1 yoctoohm", "{0} yoctoohms"),
            new (SI<Resistance>.Zepto, "{0} zΩ", "1 zeptoohm", "{0} zeptoohms"),
            new (SI<Resistance>.Atto, "{0} aΩ", "1 attoohm", "{0} attoohms"),
            new (SI<Resistance>.Femto, "{0} fΩ", "1 femtoohm", "{0} femtoohms"),
            new (SI<Resistance>.Pico, "{0} pΩ", "1 picoohm", "{0} picoohms"),
            new (SI<Resistance>.Nano, "{0} nΩ", "1 nanoohm", "{0} nanoohms"),
            new (SI<Resistance>.Micro, "{0} µΩ", "1 microohm", "{0} microohms"),
            new (SI<Resistance>.Milli, "{0} mΩ", "1 milliohm", "{0} milliohms"),
            new (SI<Resistance>.Kilo, "{0} kΩ", "1 kiloohm", "{0} kiloohms"),
            new (SI<Resistance>.Mega, "{0} MΩ", "1 megaohm", "{0} megaohms"),
            new (SI<Resistance>.Giga, "{0} GΩ", "1 gigaohm", "{0} gigaohms"),
            new (SI<Resistance>.Tera, "{0} TΩ", "1 teraohm", "{0} teraohms"),
            new (SI<Resistance>.Peta, "{0} PΩ", "1 petaohm", "{0} petaohms"),
            new (SI<Resistance>.Exa, "{0} EΩ", "1 exaohm", "{0} exaohms"),
            new (SI<Resistance>.Zetta, "{0} ZΩ", "1 zettaohm", "{0} zettaohms"),
            new (SI<Resistance>.Yotta, "{0} YΩ", "1 yottaohm", "{0} yottaohms"),
            new (SI<Resistance>.Ronna, "{0} RΩ", "1 ronnaohm", "{0} ronnaohms"),
            new (SI<Resistance>.Quetta, "{0} QΩ", "1 quettaohm", "{0} quettaohms")
        };
    }

    internal static IEnumerable<object[]> ResistanceShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            ResistanceTestDataTuples.Select(resistanceUnitArgs => new object[] {
                resistanceUnitArgs.unit, numValue, string.Format(resistanceUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> ResistanceLongNameSingularFormArgs
    {
        get => ResistanceTestDataTuples.Select(resistanceUnitArgs => new object[] {
            resistanceUnitArgs.unit, resistanceUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> ResistanceLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            ResistanceTestDataTuples.Select(resistanceUnitArgs => new object[] {
                resistanceUnitArgs.unit, numValue, string.Format(resistanceUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    [TestMethod]
    [DynamicData(nameof(ResistanceShortNameArgs))]
    public void ResistanceUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Resistance> resistanceUnit, double resistanceValue, string expectedStr)
    {
        var resistance = new Resistance(resistanceValue * resistanceUnit.Ratio);
        var resultStr = resistance.FormatAs(resistanceUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(ResistanceLongNameSingularFormArgs))]
    public void ResistanceUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Resistance> resistanceUnit, string expectedStr)
    {
        var resistance = new Resistance(resistanceUnit.Ratio);
        var resultStr = resistance.FormatAs(resistanceUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(ResistanceLongNamePluralFormArgs))]
    public void ResistanceUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Resistance> resistanceUnit, double resistanceValue, string expectedStr)
    {
        var resistance = new Resistance(resistanceValue * resistanceUnit.Ratio);
        var resultStr = resistance.FormatAs(resistanceUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }
}
