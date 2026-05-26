using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Basic;

using VelocityTestData = QuantityTestData<Velocity>;
using VelocityUnitKeyTestData = (Unit<Velocity> unit, string unitKey);

[TestClass]
[ExcludeFromCodeCoverage]
public class VelocityTests
{
    /// <summary>
    /// An array of test data tuples representing different velocity units and their display formats. Each
    /// element in the array contains information about a velocity unit, the short name, the singular
    /// long name, plural long name, and unit key.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static VelocityTestData[] VelocityTestDataTuples =>
    [
        new (Velocity.MetersPerSecond, "{0} m/s", "1 meter per second", "{0} meters per second", "Quantity.Unit.Velocity.MetersPerSecond"),
        new (Velocity.KilometersPerHour, "{0} km/h", "1 kilometer per hour", "{0} kilometers per hour", "Quantity.Unit.Velocity.KilometersPerHour"),
        new (Velocity.MilesPerHour, "{0} mph", "1 mile per hour", "{0} miles per hour", "Quantity.Unit.Velocity.MilesPerHour"),
        new (Velocity.FeetPerSecond, "{0} ft/s", "1 foot per second", "{0} feet per second", "Quantity.Unit.Velocity.FeetPerSecond"),
        new (Velocity.Knots, "{0} kn", "1 knot", "{0} knots", "Quantity.Unit.Velocity.Knots")
    ];

    internal static IEnumerable<object[]> VelocityShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            VelocityTestDataTuples.Select(velocityUnitArgs => new object[] {
                velocityUnitArgs.unit, numValue, string.Format(velocityUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> VelocityLongNameSingularFormArgs
    {
        get => VelocityTestDataTuples.Select(velocityUnitArgs => new object[] {
            velocityUnitArgs.unit, velocityUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> VelocityLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            VelocityTestDataTuples.Select(velocityUnitArgs => new object[] {
                velocityUnitArgs.unit, numValue, string.Format(velocityUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// A collection of test arguments for verifying the unit keys for velocity units.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<VelocityUnitKeyTestData> VelocityUnitKeyArgs =>
        VelocityTestDataTuples.Select(unitArgs => new VelocityUnitKeyTestData(unitArgs.unit, unitArgs.unitKey));

    [TestMethod]
    [DynamicData(nameof(VelocityShortNameArgs))]
    public void VelocityUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Velocity> velocityUnit, double velocityValue, string expectedStr)
    {
        var velocity = new Velocity(velocityValue * velocityUnit.Ratio);
        var resultStr = velocity.FormatAs(velocityUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(VelocityLongNameSingularFormArgs))]
    public void VelocityUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Velocity> velocityUnit, string expectedStr)
    {
        var velocity = new Velocity(velocityUnit.Ratio);
        var resultStr = velocity.FormatAs(velocityUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(VelocityLongNamePluralFormArgs))]
    public void VelocityUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Velocity> velocityUnit, double velocityValue, string expectedStr)
    {
        var velocity = new Velocity(velocityValue * velocityUnit.Ratio);
        var resultStr = velocity.FormatAs(velocityUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that getting a unit key from an Velocity unit will return the expected unit key.
    /// </summary>
    /// <param name="velocityUnit">The velocity unit to use when getting the unit key.</param>
    /// <param name="expectedUnitKey">The expected unit key that this unit should return.</param>
    [TestMethod]
    [DynamicData(nameof(VelocityUnitKeyArgs))]
    public void GetVelocityUnitKey_ValidUnit_ReturnsUnitKey(Unit<Velocity> velocityUnit, string expectedUnitKey)
    {
        Assert.AreEqual(expectedUnitKey, velocityUnit.UnitKey);
    }
}
