using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Elements.Quantity.Test.Quantities.Basic;

using TemperatureTestData = QuantityTestData<Temperature>;
using TemperatureUnitKeyTestData = (Unit<Temperature> unit, string unitKey);

[TestClass]
[ExcludeFromCodeCoverage]
public class TemperatureTests
{
    /// <summary>
    /// An array of test data tuples representing different temperature units and their display formats. Each
    /// element in the array contains information about a temperature unit, the short name, the singular
    /// long name, plural long name, and unit key.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static TemperatureTestData[] TemperatureTestDataTuples =>
    [
        new(Temperature.Kelvin, "{0} K", "1 Kelvin", "{0} Kelvins", "Quantity.Unit.Temperature.Kelvins"),
        new(Temperature.Celsius, "{0} °C", "1 degree Celsius", "{0} degrees Celsius", "Quantity.Unit.Temperature.Celsius"),
        new(Temperature.Fahrenheit, "{0} °F", "1 degree Fahrenheit", "{0} degrees Fahrenheit", "Quantity.Unit.Temperature.Fahrenheit"),
        new(Temperature.Rankine, "{0} °R", "1 degree Rankine", "{0} degrees Rankine", "Quantity.Unit.Temperature.Rankine")
    ];

    internal static IEnumerable<object[]> TemperatureShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            TemperatureTestDataTuples.Select(temperatureUnitArgs => new object[]
            {
                temperatureUnitArgs.unit, numValue, string.Format(temperatureUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> TemperatureLongNameSingularFormArgs
    {
        get => TemperatureTestDataTuples.Select(temperatureUnitArgs => new object[]
        {
            temperatureUnitArgs.unit, temperatureUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> TemperatureLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            TemperatureTestDataTuples.Select(temperatureUnitArgs => new object[]
            {
                temperatureUnitArgs.unit, numValue, string.Format(temperatureUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// A collection of test arguments for verifying the unit keys for temperature units.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<TemperatureUnitKeyTestData> TemperatureUnitKeyArgs =>
        TemperatureTestDataTuples.Select(unitArgs => new TemperatureUnitKeyTestData(unitArgs.unit, unitArgs.unitKey));

    [TestMethod]
    [DynamicData(nameof(TemperatureShortNameArgs))]
    public void TemperatureUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(
        Unit<Temperature> temperatureUnit, double temperatureValue, string expectedStr)
    {
        var temperature = temperatureUnit.ConvertFrom(temperatureValue);
        var resultStr = temperature.FormatAs(temperatureUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(TemperatureLongNameSingularFormArgs))]
    public void TemperatureUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(
        Unit<Temperature> temperatureUnit, string expectedStr)
    {
        var temperature = temperatureUnit.ConvertFrom(1);
        var resultStr = temperature.FormatAs(temperatureUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(TemperatureLongNamePluralFormArgs))]
    public void TemperatureUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(
        Unit<Temperature> temperatureUnit, double temperatureValue, string expectedStr)
    {
        var temperature = temperatureUnit.ConvertFrom(temperatureValue);
        var resultStr = temperature.FormatAs(temperatureUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that getting a unit key from an Temperature unit will return the expected unit key.
    /// </summary>
    /// <param name="temperatureUnit">The temperature unit to use when getting the unit key.</param>
    /// <param name="expectedUnitKey">The expected unit key that this unit should return.</param>
    [TestMethod]
    [DynamicData(nameof(TemperatureUnitKeyArgs))]
    public void GetTemperatureUnitKey_ValidUnit_ReturnsUnitKey(Unit<Temperature> temperatureUnit,
        string expectedUnitKey)
    {
        Assert.AreEqual(expectedUnitKey, temperatureUnit.UnitKey);
    }

    [DataRow(1, -272.15)]
    [DataRow(0, -273.15)]
    [DataRow(373.1, 100)]//Boiling point of water
    [DataRow(273.15, 0)]
    [DataRow(273.15 * 2, 273.15)]
    [TestMethod]
    public void KelvinToCelsius(double kelvin, double expectedCelsius)
    {
        var temperature = new Temperature(kelvin);

        Assert.AreEqual(expectedCelsius, temperature.ConvertTo(Temperature.Celsius), 0.1);
    }

    [DataRow(1, -457.87)]
    [DataRow(0, -459.67)]
    [DataRow(373.1, 212)]//boiling point of water
    [DataRow(273.15, 32)]
    [DataRow(273.15 * 2, 523.67)]
    [TestMethod]
    public void KelvinToFarenheit(double kelvin, double expectedFarenheit)
    {
        var temperature = new Temperature(kelvin);

        Assert.AreEqual(expectedFarenheit, temperature.ConvertTo(Temperature.Fahrenheit), 0.1);
    }


    [DataRow(1, 1.8)]
    [DataRow(0, 0)]
    [DataRow(373.1, 671.67)]//boiling point of water
    [DataRow(256, 460.8)]
    [DataRow(256 * 2, 921.6)]
    [TestMethod]
    public void KelvinToRankine(double kelvin, double expectedRankine)
    {
        var temperature = new Temperature(kelvin);

        Assert.AreEqual(expectedRankine, temperature.ConvertTo(Temperature.Rankine), 0.1);
    }
}
