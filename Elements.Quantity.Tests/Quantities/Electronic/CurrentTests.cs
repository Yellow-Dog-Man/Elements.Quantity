using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;


namespace Elements.Quantity.Test.Quantities.Electronic;

[TestClass]
[ExcludeFromCodeCoverage]
public class CurrentTests : BaseQuantityTests<CurrentTests, Current>, IQuantityTestData<Current>
{
    /// <inheritdoc/>
    public static QuantityTestData<Current>[] TestDataTuples =>
    [
        new(Current.Ampere, "{0} A", "1 ampere", "{0} amperes", "Quantity.Unit.Electronic.Current.Amperes"),
        new(SI<Current>.Quecto, "{0} qA", "1 quectoampere", "{0} quectoamperes", "Quantity.Unit.Electronic.Current.Quectoamperes"),
        new(SI<Current>.Ronto, "{0} rA", "1 rontoampere", "{0} rontoamperes", "Quantity.Unit.Electronic.Current.Rontoamperes"),
        new(SI<Current>.Yocto, "{0} yA", "1 yoctoampere", "{0} yoctoamperes", "Quantity.Unit.Electronic.Current.Yoctoamperes"),
        new(SI<Current>.Zepto, "{0} zA", "1 zeptoampere", "{0} zeptoamperes", "Quantity.Unit.Electronic.Current.Zeptoamperes"),
        new(SI<Current>.Atto, "{0} aA", "1 attoampere", "{0} attoamperes", "Quantity.Unit.Electronic.Current.Attoamperes"),
        new(SI<Current>.Femto, "{0} fA", "1 femtoampere", "{0} femtoamperes", "Quantity.Unit.Electronic.Current.Femtoamperes"),
        new(SI<Current>.Pico, "{0} pA", "1 picoampere", "{0} picoamperes", "Quantity.Unit.Electronic.Current.Picoamperes"),
        new(SI<Current>.Nano, "{0} nA", "1 nanoampere", "{0} nanoamperes", "Quantity.Unit.Electronic.Current.Nanoamperes"),
        new(SI<Current>.Micro, "{0} µA", "1 microampere", "{0} microamperes", "Quantity.Unit.Electronic.Current.Microamperes"),
        new(SI<Current>.Centi, "{0} cA", "1 centiampere", "{0} centiamperes", "Quantity.Unit.Electronic.Current.Centiamperes"),
        new(SI<Current>.Deci, "{0} dA", "1 deciampere", "{0} deciamperes", "Quantity.Unit.Electronic.Current.Deciamperes"),
        new(SI<Current>.Deca, "{0} daA", "1 decaampere", "{0} decaamperes", "Quantity.Unit.Electronic.Current.Decaamperes"),
        new(SI<Current>.Hecto, "{0} hA", "1 hectoampere", "{0} hectoamperes", "Quantity.Unit.Electronic.Current.Hectoamperes"),
        new(SI<Current>.Milli, "{0} mA", "1 milliampere", "{0} milliamperes", "Quantity.Unit.Electronic.Current.Milliamperes"),
        new(SI<Current>.Kilo, "{0} kA", "1 kiloampere", "{0} kiloamperes", "Quantity.Unit.Electronic.Current.Kiloamperes"),
        new(SI<Current>.Mega, "{0} MA", "1 megaampere", "{0} megaamperes", "Quantity.Unit.Electronic.Current.Megaamperes"),
        new(SI<Current>.Giga, "{0} GA", "1 gigaampere", "{0} gigaamperes", "Quantity.Unit.Electronic.Current.Gigaamperes"),
        new(SI<Current>.Tera, "{0} TA", "1 teraampere", "{0} teraamperes", "Quantity.Unit.Electronic.Current.Teraamperes"),
        new(SI<Current>.Peta, "{0} PA", "1 petaampere", "{0} petaamperes", "Quantity.Unit.Electronic.Current.Petaamperes"),
        new(SI<Current>.Exa, "{0} EA", "1 exaampere", "{0} exaamperes", "Quantity.Unit.Electronic.Current.Exaamperes"),
        new(SI<Current>.Zetta, "{0} ZA", "1 zettaampere", "{0} zettaamperes", "Quantity.Unit.Electronic.Current.Zettaamperes"),
        new(SI<Current>.Yotta, "{0} YA", "1 yottaampere", "{0} yottaamperes", "Quantity.Unit.Electronic.Current.Yottaamperes"),
        new(SI<Current>.Ronna, "{0} RA", "1 ronnaampere", "{0} ronnaamperes", "Quantity.Unit.Electronic.Current.Ronnaamperes"),
        new(SI<Current>.Quetta, "{0} QA", "1 quettaampere", "{0} quettaamperes", "Quantity.Unit.Electronic.Current.Quettaamperes")
    ];
}
