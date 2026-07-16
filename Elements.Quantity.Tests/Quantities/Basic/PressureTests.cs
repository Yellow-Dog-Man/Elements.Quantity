using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public class PressureTests : BaseQuantityTests<PressureTests, Pressure>, IQuantityTestData<Pressure>
{
    /// <inheritdoc/>
    public static QuantityTestData<Pressure>[] TestDataTuples =>
    [
        new(Pressure.Pascal, "{0} Pa", "1 pascal", "{0} pascals", "Quantity.Unit.Pressure.Pascals"),
        new(Pressure.Bar, "{0} bar", "1 bar", "{0} bars", "Quantity.Unit.Pressure.Bars"),
        new(Pressure.Atmosphere, "{0} atm", "1 standard atmosphere", "{0} standard atmospheres", "Quantity.Unit.Pressure.StandardAtmospheres"),
        new(Pressure.Torr, "{0} Torr", "1 torr", "{0} torrs", "Quantity.Unit.Pressure.Torrs"),
        new(Pressure.Millibar, "{0} mbar", "1 millibar", "{0} millibars", "Quantity.Unit.Pressure.Millibars"),
        new(Pressure.PoundPerSquareInch, "{0} psi", "1 pound per square inch", "{0} pounds per square inch", "Quantity.Unit.Pressure.PoundsPerSquareInch"),
        new(SI<Pressure>.Quecto, "{0} qPa", "1 quectopascal", "{0} quectopascals", "Quantity.Unit.Pressure.Quectopascals"),
        new(SI<Pressure>.Ronto, "{0} rPa", "1 rontopascal", "{0} rontopascals", "Quantity.Unit.Pressure.Rontopascals"),
        new(SI<Pressure>.Yocto, "{0} yPa", "1 yoctopascal", "{0} yoctopascals", "Quantity.Unit.Pressure.Yoctopascals"),
        new(SI<Pressure>.Zepto, "{0} zPa", "1 zeptopascal", "{0} zeptopascals", "Quantity.Unit.Pressure.Zeptopascals"),
        new(SI<Pressure>.Atto, "{0} aPa", "1 attopascal", "{0} attopascals", "Quantity.Unit.Pressure.Attopascals"),
        new(SI<Pressure>.Femto, "{0} fPa", "1 femtopascal", "{0} femtopascals", "Quantity.Unit.Pressure.Femtopascals"),
        new(SI<Pressure>.Pico, "{0} pPa", "1 picopascal", "{0} picopascals", "Quantity.Unit.Pressure.Picopascals"),
        new(SI<Pressure>.Nano, "{0} nPa", "1 nanopascal", "{0} nanopascals", "Quantity.Unit.Pressure.Nanopascals"),
        new(SI<Pressure>.Micro, "{0} µPa", "1 micropascal", "{0} micropascals", "Quantity.Unit.Pressure.Micropascals"),
        new(SI<Pressure>.Milli, "{0} mPa", "1 millipascal", "{0} millipascals", "Quantity.Unit.Pressure.Millipascals"),
        new(SI<Pressure>.Centi, "{0} cPa", "1 centipascal", "{0} centipascals", "Quantity.Unit.Pressure.Centipascals"),
        new(SI<Pressure>.Deci, "{0} dPa", "1 decipascal", "{0} decipascals", "Quantity.Unit.Pressure.Decipascals"),
        new(SI<Pressure>.Deca, "{0} daPa", "1 decapascal", "{0} decapascals", "Quantity.Unit.Pressure.Decapascals"),
        new(SI<Pressure>.Hecto, "{0} hPa", "1 hectopascal", "{0} hectopascals", "Quantity.Unit.Pressure.Hectopascals"),
        new(SI<Pressure>.Kilo, "{0} kPa", "1 kilopascal", "{0} kilopascals", "Quantity.Unit.Pressure.Kilopascals"),
        new(SI<Pressure>.Mega, "{0} MPa", "1 megapascal", "{0} megapascals", "Quantity.Unit.Pressure.Megapascals"),
        new(SI<Pressure>.Giga, "{0} GPa", "1 gigapascal", "{0} gigapascals", "Quantity.Unit.Pressure.Gigapascals"),
        new(SI<Pressure>.Tera, "{0} TPa", "1 terapascal", "{0} terapascals", "Quantity.Unit.Pressure.Terapascals"),
        new(SI<Pressure>.Peta, "{0} PPa", "1 petapascal", "{0} petapascals", "Quantity.Unit.Pressure.Petapascals"),
        new(SI<Pressure>.Exa, "{0} EPa", "1 exapascal", "{0} exapascals", "Quantity.Unit.Pressure.Exapascals"),
        new(SI<Pressure>.Zetta, "{0} ZPa", "1 zettapascal", "{0} zettapascals", "Quantity.Unit.Pressure.Zettapascals"),
        new(SI<Pressure>.Yotta, "{0} YPa", "1 yottapascal", "{0} yottapascals", "Quantity.Unit.Pressure.Yottapascals"),
        new(SI<Pressure>.Ronna, "{0} RPa", "1 ronnapascal", "{0} ronnapascals", "Quantity.Unit.Pressure.Ronnapascals"),
        new(SI<Pressure>.Quetta, "{0} QPa", "1 quettapascal", "{0} quettapascals", "Quantity.Unit.Pressure.Quettapascals")
    ];
}
