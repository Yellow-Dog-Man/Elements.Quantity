using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Elements.Quantity.Test.Quantities.Basic;

using LuminanceTestData = (Unit<Luminance> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class LuminanceTests
{
    /// <summary>
    /// An array of test data tuples representing different luminance units and their display formats. Each
    /// element in the array contains information about a luminance unit, the short name, the singular
    /// long name, and plural long name.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static LuminanceTestData[] LuminanceTestDataTuples
    {
        get =>
        [
            new (Luminance.CandelaPerSquareMeter, "{0} cd/m²", "1 candela per square meter", "{0} candelas per square meter"),
            new (Luminance.Nit, "{0} nt", "1 nit", "{0} nits")
        ];
    }

    /// <summary>
    /// A collection of test data containing the luminance unit, the numeric value, and the expected
    /// formatted short name.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> LuminanceShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            LuminanceTestDataTuples.Select(luminanceUnitArgs => new object[] {
                luminanceUnitArgs.unit, numValue, string.Format(luminanceUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// A collection of test data containing the luminance unit and the expected formatted long
    /// name for singluar values.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> LuminanceLongNameSingularFormArgs
    {
        get => LuminanceTestDataTuples.Select(luminanceUnitArgs => new object[] {
            luminanceUnitArgs.unit, luminanceUnitArgs.longNameSingle
        });
    }

    /// <summary>
    /// A collection of test data containing the luminance unit, the numeric value, and the expected
    /// formatted long name for plural values.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> LuminanceLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            LuminanceTestDataTuples.Select(luminanceUnitArgs => new object[] {
                luminanceUnitArgs.unit, numValue, string.Format(luminanceUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// Verifies that formatting a Luminance quantity using the specified unit and the default short name produces the
    /// expected string representation.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the unit's default short name
    /// when formatting a luminance value. It uses dynamic data to validate multiple unit and string
    /// combinations.
    /// </remarks>
    /// <param name="luminanceUnit">The luminance unit to use when formatting the value.</param>
    /// <param name="luminanceValue">The numeric value to be formatted.</param>
    /// <param name="expectedStr">The expected string result when formatting the luminance value with the specified unit's default short name.</param>
    [TestMethod]
    [DynamicData(nameof(LuminanceShortNameArgs))]
    public void LuminanceUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Luminance> luminanceUnit, double luminanceValue, string expectedStr)
    {
        var luminance = new Luminance(luminanceValue * luminanceUnit.Ratio);
        var resultStr = luminance.FormatAs(luminanceUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that formatting a luminance value using the specified unit with the long name option produces
    /// the expected singular long name string for singular values.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the singular form of the
    /// unit's long name when formatting luminance values.
    /// </remarks>
    /// <param name="luminanceUnit">The luminance unit to use when formatting the value.</param>
    /// <param name="expectedStr">The expected string result when formatting the luminance value with the long name option.</param>
    [TestMethod]
    [DynamicData(nameof(LuminanceLongNameSingularFormArgs))]
    public void LuminanceUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Luminance> luminanceUnit, string expectedStr)
    {
        var luminance = new Luminance(luminanceUnit.Ratio);
        var resultStr = luminance.FormatAs(luminanceUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that formatting a luminance value using the specified unit with the long name option produces
    /// the expected plural long name string for plural values.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the  plural form of the
    /// unit's long name when formatting luminance values.
    /// </remarks>
    /// <param name="luminanceUnit">The luminance unit to use when formatting the value.</param>
    /// <param name="luminanceValue">The numeric value to be formatted.</param>
    /// <param name="expectedStr">The expected string result when formatting the luminance value with the long name option.</param>
    [TestMethod]
    [DynamicData(nameof(LuminanceLongNamePluralFormArgs))]
    public void LuminanceUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Luminance> luminanceUnit, double luminanceValue, string expectedStr)
    {
        var luminance = new Luminance(luminanceValue * luminanceUnit.Ratio);
        var resultStr = luminance.FormatAs(luminanceUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }
}
