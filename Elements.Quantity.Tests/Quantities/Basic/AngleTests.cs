using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public sealed class AngleTests : BaseQuantityTests<AngleTests, Angle>, IQuantityTestData<Angle>
{
    /// <inheritdoc/>
    public static QuantityTestData<Angle>[] TestDataTuples =>
    [
        new(Angle.Radian, "{0} rad", "1 radian", "{0} radians", "Quantity.Unit.Angle.Radians"),
        new(Angle.Degree, "{0}°", "1 degree", "{0} degrees", "Quantity.Unit.Angle.Degrees"),
        new(Angle.ArcMinute, "{0}′", "1 arcminute", "{0} arcminutes", "Quantity.Unit.Angle.Arcminutes"),
        new(Angle.ArcSecond, "{0}″", "1 arcsecond", "{0} arcseconds", "Quantity.Unit.Angle.Arcseconds"),
        new(SI<Angle>.Quecto, "{0} qrad", "1 quectoradian", "{0} quectoradians", "Quantity.Unit.Angle.Quectoradians"),
        new(SI<Angle>.Ronto, "{0} rrad", "1 rontoradian", "{0} rontoradians", "Quantity.Unit.Angle.Rontoradians"),
        new(SI<Angle>.Yocto, "{0} yrad", "1 yoctoradian", "{0} yoctoradians", "Quantity.Unit.Angle.Yoctoradians"),
        new(SI<Angle>.Zepto, "{0} zrad", "1 zeptoradian", "{0} zeptoradians", "Quantity.Unit.Angle.Zeptoradians"),
        new(SI<Angle>.Atto, "{0} arad", "1 attoradian", "{0} attoradians", "Quantity.Unit.Angle.Attoradians"),
        new(SI<Angle>.Femto, "{0} frad", "1 femtoradian", "{0} femtoradians", "Quantity.Unit.Angle.Femtoradians"),
        new(SI<Angle>.Pico, "{0} prad", "1 picoradian", "{0} picoradians", "Quantity.Unit.Angle.Picoradians"),
        new(SI<Angle>.Nano, "{0} nrad", "1 nanoradian", "{0} nanoradians", "Quantity.Unit.Angle.Nanoradians"),
        new(SI<Angle>.Micro, "{0} µrad", "1 microradian", "{0} microradians", "Quantity.Unit.Angle.Microradians"),
        new(SI<Angle>.Centi, "{0} crad", "1 centiradian", "{0} centiradians", "Quantity.Unit.Angle.Centiradians"),
        new(SI<Angle>.Deci, "{0} drad", "1 deciradian", "{0} deciradians", "Quantity.Unit.Angle.Deciradians"),
        new(SI<Angle>.Deca, "{0} darad", "1 decaradian", "{0} decaradians", "Quantity.Unit.Angle.Decaradians"),
        new(SI<Angle>.Hecto, "{0} hrad", "1 hectoradian", "{0} hectoradians", "Quantity.Unit.Angle.Hectoradians"),
        new(SI<Angle>.Milli, "{0} mrad", "1 milliradian", "{0} milliradians", "Quantity.Unit.Angle.Milliradians"),
        new(SI<Angle>.Kilo, "{0} krad", "1 kiloradian", "{0} kiloradians", "Quantity.Unit.Angle.Kiloradians"),
        new(SI<Angle>.Mega, "{0} Mrad", "1 megaradian", "{0} megaradians", "Quantity.Unit.Angle.Megaradians"),
        new(SI<Angle>.Giga, "{0} Grad", "1 gigaradian", "{0} gigaradians", "Quantity.Unit.Angle.Gigaradians"),
        new(SI<Angle>.Tera, "{0} Trad", "1 teraradian", "{0} teraradians", "Quantity.Unit.Angle.Teraradians"),
        new(SI<Angle>.Peta, "{0} Prad", "1 petaradian", "{0} petaradians", "Quantity.Unit.Angle.Petaradians"),
        new(SI<Angle>.Exa, "{0} Erad", "1 exaradian", "{0} exaradians", "Quantity.Unit.Angle.Exaradians"),
        new(SI<Angle>.Zetta, "{0} Zrad", "1 zettaradian", "{0} zettaradians", "Quantity.Unit.Angle.Zettaradians"),
        new(SI<Angle>.Yotta, "{0} Yrad", "1 yottaradian", "{0} yottaradians", "Quantity.Unit.Angle.Yottaradians"),
        new(SI<Angle>.Ronna, "{0} Rrad", "1 ronnaradian", "{0} ronnaradians", "Quantity.Unit.Angle.Ronnaradians"),
        new(SI<Angle>.Quetta, "{0} Qrad", "1 quettaradian", "{0} quettaradians", "Quantity.Unit.Angle.Quettaradians")
    ];

    /// <inheritdoc/>
    public static IEnumerable<QuantityFormatTestData<Angle>> CompoundFormatInfoDataTuples =>
    [
        new(Angle.DegreeMinSec, 0d, ""),
        new(Angle.DegreeMinSec, 0.25d, "14°19′26″"),
        new(Angle.DegreeMinSec, 0.5d, "28°38′52″"),
        new(Angle.DegreeMinSec, 0.96d, "55°14″"),
        new(Angle.DegreeMinSec, 1d, "57°17′45″"),
        new(Angle.DegreeMinSec, 1.25d, "71°37′11″"),

        // Constructed using constants, to match the expected values from before #17
        new(Angle.DegreeMinSec, Math.PI/180d, "1°"),
        new(Angle.DegreeMinSec, Math.PI/180d + Math.PI/648000d, "1°1″"),
        new(Angle.DegreeMinSec, Math.PI/180d + Math.PI/10800d + Math.PI/648000d, "1°1′1″"),
    ];

    [DataRow(Math.PI / 2, 90d)]
    [DataRow(Math.PI / 4, 45d)]
    [DataRow(Math.PI, 180d)]
    [DataRow(Math.PI * 2, 360d)]
    [TestMethod]
    public void RadianToDegrees(double radians, double degrees)
    {
        var angle = new Angle(radians);

        Assert.AreEqual(degrees, angle.ConvertTo(Angle.Degree), 0.1);
    }

    [DataRow(90d, Math.PI / 2)]
    [DataRow(45d, Math.PI / 4)]
    [DataRow(180d, Math.PI)]
    [DataRow(360d, Math.PI * 2)]
    [TestMethod]
    public void DegreesToRadians(double degrees, double radians)
    {
        var angle = Angle.Degree.ConvertFrom(degrees);

        Assert.AreEqual(radians, angle.BaseValue, 0.0001);
    }
}
