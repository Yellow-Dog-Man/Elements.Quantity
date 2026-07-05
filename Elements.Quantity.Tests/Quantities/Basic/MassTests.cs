using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public class MassTests : BaseQuantityTests<MassTests, Mass>, IQuantityTestData<Mass>
{
    /// <inheritdoc/>
    public static QuantityTestData<Mass>[] TestDataTuples =>
    [
        new(Mass.Gram, "{0} g", "1 gram", "{0} grams", "Quantity.Unit.Mass.Grams"),
#pragma warning disable CS0618 // Type or member is obsolete
        new(Mass.Ton, "{0} t", "1 tonne", "{0} tonnes", "Quantity.Unit.Mass.Tonnes"),
#pragma warning restore CS0618 // Type or member is obsolete
        new(Mass.Tonne, "{0} t", "1 tonne", "{0} tonnes", "Quantity.Unit.Mass.Tonnes"),
        new(Mass.Grain, "{0} gr", "1 grain", "{0} grains", "Quantity.Unit.Mass.Grains"),
        new(Mass.Drachm, "{0} dr", "1 drachm", "{0} drachms", "Quantity.Unit.Mass.Drachms"),
        new(Mass.Ounce, "{0} oz", "1 ounce", "{0} ounces", "Quantity.Unit.Mass.Ounces"),
        new(Mass.Pound, "{0} lb", "1 pound", "{0} pounds", "Quantity.Unit.Mass.Pounds"),
        new(Mass.Stone, "{0} st", "1 stone", "{0} stones", "Quantity.Unit.Mass.Stones"),
        new(Mass.Quarter, "{0} qr", "1 quarter", "{0} quarters", "Quantity.Unit.Mass.Quarters"),
        new(Mass.HundredWeight, "{0} cwt", "1 hundredweight", "{0} hundredweights", "Quantity.Unit.Mass.Hundredweights"),
        new(Mass.ImperialTon, "{0} LT", "1 imperial ton", "{0} imperial tons", "Quantity.Unit.Mass.ImperialTons"),
        new(Mass.ShortTon, "{0} tn", "1 ton", "{0} tons", "Quantity.Unit.Mass.Tons"),
        new(Mass.Slug, "{0} slug", "1 slug", "{0} slugs", "Quantity.Unit.Mass.Slugs"),
        new(SI<Mass>.Quecto, "{0} qg", "1 quectogram", "{0} quectograms", "Quantity.Unit.Mass.Quectograms"),
        new(SI<Mass>.Ronto, "{0} rg", "1 rontogram", "{0} rontograms", "Quantity.Unit.Mass.Rontograms"),
        new(SI<Mass>.Yocto, "{0} yg", "1 yoctogram", "{0} yoctograms", "Quantity.Unit.Mass.Yoctograms"),
        new(SI<Mass>.Zepto, "{0} zg", "1 zeptogram", "{0} zeptograms", "Quantity.Unit.Mass.Zeptograms"),
        new(SI<Mass>.Atto, "{0} ag", "1 attogram", "{0} attograms", "Quantity.Unit.Mass.Attograms"),
        new(SI<Mass>.Femto, "{0} fg", "1 femtogram", "{0} femtograms", "Quantity.Unit.Mass.Femtograms"),
        new(SI<Mass>.Pico, "{0} pg", "1 picogram", "{0} picograms", "Quantity.Unit.Mass.Picograms"),
        new(SI<Mass>.Nano, "{0} ng", "1 nanogram", "{0} nanograms", "Quantity.Unit.Mass.Nanograms"),
        new(SI<Mass>.Micro, "{0} µg", "1 microgram", "{0} micrograms", "Quantity.Unit.Mass.Micrograms"),
        new(SI<Mass>.Centi, "{0} cg", "1 centigram", "{0} centigrams", "Quantity.Unit.Mass.Centigrams"),
        new(SI<Mass>.Deci, "{0} dg", "1 decigram", "{0} decigrams", "Quantity.Unit.Mass.Decigrams"),
        new(SI<Mass>.Deca, "{0} dag", "1 decagram", "{0} decagrams", "Quantity.Unit.Mass.Decagrams"),
        new(SI<Mass>.Hecto, "{0} hg", "1 hectogram", "{0} hectograms", "Quantity.Unit.Mass.Hectograms"),
        new(SI<Mass>.Milli, "{0} mg", "1 milligram", "{0} milligrams", "Quantity.Unit.Mass.Milligrams"),
        new(SI<Mass>.Kilo, "{0} kg", "1 kilogram", "{0} kilograms", "Quantity.Unit.Mass.Kilograms"),
        new(SI<Mass>.Mega, "{0} Mg", "1 megagram", "{0} megagrams", "Quantity.Unit.Mass.Megagrams"),
        new(SI<Mass>.Giga, "{0} Gg", "1 gigagram", "{0} gigagrams", "Quantity.Unit.Mass.Gigagrams"),
        new(SI<Mass>.Tera, "{0} Tg", "1 teragram", "{0} teragrams", "Quantity.Unit.Mass.Teragrams"),
        new(SI<Mass>.Peta, "{0} Pg", "1 petagram", "{0} petagrams", "Quantity.Unit.Mass.Petagrams"),
        new(SI<Mass>.Exa, "{0} Eg", "1 exagram", "{0} exagrams", "Quantity.Unit.Mass.Exagrams"),
        new(SI<Mass>.Zetta, "{0} Zg", "1 zettagram", "{0} zettagrams", "Quantity.Unit.Mass.Zettagrams"),
        new(SI<Mass>.Yotta, "{0} Yg", "1 yottagram", "{0} yottagrams", "Quantity.Unit.Mass.Yottagrams"),
        new(SI<Mass>.Ronna, "{0} Rg", "1 ronnagram", "{0} ronnagrams", "Quantity.Unit.Mass.Ronnagrams"),
        new(SI<Mass>.Quetta, "{0} Qg", "1 quettagram", "{0} quettagrams", "Quantity.Unit.Mass.Quettagrams")
    ];

    /// <inheritdoc/>
    public static IEnumerable<QuantityFormatTestData<Mass>>? CompoundFormatInfoDataTuples => null;
}
