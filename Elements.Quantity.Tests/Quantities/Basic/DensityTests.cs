using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Elements.Quantity.Test.Quantities.Basic;

using DensityTestData = (Unit<Density> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class DensityTests
{
    /// <summary>
    /// An array of test data tuples representing different density units and their display formats. Each
    /// element in the array contains information about a density unit, the short name, the singular
    /// long name, and plural long name.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static DensityTestData[] DensityTestDataTuples
    {
        get =>
        [
            new (Density.KilogramPerCubicMeter, "{0} kg/m³", "1 kilogram per cubic meter", "{0} kilograms per cubic meter"),
            new (Density.GramPerCubicCentimeter, "{0} g/cm³", "1 gram per cubic centimeter", "{0} grams per cubic centimeter"),
            new (Density.PoundPerCubicFoot, "{0} lb/ft³", "1 pound per cubic foot", "{0} pounds per cubic foot")
        ];
    }

    /// <summary>
    /// A collection of test data containing the density unit, the numeric value, and the expected
    /// formatted short name.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> DensityShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            DensityTestDataTuples.Select(densityUnitArgs => new object[] {
                densityUnitArgs.unit, numValue, string.Format(densityUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// A collection of test data containing the density unit and the expected formatted long
    /// name for singluar values.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> DensityLongNameSingularFormArgs
    {
        get => DensityTestDataTuples.Select(densityUnitArgs => new object[] {
            densityUnitArgs.unit, densityUnitArgs.longNameSingle
        });
    }

    /// <summary>
    /// A collection of test data containing the density unit, the numeric value, and the expected
    /// formatted long name for plural values.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> DensityLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            DensityTestDataTuples.Select(densityUnitArgs => new object[] {
                densityUnitArgs.unit, numValue, string.Format(densityUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// Verifies that formatting a Density quantity using the specified unit and the default short name produces the
    /// expected string representation.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the unit's default short name
    /// when formatting a density value. It uses dynamic data to validate multiple unit and string
    /// combinations.
    /// </remarks>
    /// <param name="densityUnit">The density unit to use when formatting the value.</param>
    /// <param name="densityValue">The numeric value to be formatted.</param>
    /// <param name="expectedStr">The expected string result when formatting the density value with the specified unit's default short name.</param>
    [TestMethod]
    [DynamicData(nameof(DensityShortNameArgs))]
    public void DensityUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Density> densityUnit, double densityValue, string expectedStr)
    {
        var density = new Density(densityValue * densityUnit.Ratio);
        var resultStr = density.FormatAs(densityUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that formatting a density value using the specified unit with the long name option produces
    /// the expected singular long name string for singular values.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the singular form of the
    /// unit's long name when formatting density values.
    /// </remarks>
    /// <param name="densityUnit">The density unit to use when formatting the value.</param>
    /// <param name="expectedStr">The expected string result when formatting the density value with the long name option.</param>
    [TestMethod]
    [DynamicData(nameof(DensityLongNameSingularFormArgs))]
    public void DensityUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Density> densityUnit, string expectedStr)
    {
        var density = new Density(densityUnit.Ratio);
        var resultStr = density.FormatAs(densityUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that formatting a density value using the specified unit with the long name option produces
    /// the expected plural long name string for plural values.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the  plural form of the
    /// unit's long name when formatting density values.
    /// </remarks>
    /// <param name="densityUnit">The density unit to use when formatting the value.</param>
    /// <param name="densityValue">The numeric value to be formatted.</param>
    /// <param name="expectedStr">The expected string result when formatting the density value with the long name option.</param>
    [TestMethod]
    [DynamicData(nameof(DensityLongNamePluralFormArgs))]
    public void DensityUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Density> densityUnit, double densityValue, string expectedStr)
    {
        var density = new Density(densityValue * densityUnit.Ratio);
        var resultStr = density.FormatAs(densityUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }
}
