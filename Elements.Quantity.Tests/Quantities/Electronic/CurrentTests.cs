using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Electronic;

using CurrentTestData = (Unit<Current> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class CurrentTests
{
    internal static CurrentTestData[] CurrentTestDataTuples
    {
        get => new CurrentTestData[]
        {
            new (Current.Ampere, "{0} A", "1 ampere", "{0} amperes"),
            new (SI<Current>.Quecto, "{0} qA", "1 quectoampere", "{0} quectoamperes"),
            new (SI<Current>.Ronto, "{0} rA", "1 rontoampere", "{0} rontoamperes"),
            new (SI<Current>.Yocto, "{0} yA", "1 yoctoampere", "{0} yoctoamperes"),
            new (SI<Current>.Zepto, "{0} zA", "1 zeptoampere", "{0} zeptoamperes"),
            new (SI<Current>.Atto, "{0} aA", "1 attoampere", "{0} attoamperes"),
            new (SI<Current>.Femto, "{0} fA", "1 femtoampere", "{0} femtoamperes"),
            new (SI<Current>.Pico, "{0} pA", "1 picoampere", "{0} picoamperes"),
            new (SI<Current>.Nano, "{0} nA", "1 nanoampere", "{0} nanoamperes"),
            new (SI<Current>.Micro, "{0} µA", "1 microampere", "{0} microamperes"),
            new (SI<Current>.Milli, "{0} mA", "1 milliampere", "{0} milliamperes"),
            new (SI<Current>.Kilo, "{0} kA", "1 kiloampere", "{0} kiloamperes"),
            new (SI<Current>.Mega, "{0} MA", "1 megaampere", "{0} megaamperes"),
            new (SI<Current>.Giga, "{0} GA", "1 gigaampere", "{0} gigaamperes"),
            new (SI<Current>.Tera, "{0} TA", "1 teraampere", "{0} teraamperes"),
            new (SI<Current>.Peta, "{0} PA", "1 petaampere", "{0} petaamperes"),
            new (SI<Current>.Exa, "{0} EA", "1 exaampere", "{0} exaamperes"),
            new (SI<Current>.Zetta, "{0} ZA", "1 zettaampere", "{0} zettaamperes"),
            new (SI<Current>.Yotta, "{0} YA", "1 yottaampere", "{0} yottaamperes"),
            new (SI<Current>.Ronna, "{0} RA", "1 ronnaampere", "{0} ronnaamperes"),
            new (SI<Current>.Quetta, "{0} QA", "1 quettaampere", "{0} quettaamperes")
        };
    }

    internal static IEnumerable<object[]> CurrentShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            CurrentTestDataTuples.Select(currentUnitArgs => new object[] {
                currentUnitArgs.unit, numValue, string.Format(currentUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> CurrentLongNameSingularFormArgs
    {
        get => CurrentTestDataTuples.Select(currentUnitArgs => new object[] {
            currentUnitArgs.unit, currentUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> CurrentLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            CurrentTestDataTuples.Select(currentUnitArgs => new object[] {
                currentUnitArgs.unit, numValue, string.Format(currentUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    [TestMethod]
    [DynamicData(nameof(CurrentShortNameArgs))]
    public void CurrentUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Current> currentUnit, double currentValue, string expectedStr)
    {
        var current = new Current(currentValue * currentUnit.Ratio);
        var resultStr = current.FormatAs(currentUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(CurrentLongNameSingularFormArgs))]
    public void CurrentUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Current> currentUnit, string expectedStr)
    {
        var current = new Current(currentUnit.Ratio);
        var resultStr = current.FormatAs(currentUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(CurrentLongNamePluralFormArgs))]
    public void CurrentUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Current> currentUnit, double currentValue, string expectedStr)
    {
        var current = new Current(currentValue * currentUnit.Ratio);
        var resultStr = current.FormatAs(currentUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }
}
