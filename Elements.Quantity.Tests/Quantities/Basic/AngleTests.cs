using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elements.Quantity.Test.Quantities.Basic;

using AngleTestData = (Unit<Angle> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class AngleTests
{
    internal static AngleTestData[] AngleTestDataTuples
    {
        get => new AngleTestData[]
        {
            new (Angle.Radian, "{0} rad", "1 radian", "{0} radians"),
            new (Angle.Degree, "{0}°", "1 degree", "{0} degrees"),
            new (Angle.ArcMinute, "{0}′", "1 arcminute", "{0} arcminutes"),
            new (Angle.ArcSecond, "{0}″", "1 arcsecond", "{0} arcseconds"),
            new (SI<Angle>.Centi, "{0} crad", "1 centiradian", "{0} centiradians"),
            new (SI<Angle>.Deca, "{0} darad", "1 decaradian", "{0} decaradians"),
            new (SI<Angle>.Deci, "{0} drad", "1 deciradian", "{0} deciradians"),
            new (SI<Angle>.Hecto, "{0} hrad", "1 hectoradian", "{0} hectoradians")
        };
    }

    internal static IEnumerable<object[]> AngleShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            AngleTestDataTuples.Select(angleUnitArgs => new object[] {
                    angleUnitArgs.unit, numValue, string.Format(angleUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> AngleLongNameSingularFormArgs
    {
        get => AngleTestDataTuples.Select(angleUnitArgs => new object[] {
                angleUnitArgs.unit, angleUnitArgs.longNameSingle
            });
    }

    internal static IEnumerable<object[]> AngleLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            AngleTestDataTuples.Select(angleUnitArgs => new object[] {
                    angleUnitArgs.unit, numValue, string.Format(angleUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> AnglePredefinedCompoundFormatInfoArgs
    {
        get => new object[][]
        {
            [Angle.DegreeMinSec, 0d, ""],
            [Angle.DegreeMinSec, 0.25d, "14°19′26″"],
            [Angle.DegreeMinSec, 0.5d, "28°38′52″"],
            [Angle.DegreeMinSec, 0.96d, "55°14″"],
            [Angle.DegreeMinSec, 1d, "57°17′45″"],
            [Angle.DegreeMinSec, 1.25d, "71°37′11″"],

            // Constructed using constants, to match the expected values from before #17
            [Angle.DegreeMinSec, Math.PI/180d, "1°"],
            [Angle.DegreeMinSec, Math.PI/180d + Math.PI/648000d, "1°1″"],
            [Angle.DegreeMinSec, Math.PI/180d + Math.PI/10800d + Math.PI/648000d, "1°1′1″"]
        };
    }

    [TestMethod]
    [DynamicData(nameof(AngleShortNameArgs))]
    public void AngleUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Angle> angleUnit, double angleValue, string expectedStr)
    {
        var angle = new Angle(angleValue * angleUnit.Ratio);
        var resultStr = angle.FormatAs(angleUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(AngleLongNameSingularFormArgs))]
    public void AngleUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Angle> angleUnit, string expectedStr)
    {
        var angle = new Angle(angleUnit.Ratio);
        var resultStr = angle.FormatAs(angleUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(AngleLongNamePluralFormArgs))]
    public void AngleUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Angle> angleUnit, double angleValue, string expectedStr)
    {
        var angle = new Angle(angleValue * angleUnit.Ratio);
        var resultStr = angle.FormatAs(angleUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Test that Angle's are correctly formatted when using <see cref="CompoundFormatInfo{Angle}"/>
    /// </summary>
    /// <param name="angleCompoundFormatInfo">Format Info used</param>
    /// <param name="angleValue">Angle value in <see cref="Angle.DefaultUnit"/> Unit.</param>
    /// <param name="expectedStr">Expected format result</param>
    [TestMethod]
    [DynamicData(nameof(AnglePredefinedCompoundFormatInfoArgs))]
    public void AngleUnit_PredefinedQuantityCompoundFormatInfo_FormatsQuantityAsString(CompoundFormatInfo<Angle> angleCompoundFormatInfo, double angleValue, string expectedStr)
    {
        var angle = new Angle(angleValue);
        var resultStr = angle.FormatCompound(angleCompoundFormatInfo);

        Assert.AreEqual(expectedStr, resultStr);
    }
}
