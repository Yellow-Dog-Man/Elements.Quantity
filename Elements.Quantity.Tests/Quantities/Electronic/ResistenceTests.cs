using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Electronic;

using ResistanceTestData = QuantityTestData<Resistance>;
using ResistanceUnitKeyTestData = (Unit<Resistance> unit, string unitKey);

[TestClass]
[ExcludeFromCodeCoverage]
public class ResistanceTests
{
    /// <summary>
    /// An array of test data tuples representing different resistance units and their display formats. Each
    /// element in the array contains information about a resistance unit, the short name, the singular
    /// long name, plural long name, and unit key.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static ResistanceTestData[] ResistanceTestDataTuples =>
    [
        new (Resistance.Ohm, "{0} Ω", "1 ohm", "{0} ohms", "Quantity.Unit.Electronic.Resistance.Ohms"),
        new (SI<Resistance>.Quecto, "{0} qΩ", "1 quectoohm", "{0} quectoohms", "Quantity.Unit.Electronic.Resistance.Quectoohms"),
        new (SI<Resistance>.Ronto, "{0} rΩ", "1 rontoohm", "{0} rontoohms", "Quantity.Unit.Electronic.Resistance.Rontoohms"),
        new (SI<Resistance>.Yocto, "{0} yΩ", "1 yoctoohm", "{0} yoctoohms", "Quantity.Unit.Electronic.Resistance.Yoctoohms"),
        new (SI<Resistance>.Zepto, "{0} zΩ", "1 zeptoohm", "{0} zeptoohms", "Quantity.Unit.Electronic.Resistance.Zeptoohms"),
        new (SI<Resistance>.Atto, "{0} aΩ", "1 attoohm", "{0} attoohms", "Quantity.Unit.Electronic.Resistance.Attoohms"),
        new (SI<Resistance>.Femto, "{0} fΩ", "1 femtoohm", "{0} femtoohms", "Quantity.Unit.Electronic.Resistance.Femtoohms"),
        new (SI<Resistance>.Pico, "{0} pΩ", "1 picoohm", "{0} picoohms", "Quantity.Unit.Electronic.Resistance.Picoohms"),
        new (SI<Resistance>.Nano, "{0} nΩ", "1 nanoohm", "{0} nanoohms", "Quantity.Unit.Electronic.Resistance.Nanoohms"),
        new (SI<Resistance>.Micro, "{0} µΩ", "1 microohm", "{0} microohms", "Quantity.Unit.Electronic.Resistance.Microohms"),
        new (SI<Resistance>.Centi, "{0} cΩ", "1 centiohm", "{0} centiohms", "Quantity.Unit.Electronic.Resistance.Centiohms"),
        new (SI<Resistance>.Deci, "{0} dΩ", "1 deciohm", "{0} deciohms", "Quantity.Unit.Electronic.Resistance.Deciohms"),
        new (SI<Resistance>.Deca, "{0} daΩ", "1 decaohm", "{0} decaohms", "Quantity.Unit.Electronic.Resistance.Decaohms"),
        new (SI<Resistance>.Hecto, "{0} hΩ", "1 hectoohm", "{0} hectoohms", "Quantity.Unit.Electronic.Resistance.Hectoohms"),
        new (SI<Resistance>.Milli, "{0} mΩ", "1 milliohm", "{0} milliohms", "Quantity.Unit.Electronic.Resistance.Milliohms"),
        new (SI<Resistance>.Kilo, "{0} kΩ", "1 kiloohm", "{0} kiloohms", "Quantity.Unit.Electronic.Resistance.Kiloohms"),
        new (SI<Resistance>.Mega, "{0} MΩ", "1 megaohm", "{0} megaohms", "Quantity.Unit.Electronic.Resistance.Megaohms"),
        new (SI<Resistance>.Giga, "{0} GΩ", "1 gigaohm", "{0} gigaohms", "Quantity.Unit.Electronic.Resistance.Gigaohms"),
        new (SI<Resistance>.Tera, "{0} TΩ", "1 teraohm", "{0} teraohms", "Quantity.Unit.Electronic.Resistance.Teraohms"),
        new (SI<Resistance>.Peta, "{0} PΩ", "1 petaohm", "{0} petaohms", "Quantity.Unit.Electronic.Resistance.Petaohms"),
        new (SI<Resistance>.Exa, "{0} EΩ", "1 exaohm", "{0} exaohms", "Quantity.Unit.Electronic.Resistance.Exaohms"),
        new (SI<Resistance>.Zetta, "{0} ZΩ", "1 zettaohm", "{0} zettaohms", "Quantity.Unit.Electronic.Resistance.Zettaohms"),
        new (SI<Resistance>.Yotta, "{0} YΩ", "1 yottaohm", "{0} yottaohms", "Quantity.Unit.Electronic.Resistance.Yottaohms"),
        new (SI<Resistance>.Ronna, "{0} RΩ", "1 ronnaohm", "{0} ronnaohms", "Quantity.Unit.Electronic.Resistance.Ronnaohms"),
        new (SI<Resistance>.Quetta, "{0} QΩ", "1 quettaohm", "{0} quettaohms", "Quantity.Unit.Electronic.Resistance.Quettaohms")
    ];

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

    /// <summary>
    /// A collection of test arguments for verifying the unit keys for resistance units.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<ResistanceUnitKeyTestData> ResistanceUnitKeyArgs =>
        ResistanceTestDataTuples.Select(unitArgs => new ResistanceUnitKeyTestData(unitArgs.unit, unitArgs.unitKey));

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

    /// <summary>
    /// Verifies that getting a unit key from an Resistance unit will return the expected unit key.
    /// </summary>
    /// <param name="resistanceUnit">The resistance unit to use when getting the unit key.</param>
    /// <param name="expectedUnitKey">The expected unit key that this unit should return.</param>
    [TestMethod]
    [DynamicData(nameof(ResistanceUnitKeyArgs))]
    public void GetResistanceUnitKey_ValidUnit_ReturnsUnitKey(Unit<Resistance> resistanceUnit, string expectedUnitKey)
    {
        Assert.AreEqual(expectedUnitKey, resistanceUnit.UnitKey);
    }
}
