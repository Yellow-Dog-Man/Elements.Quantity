using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public class DistanceTests : BaseQuantityTests<DistanceTests, Distance>, IQuantityTestData<Distance>
{
    /// <inheritdoc/>
    public static QuantityTestData<Distance>[] TestDataTuples =>
    [
        new(Distance.AU, "{0} AU", "1 Astronomical Unit", "{0} Astronomical Units", "Quantity.Unit.Distance.AstronomicalUnits"),
        new(Distance.Angstrom, "{0} Å", "1 ångström", "{0} ångströms", "Quantity.Unit.Distance.Ångströms"),
        new(Distance.Foot, "{0} ft", "1 foot", "{0} feet", "Quantity.Unit.Distance.Feet"),
        new(Distance.Inch, "{0} in", "1 inch", "{0} inches", "Quantity.Unit.Distance.Inches"),
        new(Distance.Lightsecond, "{0} ls", "1 lightsecond", "{0} lightseconds", "Quantity.Unit.Distance.Lightseconds"),
        new(Distance.Lightyear, "{0} ly", "1 lightyear", "{0} lightyears", "Quantity.Unit.Distance.Lightyears"),
        new(Distance.Meter, "{0} m", "1 meter", "{0} meters", "Quantity.Unit.Distance.Meters"),
        new(Distance.Mile, "{0} mi", "1 mile", "{0} miles", "Quantity.Unit.Distance.Miles"),
        new(Distance.Parsec, "{0} pc", "1 parsec", "{0} parsecs", "Quantity.Unit.Distance.Parsecs"),
        new(Distance.SolarRadius, "{0} R☉", "1 Solar radius", "{0} Solar radii", "Quantity.Unit.Distance.SolarRadii"),
        new(Distance.Thou, "{0} th", "1 thou", "{0} thous", "Quantity.Unit.Distance.Thous"),
        new(Distance.Yard, "{0} yd", "1 yard", "{0} yards", "Quantity.Unit.Distance.Yards"),
        new(Distance.NauticalMile, "{0} NM", "1 nautical mile", "{0} nautical miles", "Quantity.Unit.Distance.NauticalMiles"),
        new(Distance.Fathom, "{0} ftm", "1 fathom", "{0} fathoms", "Quantity.Unit.Distance.Fathoms"),
        new(Distance.Chain, "{0} ch", "1 chain", "{0} chains", "Quantity.Unit.Distance.Chains"),
        new(Distance.Rod, "{0} rd", "1 rod", "{0} rods", "Quantity.Unit.Distance.Rods"),
        new(SI<Distance>.Quecto, "{0} qm", "1 quectometer", "{0} quectometers", "Quantity.Unit.Distance.Quectometers"),
        new(SI<Distance>.Ronto, "{0} rm", "1 rontometer", "{0} rontometers", "Quantity.Unit.Distance.Rontometers"),
        new(SI<Distance>.Yocto, "{0} ym", "1 yoctometer", "{0} yoctometers", "Quantity.Unit.Distance.Yoctometers"),
        new(SI<Distance>.Zepto, "{0} zm", "1 zeptometer", "{0} zeptometers", "Quantity.Unit.Distance.Zeptometers"),
        new(SI<Distance>.Atto, "{0} am", "1 attometer", "{0} attometers", "Quantity.Unit.Distance.Attometers"),
        new(SI<Distance>.Femto, "{0} fm", "1 femtometer", "{0} femtometers", "Quantity.Unit.Distance.Femtometers"),
        new(SI<Distance>.Pico, "{0} pm", "1 picometer", "{0} picometers", "Quantity.Unit.Distance.Picometers"),
        new(SI<Distance>.Nano, "{0} nm", "1 nanometer", "{0} nanometers", "Quantity.Unit.Distance.Nanometers"),
        new(SI<Distance>.Micro, "{0} µm", "1 micrometer", "{0} micrometers", "Quantity.Unit.Distance.Micrometers"),
        new(SI<Distance>.Centi, "{0} cm", "1 centimeter", "{0} centimeters", "Quantity.Unit.Distance.Centimeters"),
        new(SI<Distance>.Deci, "{0} dm", "1 decimeter", "{0} decimeters", "Quantity.Unit.Distance.Decimeters"),
        new(SI<Distance>.Deca, "{0} dam", "1 decameter", "{0} decameters", "Quantity.Unit.Distance.Decameters"),
        new(SI<Distance>.Hecto, "{0} hm", "1 hectometer", "{0} hectometers", "Quantity.Unit.Distance.Hectometers"),
        new(SI<Distance>.Milli, "{0} mm", "1 millimeter", "{0} millimeters", "Quantity.Unit.Distance.Millimeters"),
        new(SI<Distance>.Kilo, "{0} km", "1 kilometer", "{0} kilometers", "Quantity.Unit.Distance.Kilometers"),
        new(SI<Distance>.Mega, "{0} Mm", "1 megameter", "{0} megameters", "Quantity.Unit.Distance.Megameters"),
        new(SI<Distance>.Giga, "{0} Gm", "1 gigameter", "{0} gigameters", "Quantity.Unit.Distance.Gigameters"),
        new(SI<Distance>.Tera, "{0} Tm", "1 terameter", "{0} terameters", "Quantity.Unit.Distance.Terameters"),
        new(SI<Distance>.Peta, "{0} Pm", "1 petameter", "{0} petameters", "Quantity.Unit.Distance.Petameters"),
        new(SI<Distance>.Exa, "{0} Em", "1 exameter", "{0} exameters", "Quantity.Unit.Distance.Exameters"),
        new(SI<Distance>.Zetta, "{0} Zm", "1 zettameter", "{0} zettameters", "Quantity.Unit.Distance.Zettameters"),
        new(SI<Distance>.Yotta, "{0} Ym", "1 yottameter", "{0} yottameters", "Quantity.Unit.Distance.Yottameters"),
        new(SI<Distance>.Ronna, "{0} Rm", "1 ronnameter", "{0} ronnameters", "Quantity.Unit.Distance.Ronnameters"),
        new(SI<Distance>.Quetta, "{0} Qm", "1 quettameter", "{0} quettameters", "Quantity.Unit.Distance.Quettameters")
    ];

    /// <inheritdoc/>
    public static IEnumerable<QuantityFormatTestData<Distance>> CompoundFormatInfoDataTuples =>
    [
        new(Distance.FeetInches, 0d, ""),
        new(Distance.FeetInches, .0254d, "1\""),
        new(Distance.FeetInches, .3048d, "1'"),
        new(Distance.FeetInches, .3302d, "1'1\""),
    ];
}
