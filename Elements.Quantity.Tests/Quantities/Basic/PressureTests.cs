using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Elements.Quantity.Test.Quantities.Basic;

using PressureTestData = QuantityTestData<Pressure>;
using PressureUnitKeyTestData = (Unit<Pressure> unit, string unitKey);

[TestClass]
[ExcludeFromCodeCoverage]
public class PressureTests
{
    /// <summary>
    /// An array of test data tuples representing different pressure units and their display formats. Each
    /// element in the array contains information about a pressure unit, the short name, the singular
    /// long name, and plural long name.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static PressureTestData[] PressureTestDataTuples =>
    [
        new (Pressure.Pascal, "{0} Pa", "1 pascal", "{0} pascals", "Quantity.Unit.Pressure.Pascals"),
        new (Pressure.Bar, "{0} bar", "1 bar", "{0} bars", "Quantity.Unit.Pressure.Bars"),
        new (Pressure.Atmosphere, "{0} atm", "1 standard atmosphere", "{0} standard atmospheres", "Quantity.Unit.Pressure.StandardAtmospheres"),
        new (Pressure.Torr, "{0} Torr", "1 torr", "{0} torrs", "Quantity.Unit.Pressure.Torrs"),
        new (Pressure.Millibar, "{0} mbar", "1 millibar", "{0} millibars", "Quantity.Unit.Pressure.Millibars"),
        new (Pressure.PoundPerSquareInch, "{0} psi", "1 pound per square inch", "{0} pounds per square inch", "Quantity.Unit.Pressure.PoundsPerSquareInch"),
        new (SI<Pressure>.Quecto, "{0} qPa", "1 quectopascal", "{0} quectopascals", "Quantity.Unit.Pressure.Quectopascals"),
        new (SI<Pressure>.Ronto, "{0} rPa", "1 rontopascal", "{0} rontopascals", "Quantity.Unit.Pressure.Rontopascals"),
        new (SI<Pressure>.Yocto, "{0} yPa", "1 yoctopascal", "{0} yoctopascals", "Quantity.Unit.Pressure.Yoctopascals"),
        new (SI<Pressure>.Zepto, "{0} zPa", "1 zeptopascal", "{0} zeptopascals", "Quantity.Unit.Pressure.Zeptopascals"),
        new (SI<Pressure>.Atto, "{0} aPa", "1 attopascal", "{0} attopascals", "Quantity.Unit.Pressure.Attopascals"),
        new (SI<Pressure>.Femto, "{0} fPa", "1 femtopascal", "{0} femtopascals", "Quantity.Unit.Pressure.Femtopascals"),
        new (SI<Pressure>.Pico, "{0} pPa", "1 picopascal", "{0} picopascals", "Quantity.Unit.Pressure.Picopascals"),
        new (SI<Pressure>.Nano, "{0} nPa", "1 nanopascal", "{0} nanopascals", "Quantity.Unit.Pressure.Nanopascals"),
        new (SI<Pressure>.Micro, "{0} µPa", "1 micropascal", "{0} micropascals", "Quantity.Unit.Pressure.Micropascals"),
        new (SI<Pressure>.Milli, "{0} mPa", "1 millipascal", "{0} millipascals", "Quantity.Unit.Pressure.Millipascals"),
        new (SI<Pressure>.Centi, "{0} cPa", "1 centipascal", "{0} centipascals", "Quantity.Unit.Pressure.Centipascals"),
        new (SI<Pressure>.Deci, "{0} dPa", "1 decipascal", "{0} decipascals", "Quantity.Unit.Pressure.Decipascals"),
        new (SI<Pressure>.Deca, "{0} daPa", "1 decapascal", "{0} decapascals", "Quantity.Unit.Pressure.Decapascals"),
        new (SI<Pressure>.Hecto, "{0} hPa", "1 hectopascal", "{0} hectopascals", "Quantity.Unit.Pressure.Hectopascals"),
        new (SI<Pressure>.Kilo, "{0} kPa", "1 kilopascal", "{0} kilopascals", "Quantity.Unit.Pressure.Kilopascals"),
        new (SI<Pressure>.Mega, "{0} MPa", "1 megapascal", "{0} megapascals", "Quantity.Unit.Pressure.Megapascals"),
        new (SI<Pressure>.Giga, "{0} GPa", "1 gigapascal", "{0} gigapascals", "Quantity.Unit.Pressure.Gigapascals"),
        new (SI<Pressure>.Tera, "{0} TPa", "1 terapascal", "{0} terapascals", "Quantity.Unit.Pressure.Terapascals"),
        new (SI<Pressure>.Peta, "{0} PPa", "1 petapascal", "{0} petapascals", "Quantity.Unit.Pressure.Petapascals"),
        new (SI<Pressure>.Exa, "{0} EPa", "1 exapascal", "{0} exapascals", "Quantity.Unit.Pressure.Exapascals"),
        new (SI<Pressure>.Zetta, "{0} ZPa", "1 zettapascal", "{0} zettapascals", "Quantity.Unit.Pressure.Zettapascals"),
        new (SI<Pressure>.Yotta, "{0} YPa", "1 yottapascal", "{0} yottapascals", "Quantity.Unit.Pressure.Yottapascals"),
        new (SI<Pressure>.Ronna, "{0} RPa", "1 ronnapascal", "{0} ronnapascals", "Quantity.Unit.Pressure.Ronnapascals"),
        new (SI<Pressure>.Quetta, "{0} QPa", "1 quettapascal", "{0} quettapascals", "Quantity.Unit.Pressure.Quettapascals")
    ];

