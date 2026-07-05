using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elements.Quantity.Test.Quantities;

[TestClass]
[ExcludeFromCodeCoverage]
public abstract class BaseQuantityTests<TData, TQuantity>
where TData : IQuantityTestData<TQuantity>
where TQuantity : unmanaged, IQuantity<TQuantity>
{
    private static QuantityTestData<TQuantity>[] TestDataTuples => TData.TestDataTuples;

    public static IEnumerable<object[]> PredefinedCompoundFormatInfoArgs =>
        TData.CompoundFormatInfoDataTuples?.Select(row => (object[])[row.Format, row.Value, row.ExpectedStr])
        // No test cases => yield one null entry to prevent MSTest from failing
        ?? [(object?[])[null, 0d, ""]];

    /// <summary>
    /// A collection of test data containing the <typeparamref name="TQuantity"/> unit, the numeric value, and the expected
    /// formatted short name.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    public static IEnumerable<object[]> ShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            TestDataTuples.Select(quantityUnitArgs => new object[] {
                quantityUnitArgs.unit, numValue, string.Format(quantityUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// A collection of test data containing the <typeparamref name="TQuantity"/> unit and the expected formatted long
    /// name for singluar values.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    public static IEnumerable<object[]> LongNameSingularFormArgs
    {
        get => TestDataTuples.Select(quantityUnitArgs => new object[] {
            quantityUnitArgs.unit, quantityUnitArgs.longNameSingle
        });
    }

    /// <summary>
    /// A collection of test data containing the <typeparamref name="TQuantity"/> unit, the numeric value, and the expected
    /// formatted long name for plural values.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    public static IEnumerable<object[]> LongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            TestDataTuples.Select(quantityUnitArgs => new object[] {
                quantityUnitArgs.unit, numValue, string.Format(quantityUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// A collection of test arguments for verifying the unit keys for <typeparamref name="TQuantity"/> units.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    public static IEnumerable<ValueTuple<Unit<TQuantity>, string>> UnitKeyArgs =>
        TestDataTuples.Select(unitArgs => (unitArgs.unit, unitArgs.unitKey));

    /// <summary>
    /// Verifies that formatting a <typeparamref name="TQuantity"/> quantity using the specified unit and the default short name produces the
    /// expected string representation.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the unit's default short name
    /// when formatting a <typeparamref name="TQuantity"/> value. It uses dynamic data to validate multiple unit and string
    /// combinations.
    /// </remarks>
    /// <param name="unit">The quantity unit to use when formatting the value.</param>
    /// <param name="value">The numeric value to be formatted.</param>
    /// <param name="expectedStr">
    /// The expected string result when formatting the <typeparamref name="TQuantity"/> value with
    /// the specified unit's default short name.
    /// </param>
    [TestMethod]
    [DynamicData(nameof(ShortNameArgs))]
    public void QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(
        Unit<TQuantity> unit, double value, string expectedStr)
    {
        var quantity = unit.ConvertFrom(value);
        var resultStr = quantity.FormatAs(unit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that formatting a <typeparamref name="TQuantity"/> value using the specified unit with the long name option produces
    /// the expected singular long name string for singular values.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the singular form of the
    /// unit's long name when formatting <typeparamref name="TQuantity"/> values.
    /// </remarks>
    /// <param name="unit">The quantity unit to use when formatting the value.</param>
    /// <param name="expectedStr">The expected string result when formatting the quantity value with the long name option.</param>
    [TestMethod]
    [DynamicData(nameof(LongNameSingularFormArgs))]
    public void QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(
        Unit<TQuantity> unit, string expectedStr)
    {
        var quantity = unit.ConvertFrom(1d);
        var resultStr = quantity.FormatAs(unit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that formatting a <typeparamref name="TQuantity"/> value using the specified unit with the long name option produces
    /// the expected plural long name string for plural values.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the plural form of the
    /// unit's long name when formatting <typeparamref name="TQuantity"/> values.
    /// </remarks>
    /// <param name="unit">The quantity unit to use when formatting the value.</param>
    /// <param name="value">The numeric value to be formatted.</param>
    /// <param name="expectedStr">The expected string result when formatting the quantity value with the long name option.</param>
    [TestMethod]
    [DynamicData(nameof(LongNamePluralFormArgs))]
    public void QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(
        Unit<TQuantity> unit, double value, string expectedStr)
    {
        var quantity = unit.ConvertFrom(value);
        var resultStr = quantity.FormatAs(unit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that getting a unit key from a <typeparamref name="TQuantity"/> unit will return the expected unit key.
    /// </summary>
    /// <param name="unit">The quantity unit to use when getting the unit key.</param>
    /// <param name="expectedUnitKey">The expected unit key that this unit should return.</param>
    [TestMethod]
    [DynamicData(nameof(UnitKeyArgs))]
    public void GetQuantityUnitKey_ValidUnit_ReturnsUnitKey(Unit<TQuantity> unit, string expectedUnitKey)
    {
        Assert.AreEqual(expectedUnitKey, unit.UnitKey);
    }

    /// <summary>
    /// Test that <typeparamref name="TQuantity"/> is correctly formatted when using <see cref="CompoundFormatInfo{TQuantity}"/>
    /// </summary>
    /// <param name="format">Format Info used</param>
    /// <param name="value">Quantity value in <see cref="TQuantity.DefaultUnit"/> Unit.</param>
    /// <param name="expectedStr">Expected format result</param>
    [TestMethod]
    [DynamicData(nameof(PredefinedCompoundFormatInfoArgs))]
    public void DistanceUnit_PredefinedQuantityCompoundFormatInfo_FormatsQuantityAsString(CompoundFormatInfo<TQuantity>? format, double value, string expectedStr)
    {
        // Skip if no tests are to be run (single null row)
        if (format is null) Assert.Inconclusive();

        var quantity = default(TQuantity).New(value);
        var resultStr = quantity.FormatCompound(format);

        Assert.AreEqual(expectedStr, resultStr);
    }
}
