using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Basic;

using DistanceTestData = QuantityTestData<Distance>;
using DistanceUnitKeyTestData = (Unit<Distance> unit, string unitKey);

[TestClass]
[ExcludeFromCodeCoverage]
public class DistanceTests
{
    /// <summary>
    /// An array of test data tuples representing different distance units and their display formats. Each
    /// element in the array contains information about a distance unit, the short name, the singular
    /// long name, plural long name, and unit key.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static DistanceTestData[] DistanceTestDataTuples =>
    [
        new (Distance.AU, "{0} AU", "1 Astronomical Unit", "{0} Astronomical Units", "Quantity.Unit.Distance.AstronomicalUnits"),
        new (Distance.Angstrom, "{0} Å", "1 ångström", "{0} ångströms", "Quantity.Unit.Distance.Ångströms"),
        new (Distance.Foot, "{0} ft", "1 foot", "{0} feet", "Quantity.Unit.Distance.Feet"),
        new (Distance.Inch, "{0} in", "1 inch", "{0} inches", "Quantity.Unit.Distance.Inches"),
        new (Distance.Lightsecond, "{0} ls", "1 lightsecond", "{0} lightseconds", "Quantity.Unit.Distance.Lightseconds"),
        new (Distance.Lightyear, "{0} ly", "1 lightyear", "{0} lightyears", "Quantity.Unit.Distance.Lightyears"),
        new (Distance.Meter, "{0} m", "1 meter", "{0} meters", "Quantity.Unit.Distance.Meters"),
        new (Distance.Mile, "{0} mi", "1 mile", "{0} miles", "Quantity.Unit.Distance.Miles"),
        new (Distance.Parsec, "{0} pc", "1 parsec", "{0} parsecs", "Quantity.Unit.Distance.Parsecs"),
        new (Distance.SolarRadius, "{0} R☉", "1 Solar radius", "{0} Solar radii", "Quantity.Unit.Distance.SolarRadii"),
        new (Distance.Thou, "{0} th", "1 thou", "{0} thous", "Quantity.Unit.Distance.Thous"),
        new (Distance.Yard, "{0} yd", "1 yard", "{0} yards", "Quantity.Unit.Distance.Yards"),
        new (Distance.NauticalMile, "{0} NM", "1 nautical mile", "{0} nautical miles", "Quantity.Unit.Distance.NauticalMiles"),
        new (Distance.Fathom, "{0} ftm", "1 fathom", "{0} fathoms", "Quantity.Unit.Distance.Fathoms"),
        new (Distance.Chain, "{0} ch", "1 chain", "{0} chains", "Quantity.Unit.Distance.Chains"),
        new (Distance.Rod, "{0} rd", "1 rod", "{0} rods", "Quantity.Unit.Distance.Rods"),
        new (SI<Distance>.Quecto, "{0} qm", "1 quectometer", "{0} quectometers", "Quantity.Unit.Distance.Quectometers"),
        new (SI<Distance>.Ronto, "{0} rm", "1 rontometer", "{0} rontometers", "Quantity.Unit.Distance.Rontometers"),
        new (SI<Distance>.Yocto, "{0} ym", "1 yoctometer", "{0} yoctometers", "Quantity.Unit.Distance.Yoctometers"),
        new (SI<Distance>.Zepto, "{0} zm", "1 zeptometer", "{0} zeptometers", "Quantity.Unit.Distance.Zeptometers"),
        new (SI<Distance>.Atto, "{0} am", "1 attometer", "{0} attometers", "Quantity.Unit.Distance.Attometers"),
        new (SI<Distance>.Femto, "{0} fm", "1 femtometer", "{0} femtometers", "Quantity.Unit.Distance.Femtometers"),
        new (SI<Distance>.Pico, "{0} pm", "1 picometer", "{0} picometers", "Quantity.Unit.Distance.Picometers"),
        new (SI<Distance>.Nano, "{0} nm", "1 nanometer", "{0} nanometers", "Quantity.Unit.Distance.Nanometers"),
        new (SI<Distance>.Micro, "{0} µm", "1 micrometer", "{0} micrometers", "Quantity.Unit.Distance.Micrometers"),
        new (SI<Distance>.Centi, "{0} cm", "1 centimeter", "{0} centimeters", "Quantity.Unit.Distance.Centimeters"),
        new (SI<Distance>.Deci, "{0} dm", "1 decimeter", "{0} decimeters", "Quantity.Unit.Distance.Decimeters"),
        new (SI<Distance>.Deca, "{0} dam", "1 decameter", "{0} decameters", "Quantity.Unit.Distance.Decameters"),
        new (SI<Distance>.Hecto, "{0} hm", "1 hectometer", "{0} hectometers", "Quantity.Unit.Distance.Hectometers"),
        new (SI<Distance>.Milli, "{0} mm", "1 millimeter", "{0} millimeters", "Quantity.Unit.Distance.Millimeters"),
        new (SI<Distance>.Kilo, "{0} km", "1 kilometer", "{0} kilometers", "Quantity.Unit.Distance.Kilometers"),
        new (SI<Distance>.Mega, "{0} Mm", "1 megameter", "{0} megameters", "Quantity.Unit.Distance.Megameters"),
        new (SI<Distance>.Giga, "{0} Gm", "1 gigameter", "{0} gigameters", "Quantity.Unit.Distance.Gigameters"),
        new (SI<Distance>.Tera, "{0} Tm", "1 terameter", "{0} terameters", "Quantity.Unit.Distance.Terameters"),
        new (SI<Distance>.Peta, "{0} Pm", "1 petameter", "{0} petameters", "Quantity.Unit.Distance.Petameters"),
        new (SI<Distance>.Exa, "{0} Em", "1 exameter", "{0} exameters", "Quantity.Unit.Distance.Exameters"),
        new (SI<Distance>.Zetta, "{0} Zm", "1 zettameter", "{0} zettameters", "Quantity.Unit.Distance.Zettameters"),
        new (SI<Distance>.Yotta, "{0} Ym", "1 yottameter", "{0} yottameters", "Quantity.Unit.Distance.Yottameters"),
        new (SI<Distance>.Ronna, "{0} Rm", "1 ronnameter", "{0} ronnameters", "Quantity.Unit.Distance.Ronnameters"),
        new (SI<Distance>.Quetta, "{0} Qm", "1 quettameter", "{0} quettameters", "Quantity.Unit.Distance.Quettameters")
    ];