    /// <summary>
    /// A collection of test data containing the pressure unit, the numeric value, and the expected
    /// formatted short name.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> PressureShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            PressureTestDataTuples.Select(pressureUnitArgs => new object[] {
                pressureUnitArgs.unit, numValue, string.Format(pressureUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// A collection of test data containing the pressure unit and the expected formatted long
    /// name for singluar values.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> PressureLongNameSingularFormArgs
    {
        get => PressureTestDataTuples.Select(pressureUnitArgs => new object[] {
            pressureUnitArgs.unit, pressureUnitArgs.longNameSingle
        });
    }

    /// <summary>
    /// A collection of test data containing the pressure unit, the numeric value, and the expected
    /// formatted long name for plural values.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> PressureLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            PressureTestDataTuples.Select(pressureUnitArgs => new object[] {
                pressureUnitArgs.unit, numValue, string.Format(pressureUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// A collection of test arguments for verifying the unit keys for pressure units.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<PressureUnitKeyTestData> PressureUnitKeyArgs =>
        PressureTestDataTuples.Select(unitArgs => new PressureUnitKeyTestData(unitArgs.unit, unitArgs.unitKey));

    /// <summary>
    /// Verifies that formatting a Pressure quantity using the specified unit and the default short name produces the
    /// expected string representation.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the unit's default short name
    /// when formatting a pressure value. It uses dynamic data to validate multiple unit and string
    /// combinations.
    /// </remarks>
    /// <param name="pressureUnit">The pressure unit to use when formatting the value.</param>
    /// <param name="pressureValue">The numeric value to be formatted.</param>
    /// <param name="expectedStr">The expected string result when formatting the pressure value with the specified unit's default short name.</param>
    [TestMethod]
    [DynamicData(nameof(PressureShortNameArgs))]
    public void PressureUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Pressure> pressureUnit, double pressureValue, string expectedStr)
    {
        var pressure = new Pressure(pressureValue * pressureUnit.Ratio);
        var resultStr = pressure.FormatAs(pressureUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that formatting a pressure value using the specified unit with the long name option produces
    /// the expected singular long name string for singular values.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the singular form of the
    /// unit's long name when formatting pressure values.
    /// </remarks>
    /// <param name="pressureUnit">The pressure unit to use when formatting the value.</param>
    /// <param name="expectedStr">The expected string result when formatting the pressure value with the long name option.</param>
    [TestMethod]
    [DynamicData(nameof(PressureLongNameSingularFormArgs))]
    public void PressureUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Pressure> pressureUnit, string expectedStr)
    {
        var pressure = new Pressure(pressureUnit.Ratio);
        var resultStr = pressure.FormatAs(pressureUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that formatting a pressure value using the specified unit with the long name option produces
    /// the expected plural long name string for plural values.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the  plural form of the
    /// unit's long name when formatting pressure values.
    /// </remarks>
    /// <param name="pressureUnit">The pressure unit to use when formatting the value.</param>
    /// <param name="pressureValue">The numeric value to be formatted.</param>
    /// <param name="expectedStr">The expected string result when formatting the pressure value with the long name option.</param>
    [TestMethod]
    [DynamicData(nameof(PressureLongNamePluralFormArgs))]
    public void PressureUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Pressure> pressureUnit, double pressureValue, string expectedStr)
    {
        var pressure = new Pressure(pressureValue * pressureUnit.Ratio);
        var resultStr = pressure.FormatAs(pressureUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that getting a unit key from an Pressure unit will return the expected unit key.
    /// </summary>
    /// <param name="pressureUnit">The pressure unit to use when getting the unit key.</param>
    /// <param name="expectedUnitKey">The expected unit key that this unit should return.</param>
    [TestMethod]
    [DynamicData(nameof(PressureUnitKeyArgs))]
    public void GetPressureUnitKey_ValidUnit_ReturnsUnitKey(Unit<Pressure> pressureUnit, string expectedUnitKey)
    {
        Assert.AreEqual(expectedUnitKey, pressureUnit.UnitKey);
    }
}
