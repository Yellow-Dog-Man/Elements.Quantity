using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Electronic;

using VoltageTestData = (Unit<Voltage> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class VoltageTests
{
    internal static VoltageTestData[] VoltageTestDataTuples
    {
        get => new VoltageTestData[]
        {
            new (Voltage.Volt, "{0} V", "1 volt", "{0} volts"),
            new (SI<Voltage>.Quecto, "{0} qV", "1 quectovolt", "{0} quectovolts"),
            new (SI<Voltage>.Ronto, "{0} rV", "1 rontovolt", "{0} rontovolts"),
            new (SI<Voltage>.Yocto, "{0} yV", "1 yoctovolt", "{0} yoctovolts"),
            new (SI<Voltage>.Zepto, "{0} zV", "1 zeptovolt", "{0} zeptovolts"),
            new (SI<Voltage>.Atto, "{0} aV", "1 attovolt", "{0} attovolts"),
            new (SI<Voltage>.Femto, "{0} fV", "1 femtovolt", "{0} femtovolts"),
            new (SI<Voltage>.Pico, "{0} pV", "1 picovolt", "{0} picovolts"),
            new (SI<Voltage>.Nano, "{0} nV", "1 nanovolt", "{0} nanovolts"),
            new (SI<Voltage>.Micro, "{0} µV", "1 microvolt", "{0} microvolts"),
            new (SI<Voltage>.Milli, "{0} mV", "1 millivolt", "{0} millivolts"),
            new (SI<Voltage>.Kilo, "{0} kV", "1 kilovolt", "{0} kilovolts"),
            new (SI<Voltage>.Mega, "{0} MV", "1 megavolt", "{0} megavolts"),
            new (SI<Voltage>.Giga, "{0} GV", "1 gigavolt", "{0} gigavolts"),
            new (SI<Voltage>.Tera, "{0} TV", "1 teravolt", "{0} teravolts"),
            new (SI<Voltage>.Peta, "{0} PV", "1 petavolt", "{0} petavolts"),
            new (SI<Voltage>.Exa, "{0} EV", "1 exavolt", "{0} exavolts"),
            new (SI<Voltage>.Zetta, "{0} ZV", "1 zettavolt", "{0} zettavolts"),
            new (SI<Voltage>.Yotta, "{0} YV", "1 yottavolt", "{0} yottavolts"),
            new (SI<Voltage>.Ronna, "{0} RV", "1 ronnavolt", "{0} ronnavolts"),
            new (SI<Voltage>.Quetta, "{0} QV", "1 quettavolt", "{0} quettavolts")
        };
    }

    internal static IEnumerable<object[]> VoltageShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            VoltageTestDataTuples.Select(voltageUnitArgs => new object[] {
                voltageUnitArgs.unit, numValue, string.Format(voltageUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> VoltageLongNameSingularFormArgs
    {
        get => VoltageTestDataTuples.Select(voltageUnitArgs => new object[] {
            voltageUnitArgs.unit, voltageUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> VoltageLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            VoltageTestDataTuples.Select(voltageUnitArgs => new object[] {
                voltageUnitArgs.unit, numValue, string.Format(voltageUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    [TestMethod]
    [DynamicData(nameof(VoltageShortNameArgs))]
    public void VoltageUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Voltage> voltageUnit, double voltageValue, string expectedStr)
    {
        var voltage = new Voltage(voltageValue * voltageUnit.Ratio);
        var resultStr = voltage.FormatAs(voltageUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(VoltageLongNameSingularFormArgs))]
    public void VoltageUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Voltage> voltageUnit, string expectedStr)
    {
        var voltage = new Voltage(voltageUnit.Ratio);
        var resultStr = voltage.FormatAs(voltageUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(VoltageLongNamePluralFormArgs))]
    public void VoltageUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Voltage> voltageUnit, double voltageValue, string expectedStr)
    {
        var voltage = new Voltage(voltageValue * voltageUnit.Ratio);
        var resultStr = voltage.FormatAs(voltageUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }
}
