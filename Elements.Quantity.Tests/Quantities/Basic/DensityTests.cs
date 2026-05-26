using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Elements.Quantity.Test.Quantities.Basic;

using DensityTestData = QuantityTestData<Density>;
using DensityUnitKeyTestData = (Unit<Density> unit, string unitKey);

[TestClass]
[ExcludeFromCodeCoverage]
public class DensityTests
{
    /// <summary>
    /// An array of test data tuples representing different density units and their display formats. Each
    /// element in the array contains information about a density unit, the short name, the singular
    /// long name, plural long name, and unit key.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static DensityTestData[] DensityTestDataTuples =>
    [
        new (Density.KilogramPerCubicMeter, "{0} kg/m³", "1 kilogram per cubic meter", "{0} kilograms per cubic meter", "Quantity.Unit.Density.KilogramsPerCubicMeter"),
        new (Density.GramPerCubicCentimeter, "{0} g/cm³", "1 gram per cubic centimeter", "{0} grams per cubic centimeter", "Quantity.Unit.Density.GramsPerCubicCentimeter"),
        new (Density.PoundPerCubicFoot, "{0} lb/ft³", "1 pound per cubic foot", "{0} pounds per cubic foot", "Quantity.Unit.Density.PoundsPerCubicFoot")
    ];

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
    /// A collection of test arguments for verifying the unit keys for density units.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<DensityUnitKeyTestData> DensityUnitKeyArgs =>
        DensityTestDataTuples.Select(unitArgs => new DensityUnitKeyTestData(unitArgs.unit, unitArgs.unitKey));

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

    /// <summary>
    /// Verifies that getting a unit key from an Density unit will return the expected unit key.
    /// </summary>
    /// <param name="densityUnit">The density unit to use when getting the unit key.</param>
    /// <param name="expectedUnitKey">The expected unit key that this unit should return.</param>
    [TestMethod]
    [DynamicData(nameof(DensityUnitKeyArgs))]
    public void GetDensityUnitKey_ValidUnit_ReturnsUnitKey(Unit<Density> densityUnit, string expectedUnitKey)
    {
        Assert.AreEqual(expectedUnitKey, densityUnit.UnitKey);
    }
}
