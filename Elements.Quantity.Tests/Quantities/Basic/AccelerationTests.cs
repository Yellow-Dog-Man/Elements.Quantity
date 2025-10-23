using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elements.Quantity.Test.Quantities.Basic;

using AccelerationTestData = (Unit<Acceleration> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class AccelerationTests
{
    internal static AccelerationTestData[] AccelerationTestDataTuples
    {
        get => new AccelerationTestData[]
        {
            new (Acceleration.MetersPerSecondPerSecond, "{0} m/s^2", "1 meter per second squared", "{0} meters per second squared")
        };
    }

    internal static IEnumerable<object[]> AccelerationShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            AccelerationTestDataTuples.Select(accelerationUnitArgs => new object[] {
                accelerationUnitArgs.unit, numValue, string.Format(accelerationUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> AccelerationLongNameSingularFormArgs
    {
        get => AccelerationTestDataTuples.Select(accelerationUnitArgs => new object[] {
            accelerationUnitArgs.unit, accelerationUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> AccelerationLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            AccelerationTestDataTuples.Select(accelerationUnitArgs => new object[] {
                accelerationUnitArgs.unit, numValue, string.Format(accelerationUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    [TestMethod]
    [DynamicData(nameof(AccelerationShortNameArgs))]
    public void AccelerationUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Acceleration> accelerationUnit, double accelerationValue, string expectedStr)
    {
        var acceleration = new Acceleration(accelerationValue * accelerationUnit.Ratio);
        var resultStr = acceleration.FormatAs(accelerationUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(AccelerationLongNameSingularFormArgs))]
    public void AccelerationUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Acceleration> accelerationUnit, string expectedStr)
    {
        var acceleration = new Acceleration(accelerationUnit.Ratio);
        var resultStr = acceleration.FormatAs(accelerationUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(AccelerationLongNamePluralFormArgs))]
    public void AccelerationUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Acceleration> accelerationUnit, double accelerationValue, string expectedStr)
    {
        var acceleration = new Acceleration(accelerationValue * accelerationUnit.Ratio);
        var resultStr = acceleration.FormatAs(accelerationUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }
}
