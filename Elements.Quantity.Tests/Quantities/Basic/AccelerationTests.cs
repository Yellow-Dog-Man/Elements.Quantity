using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elements.Quantity.Test.Quantities.Basic;

using AccelerationTestData = QuantityTestData<Acceleration>;
using AccelerationUnitKeyTestData = (Unit<Acceleration> unit, string unitKey);

[TestClass]
[ExcludeFromCodeCoverage]
public class AccelerationTests
{
    /// <summary>
    /// An array of test data tuples representing different acceleration units and their display formats. Each
    /// element in the array contains information about a acceleration unit, the short name, the singular
    /// long name, plural long name, and unit key.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static AccelerationTestData[] AccelerationTestDataTuples =>
    [
        new (Acceleration.MetersPerSecondPerSecond, "{0} m/s^2", "1 meter per second squared", "{0} meters per second squared", "Quantity.Unit.Acceleration.MetersPerSecondSquared")
    ];

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

    /// <summary>
    /// A collection of test arguments for verifying the unit keys for acceleration units.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<AccelerationUnitKeyTestData> AccelerationUnitKeyArgs =>
        AccelerationTestDataTuples.Select(unitArgs => new AccelerationUnitKeyTestData(unitArgs.unit, unitArgs.unitKey));

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

    /// <summary>
    /// Verifies that getting a unit key from an Acceleration unit will return the expected unit key.
    /// </summary>
    /// <param name="accelerationUnit">The acceleration unit to use when getting the unit key.</param>
    /// <param name="expectedUnitKey">The expected unit key that this unit should return.</param>
    [TestMethod]
    [DynamicData(nameof(AccelerationUnitKeyArgs))]
    public void GetAccelerationUnitKey_ValidUnit_ReturnsUnitKey(Unit<Acceleration> accelerationUnit, string expectedUnitKey)
    {
        Assert.AreEqual(expectedUnitKey, accelerationUnit.UnitKey);
    }
}
