using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elements.Quantity.Test.Quantities.Basic;

using RatioTestData = (Unit<Ratio> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class RatioTests
{
    internal static RatioTestData[] RatioTestDataTuples
    {
        get => new RatioTestData[]
        {
            new (Ratio.RatioValue, "{0}", "1", "{0}"),
            new (Ratio.Percent, "{0} %", "1 percent", "{0} percent")
        };
    }

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
}
