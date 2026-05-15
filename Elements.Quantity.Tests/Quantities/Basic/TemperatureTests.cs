using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elements.Quantity.Test.Quantities.Basic;

using TemperatureTestData = (Unit<Temperature> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class TemperatureTests
{
    internal static TemperatureTestData[] TemperatureTestDataTuples
    {
        get => new TemperatureTestData[]
        {
            new (Temperature.Kelvin, "{0} K", "1 Kelvin", "{0} Kelvins"),
            new (Temperature.Celsius, "{0} °C", "1 degree Celsius", "{0} degrees Celsius"),
            new (Temperature.Fahrenheit, "{0} °F", "1 degree Fahrenheit", "{0} degrees Fahrenheit")
        };
    }

    internal static IEnumerable<object[]> TemperatureShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            TemperatureTestDataTuples.Select(temperatureUnitArgs => new object[] {
                temperatureUnitArgs.unit, numValue, string.Format(temperatureUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> TemperatureLongNameSingularFormArgs
    {
        get => TemperatureTestDataTuples.Select(temperatureUnitArgs => new object[] {
            temperatureUnitArgs.unit, temperatureUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> TemperatureLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            TemperatureTestDataTuples.Select(temperatureUnitArgs => new object[] {
                temperatureUnitArgs.unit, numValue, string.Format(temperatureUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    [TestMethod]
    [DynamicData(nameof(TemperatureShortNameArgs))]
    public void TemperatureUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Temperature> temperatureUnit, double temperatureValue, string expectedStr)
    {
        var temperature = temperatureUnit.ConvertFrom(temperatureValue);
        var resultStr = temperature.FormatAs(temperatureUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(TemperatureLongNameSingularFormArgs))]
    public void TemperatureUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Temperature> temperatureUnit, string expectedStr)
    {
        var temperature = temperatureUnit.ConvertFrom(1);
        var resultStr = temperature.FormatAs(temperatureUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(TemperatureLongNamePluralFormArgs))]
    public void TemperatureUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Temperature> temperatureUnit, double temperatureValue, string expectedStr)
    {
        var temperature = temperatureUnit.ConvertFrom(temperatureValue);
        var resultStr = temperature.FormatAs(temperatureUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }
}
