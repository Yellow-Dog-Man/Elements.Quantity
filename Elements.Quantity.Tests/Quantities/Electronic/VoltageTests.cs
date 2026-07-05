using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace Elements.Quantity.Test.Quantities.Electronic;

[TestClass]
[ExcludeFromCodeCoverage]
public class VoltageTests : BaseQuantityTests<VoltageTests, Voltage>, IQuantityTestData<Voltage>
{
    /// <inheritdoc/>
    public static QuantityTestData<Voltage>[] TestDataTuples =>
    [
        new(Voltage.Volt, "{0} V", "1 volt", "{0} volts", "Quantity.Unit.Electronic.Voltage.Volts"),
        new(SI<Voltage>.Quecto, "{0} qV", "1 quectovolt", "{0} quectovolts", "Quantity.Unit.Electronic.Voltage.Quectovolts"),
        new(SI<Voltage>.Ronto, "{0} rV", "1 rontovolt", "{0} rontovolts", "Quantity.Unit.Electronic.Voltage.Rontovolts"),
        new(SI<Voltage>.Yocto, "{0} yV", "1 yoctovolt", "{0} yoctovolts", "Quantity.Unit.Electronic.Voltage.Yoctovolts"),
        new(SI<Voltage>.Zepto, "{0} zV", "1 zeptovolt", "{0} zeptovolts", "Quantity.Unit.Electronic.Voltage.Zeptovolts"),
        new(SI<Voltage>.Atto, "{0} aV", "1 attovolt", "{0} attovolts", "Quantity.Unit.Electronic.Voltage.Attovolts"),
        new(SI<Voltage>.Femto, "{0} fV", "1 femtovolt", "{0} femtovolts", "Quantity.Unit.Electronic.Voltage.Femtovolts"),
        new(SI<Voltage>.Pico, "{0} pV", "1 picovolt", "{0} picovolts", "Quantity.Unit.Electronic.Voltage.Picovolts"),
        new(SI<Voltage>.Nano, "{0} nV", "1 nanovolt", "{0} nanovolts", "Quantity.Unit.Electronic.Voltage.Nanovolts"),
        new(SI<Voltage>.Micro, "{0} µV", "1 microvolt", "{0} microvolts", "Quantity.Unit.Electronic.Voltage.Microvolts"),
        new(SI<Voltage>.Centi, "{0} cV", "1 centivolt", "{0} centivolts", "Quantity.Unit.Electronic.Voltage.Centivolts"),
        new(SI<Voltage>.Deci, "{0} dV", "1 decivolt", "{0} decivolts", "Quantity.Unit.Electronic.Voltage.Decivolts"),
        new(SI<Voltage>.Deca, "{0} daV", "1 decavolt", "{0} decavolts", "Quantity.Unit.Electronic.Voltage.Decavolts"),
        new(SI<Voltage>.Hecto, "{0} hV", "1 hectovolt", "{0} hectovolts", "Quantity.Unit.Electronic.Voltage.Hectovolts"),
        new(SI<Voltage>.Milli, "{0} mV", "1 millivolt", "{0} millivolts", "Quantity.Unit.Electronic.Voltage.Millivolts"),
        new(SI<Voltage>.Kilo, "{0} kV", "1 kilovolt", "{0} kilovolts", "Quantity.Unit.Electronic.Voltage.Kilovolts"),
        new(SI<Voltage>.Mega, "{0} MV", "1 megavolt", "{0} megavolts", "Quantity.Unit.Electronic.Voltage.Megavolts"),
        new(SI<Voltage>.Giga, "{0} GV", "1 gigavolt", "{0} gigavolts", "Quantity.Unit.Electronic.Voltage.Gigavolts"),
        new(SI<Voltage>.Tera, "{0} TV", "1 teravolt", "{0} teravolts", "Quantity.Unit.Electronic.Voltage.Teravolts"),
        new(SI<Voltage>.Peta, "{0} PV", "1 petavolt", "{0} petavolts", "Quantity.Unit.Electronic.Voltage.Petavolts"),
        new(SI<Voltage>.Exa, "{0} EV", "1 exavolt", "{0} exavolts", "Quantity.Unit.Electronic.Voltage.Exavolts"),
        new(SI<Voltage>.Zetta, "{0} ZV", "1 zettavolt", "{0} zettavolts", "Quantity.Unit.Electronic.Voltage.Zettavolts"),
        new(SI<Voltage>.Yotta, "{0} YV", "1 yottavolt", "{0} yottavolts", "Quantity.Unit.Electronic.Voltage.Yottavolts"),
        new(SI<Voltage>.Ronna, "{0} RV", "1 ronnavolt", "{0} ronnavolts", "Quantity.Unit.Electronic.Voltage.Ronnavolts"),
        new(SI<Voltage>.Quetta, "{0} QV", "1 quettavolt", "{0} quettavolts", "Quantity.Unit.Electronic.Voltage.Quettavolts")
    ];

    /// <inheritdoc/>
    public static IEnumerable<QuantityFormatTestData<Voltage>>? CompoundFormatInfoDataTuples => null;
}
