using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Basic;

using VelocityTestData = (Unit<Velocity> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class VelocityTests
{
    internal static VelocityTestData[] VelocityTestDataTuples
    {
        get => new VelocityTestData[]
        {
            new (Velocity.MetersPerSecond, "{0} m/s", "1 meter per second", "{0} meters per second"),
            new (Velocity.KilometersPerHour, "{0} km/h", "1 kilometer per hour", "{0} kilometers per hour"),
            new (Velocity.MilesPerHour, "{0} mph", "1 mile per hour", "{0} miles per hour"),
            new (Velocity.FeetPerSecond, "{0} ft/s", "1 foot per second", "{0} feet per second"),
            new (Velocity.Knots, "{0} kn", "1 knot", "{0} knots")
        };
    }

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
}
