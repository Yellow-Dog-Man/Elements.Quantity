using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Basic;

using DistanceTestData = (Unit<Distance> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class DistanceTests
{
    internal static DistanceTestData[] DistanceTestDataTuples
    {
        get => new DistanceTestData[]
        {
            new (Distance.AU, "{0} AU", "1 Astronomical Unit", "{0} Astronomical Units"),
            new (Distance.Angstrom, "{0} Å", "1 ångström", "{0} ångströms"),
            new (Distance.Foot, "{0} ft", "1 foot", "{0} feet"),
            new (Distance.Inch, "{0} in", "1 inch", "{0} inches"),
            new (Distance.Lightsecond, "{0} ls", "1 lightsecond", "{0} lightseconds"),
            new (Distance.Lightyear, "{0} ly", "1 lightyear", "{0} lightyears"),
            new (Distance.Meter, "{0} m", "1 meter", "{0} meters"),
            new (Distance.Mile, "{0} mi", "1 mile", "{0} miles"),
            new (Distance.Parsec, "{0} pc", "1 parsec", "{0} parsecs"),
            new (Distance.SolarRadius, "{0} R☉", "1 Solar radius", "{0} Solar radii"),
            new (Distance.Thou, "{0} th", "1 thou", "{0} thous"),
            new (Distance.Yard, "{0} yd", "1 yard", "{0} yards"),
            new (SI<Distance>.Kilo, "{0} km", "1 kilometer", "{0} kilometers"),
            new (SI<Distance>.Centi, "{0} cm", "1 centimeter", "{0} centimeters"),
            new (SI<Distance>.Milli, "{0} mm", "1 millimeter", "{0} millimeters"),
            new (SI<Distance>.Micro, "{0} µm", "1 micrometer", "{0} micrometers"),
            new (SI<Distance>.Nano, "{0} nm", "1 nanometer", "{0} nanometers"),
            new (SI<Distance>.Pico, "{0} pm", "1 picometer", "{0} picometers"),
            new (SI<Distance>.Femto, "{0} fm", "1 femtometer", "{0} femtometers"),
            new (SI<Distance>.Atto, "{0} am", "1 attometer", "{0} attometers")
        };
    }

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
}