    internal static IEnumerable<object[]> DistanceShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            DistanceTestDataTuples.Select(distanceUnitArgs => new object[] {
                distanceUnitArgs.unit, numValue, string.Format(distanceUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> DistanceLongNameSingularFormArgs
    {
        get => DistanceTestDataTuples.Select(distanceUnitArgs => new object[] {
            distanceUnitArgs.unit, distanceUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> DistanceLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            DistanceTestDataTuples.Select(distanceUnitArgs => new object[] {
                distanceUnitArgs.unit, numValue, string.Format(distanceUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> DistancePredefinedCompoundFormatInfoArgs
    {
        get => new object[][]
        {
            [Distance.FeetInches, 0d, ""],
            [Distance.FeetInches, .0254d, "1\""],
            [Distance.FeetInches, .3048d, "1'"],
            [Distance.FeetInches, .3302d, "1'1\""]
        };
    }

    /// <summary>
    /// A collection of test arguments for verifying the unit keys for distance units.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<DistanceUnitKeyTestData> DistanceUnitKeyArgs =>
        DistanceTestDataTuples.Select(unitArgs => new DistanceUnitKeyTestData(unitArgs.unit, unitArgs.unitKey));

    [TestMethod]
    [DynamicData(nameof(DistanceShortNameArgs))]
    public void DistanceUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Distance> distanceUnit, double distanceValue, string expectedStr)
    {
        var distance = new Distance(distanceValue * distanceUnit.Ratio);
        var resultStr = distance.FormatAs(distanceUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(DistanceLongNameSingularFormArgs))]
    public void DistanceUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Distance> distanceUnit, string expectedStr)
    {
        var distance = new Distance(distanceUnit.Ratio);
        var resultStr = distance.FormatAs(distanceUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(DistanceLongNamePluralFormArgs))]
    public void DistanceUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Distance> distanceUnit, double distanceValue, string expectedStr)
    {
        var distance = new Distance(distanceValue * distanceUnit.Ratio);
        var resultStr = distance.FormatAs(distanceUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

        [TestMethod]
    [DynamicData(nameof(DistancePredefinedCompoundFormatInfoArgs))]
    public void DistanceUnit_PredefinedQuantityCompoundFormatInfo_FormatsQuantityAsString(CompoundFormatInfo<Distance> distanceCompoundFormatInfo, double distanceValue, string expectedStr)
    {
        var distance = new Distance(distanceValue);
        var resultStr = distance.FormatCompound(distanceCompoundFormatInfo);

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that getting a unit key from an Distance unit will return the expected unit key.
    /// </summary>
    /// <param name="distanceUnit">The distance unit to use when getting the unit key.</param>
    /// <param name="expectedUnitKey">The expected unit key that this unit should return.</param>
    [TestMethod]
    [DynamicData(nameof(DistanceUnitKeyArgs))]
    public void GetDistanceUnitKey_ValidUnit_ReturnsUnitKey(Unit<Distance> distanceUnit, string expectedUnitKey)
    {
        Assert.AreEqual(expectedUnitKey, distanceUnit.UnitKey);
    }
}
