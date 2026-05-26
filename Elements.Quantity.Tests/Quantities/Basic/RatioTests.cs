using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Elements.Quantity.Test.Quantities.Basic;

using RatioTestData = QuantityTestData<Ratio>;
using RatioUnitKeyTestData = (Unit<Ratio> unit, string unitKey);

[TestClass]
[ExcludeFromCodeCoverage]
public class RatioTests
{
    /// <summary>
    /// An array of test data tuples representing different ratio units and their display formats. Each
    /// element in the array contains information about a ratio unit, the short name, the singular
    /// long name, plural long name, and unit key.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static RatioTestData[] RatioTestDataTuples =>
    [
        new (Ratio.RatioValue, "{0}", "1", "{0}", "Quantity.Unit.Ratio"),
        new (Ratio.Percent, "{0} %", "1 percent", "{0} percent", "Quantity.Unit.Ratio.Percent")
    ];

    internal static IEnumerable<object[]> RatioShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            RatioTestDataTuples.Select(ratioUnitArgs => new object[] {
                ratioUnitArgs.unit, numValue, string.Format(ratioUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> RatioLongNameSingularFormArgs
    {
        get => RatioTestDataTuples.Select(ratioUnitArgs => new object[] {
            ratioUnitArgs.unit, ratioUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> RatioLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            RatioTestDataTuples.Select(ratioUnitArgs => new object[] {
                ratioUnitArgs.unit, numValue, string.Format(ratioUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// A collection of test arguments for verifying the unit keys for ratio units.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<RatioUnitKeyTestData> RatioUnitKeyArgs =>
        RatioTestDataTuples.Select(unitArgs => new RatioUnitKeyTestData(unitArgs.unit, unitArgs.unitKey));

    [TestMethod]
    [DynamicData(nameof(RatioShortNameArgs))]
    public void RatioUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Ratio> ratioUnit, double ratioValue, string expectedStr)
    {
        var ratio = new Ratio(ratioValue * ratioUnit.Ratio);
        var resultStr = ratio.FormatAs(ratioUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(RatioLongNameSingularFormArgs))]
    public void RatioUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Ratio> ratioUnit, string expectedStr)
    {
        var ratio = new Ratio(ratioUnit.Ratio);
        var resultStr = ratio.FormatAs(ratioUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(RatioLongNamePluralFormArgs))]
    public void RatioUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Ratio> ratioUnit, double ratioValue, string expectedStr)
    {
        var ratio = new Ratio(ratioValue * ratioUnit.Ratio);
        var resultStr = ratio.FormatAs(ratioUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that getting a unit key from an Ratio unit will return the expected unit key.
    /// </summary>
    /// <param name="ratioUnit">The ratio unit to use when getting the unit key.</param>
    /// <param name="expectedUnitKey">The expected unit key that this unit should return.</param>
    [TestMethod]
    [DynamicData(nameof(RatioUnitKeyArgs))]
    public void GetRatioUnitKey_ValidUnit_ReturnsUnitKey(Unit<Ratio> ratioUnit, string expectedUnitKey)
    {
        Assert.AreEqual(expectedUnitKey, ratioUnit.UnitKey);
    }
}
