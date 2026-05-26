using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Electronic;

using CurrentTestData = QuantityTestData<Current>;
using CurrentUnitKeyTestData = (Unit<Current> unit, string unitKey);

[TestClass]
[ExcludeFromCodeCoverage]
public class CurrentTests
{
    /// <summary>
    /// An array of test data tuples representing different current units and their display formats. Each
    /// element in the array contains information about a current unit, the short name, the singular
    /// long name, plural long name, and unit key.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static CurrentTestData[] CurrentTestDataTuples =>
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

    /// <summary>
    /// A collection of test arguments for verifying the unit keys for current units.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<CurrentUnitKeyTestData> CurrentUnitKeyArgs =>
        CurrentTestDataTuples.Select(unitArgs => new CurrentUnitKeyTestData(unitArgs.unit, unitArgs.unitKey));

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

    /// <summary>
    /// Verifies that getting a unit key from an Current unit will return the expected unit key.
    /// </summary>
    /// <param name="currentUnit">The current unit to use when getting the unit key.</param>
    /// <param name="expectedUnitKey">The expected unit key that this unit should return.</param>
    [TestMethod]
    [DynamicData(nameof(CurrentUnitKeyArgs))]
    public void GetCurrentUnitKey_ValidUnit_ReturnsUnitKey(Unit<Current> currentUnit, string expectedUnitKey)
    {
        Assert.AreEqual(expectedUnitKey, currentUnit.UnitKey);
    }
}
