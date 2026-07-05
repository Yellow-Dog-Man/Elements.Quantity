using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public class TemperatureTests : BaseQuantityTests<TemperatureTests, Temperature>, IQuantityTestData<Temperature>
{
    /// <inheritdoc/>
    public static QuantityTestData<Temperature>[] TestDataTuples =>
    [
        new(Temperature.Kelvin, "{0} K", "1 Kelvin", "{0} Kelvins", "Quantity.Unit.Temperature.Kelvins"),
        new(Temperature.Celsius, "{0} °C", "1 degree Celsius", "{0} degrees Celsius", "Quantity.Unit.Temperature.Celsius"),
        new(Temperature.Fahrenheit, "{0} °F", "1 degree Fahrenheit", "{0} degrees Fahrenheit", "Quantity.Unit.Temperature.Fahrenheit"),
        new(Temperature.Rankine, "{0} °R", "1 degree Rankine", "{0} degrees Rankine", "Quantity.Unit.Temperature.Rankine")
    ];

    public const double TEMPERATURE_EPSILION = 0.001;

    [DataRow(1, -272.15)]
    [DataRow(0, -273.15)]
    [DataRow(373.15, 100)]//Boiling point of water
    [DataRow(273.15, 0)]
    [DataRow(273.15 * 2, 273.15)]
    [TestMethod]
    public void KelvinToCelsius(double kelvin, double expectedCelsius)
    {
        var temperature = new Temperature(kelvin);
        Assert.AreEqual(expectedCelsius, temperature.ConvertTo(Temperature.Celsius), TEMPERATURE_EPSILION);
    }

    [DataRow(1, -457.87)]
    [DataRow(0, -459.67)]
    [DataRow(373.15, 212)]//boiling point of water
    [DataRow(273.15, 32)]
    [DataRow(273.15 * 2, 523.67)]
    [TestMethod]
    public void KelvinToFarenheit(double kelvin, double expectedFarenheit)
    {
        var temperature = new Temperature(kelvin);

        Assert.AreEqual(expectedFarenheit, temperature.ConvertTo(Temperature.Fahrenheit), TEMPERATURE_EPSILION);
    }

    [DataRow(0, 32)]
    [TestMethod]
    public void CelciusToFarenheit(double celcius, double expectedFarenheit)
    {
        var result = Temperature.Fahrenheit.ConvertFrom(Temperature.Celsius.ConvertFrom(celcius));
        Assert.AreEqual(expectedFarenheit, (celcius * Temperature.Celsius) * Temperature.Fahrenheit, TEMPERATURE_EPSILION);
        Assert.AreEqual(expectedFarenheit, Temperature.Celsius.ConvertFrom(celcius).ToFarenheit(), TEMPERATURE_EPSILION);
        Assert.AreEqual(expectedFarenheit, Temperature.Celsius.ConvertFrom(celcius).ConvertTo(Temperature.Fahrenheit), TEMPERATURE_EPSILION);
    }

    [TestMethod]
    public void TestImplicitOperator()
    {
        const double kelvin = 273;
        var t = new Temperature(kelvin);
        var x = t.New(kelvin);

        Assert.AreEqual(kelvin, t, TEMPERATURE_EPSILION);
        Assert.AreEqual(kelvin, x, TEMPERATURE_EPSILION);
    }


    [DataRow(1, 1.8)]
    [DataRow(0, 0)]
    [DataRow(373.15, 671.67)]//boiling point of water
    [DataRow(256, 460.8)]
    [DataRow(256 * 2, 921.6)]
    [TestMethod]
    public void KelvinToRankine(double kelvin, double expectedRankine)
    {
        var temperature = new Temperature(kelvin);

        Assert.AreEqual(expectedRankine, temperature.ConvertTo(Temperature.Rankine), TEMPERATURE_EPSILION);
    }
}
