using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Elements.Quantity.Test.Quantities.Basic;

using PressureTestData = (Unit<Pressure> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
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
    internal static PressureTestData[] PressureTestDataTuples
    {
        get =>
        [
            new (Pressure.Pascal, "{0} Pa", "1 pascal", "{0} pascals"),
            new (Pressure.Bar, "{0} bar", "1 bar", "{0} bars"),
            new (Pressure.Atmosphere, "{0} atm", "1 standard atmosphere", "{0} standard atmospheres"),
            new (Pressure.Torr, "{0} Torr", "1 torr", "{0} torrs"),
            new (Pressure.Millibar, "{0} mbar", "1 millibar", "{0} millibars"),
            new (Pressure.PoundPerSquareInch, "{0} psi", "1 pound per square inch", "{0} pounds per square inch"),
            new (SI<Pressure>.Quecto, "{0} qPa", "1 quectopascal", "{0} quectopascals"),
            new (SI<Pressure>.Ronto, "{0} rPa", "1 rontopascal", "{0} rontopascals"),
            new (SI<Pressure>.Yocto, "{0} yPa", "1 yoctopascal", "{0} yoctopascals"),
            new (SI<Pressure>.Zepto, "{0} zPa", "1 zeptopascal", "{0} zeptopascals"),
            new (SI<Pressure>.Atto, "{0} aPa", "1 attopascal", "{0} attopascals"),
            new (SI<Pressure>.Femto, "{0} fPa", "1 femtopascal", "{0} femtopascals"),
            new (SI<Pressure>.Pico, "{0} pPa", "1 picopascal", "{0} picopascals"),
            new (SI<Pressure>.Nano, "{0} nPa", "1 nanopascal", "{0} nanopascals"),
            new (SI<Pressure>.Micro, "{0} µPa", "1 micropascal", "{0} micropascals"),
            new (SI<Pressure>.Milli, "{0} mPa", "1 millipascal", "{0} millipascals"),
            new (SI<Pressure>.Centi, "{0} cPa", "1 centipascal", "{0} centipascals"),
            new (SI<Pressure>.Deci, "{0} dPa", "1 decipascal", "{0} decipascals"),
            new (SI<Pressure>.Deca, "{0} daPa", "1 decapascal", "{0} decapascals"),
            new (SI<Pressure>.Hecto, "{0} hPa", "1 hectopascal", "{0} hectopascals"),
            new (SI<Pressure>.Kilo, "{0} kPa", "1 kilopascal", "{0} kilopascals"),
            new (SI<Pressure>.Mega, "{0} MPa", "1 megapascal", "{0} megapascals"),
            new (SI<Pressure>.Giga, "{0} GPa", "1 gigapascal", "{0} gigapascals"),
            new (SI<Pressure>.Tera, "{0} TPa", "1 terapascal", "{0} terapascals"),
            new (SI<Pressure>.Peta, "{0} PPa", "1 petapascal", "{0} petapascals"),
            new (SI<Pressure>.Exa, "{0} EPa", "1 exapascal", "{0} exapascals"),
            new (SI<Pressure>.Zetta, "{0} ZPa", "1 zettapascal", "{0} zettapascals"),
            new (SI<Pressure>.Yotta, "{0} YPa", "1 yottapascal", "{0} yottapascals"),
            new (SI<Pressure>.Ronna, "{0} RPa", "1 ronnapascal", "{0} ronnapascals"),
            new (SI<Pressure>.Quetta, "{0} QPa", "1 quettapascal", "{0} quettapascals")
        ];
    }

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
}
