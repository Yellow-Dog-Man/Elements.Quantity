using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Elements.Quantity.Test.Quantities.Basic;

using TorqueTestData = (Unit<Torque> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class TorqueTests
{
    /// <summary>
    /// An array of test data tuples representing different torque units and their display formats. Each
    /// element in the array contains information about a torque unit, the short name, the singular
    /// long name, and plural long name.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static TorqueTestData[] TorqueTestDataTuples
    {
        get =>
        [
            new (Torque.NewtonMeter, "{0} N m", "1 newton meter", "{0} newton meters"),
            new (Torque.PoundFoot, "{0} lb·ft", "1 pound-foot", "{0} pound-feet")
        ];
    }

    /// <summary>
    /// A collection of test data containing the torque unit, the numeric value, and the expected
    /// formatted short name.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> TorqueShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            TorqueTestDataTuples.Select(torqueUnitArgs => new object[] {
                torqueUnitArgs.unit, numValue, string.Format(torqueUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// A collection of test data containing the torque unit and the expected formatted long
    /// name for singluar values.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> TorqueLongNameSingularFormArgs
    {
        get => TorqueTestDataTuples.Select(torqueUnitArgs => new object[] {
            torqueUnitArgs.unit, torqueUnitArgs.longNameSingle
        });
    }

    /// <summary>
    /// A collection of test data containing the torque unit, the numeric value, and the expected
    /// formatted long name for plural values.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static IEnumerable<object[]> TorqueLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            TorqueTestDataTuples.Select(torqueUnitArgs => new object[] {
                torqueUnitArgs.unit, numValue, string.Format(torqueUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    /// <summary>
    /// Verifies that formatting a Torque quantity using the specified unit and the default short name produces the
    /// expected string representation.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the unit's default short name
    /// when formatting a torque value. It uses dynamic data to validate multiple unit and string
    /// combinations.
    /// </remarks>
    /// <param name="torqueUnit">The torque unit to use when formatting the value.</param>
    /// <param name="torqueValue">The numeric value to be formatted.</param>
    /// <param name="expectedStr">The expected string result when formatting the torque value with the specified unit's default short name.</param>
    [TestMethod]
    [DynamicData(nameof(TorqueShortNameArgs))]
    public void TorqueUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Torque> torqueUnit, double torqueValue, string expectedStr)
    {
        var torque = new Torque(torqueValue * torqueUnit.Ratio);
        var resultStr = torque.FormatAs(torqueUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that formatting a torque value using the specified unit with the long name option produces
    /// the expected singular long name string for singular values.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the singular form of the
    /// unit's long name when formatting torque values.
    /// </remarks>
    /// <param name="torqueUnit">The torque unit to use when formatting the value.</param>
    /// <param name="expectedStr">The expected string result when formatting the torque value with the long name option.</param>
    [TestMethod]
    [DynamicData(nameof(TorqueLongNameSingularFormArgs))]
    public void TorqueUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Torque> torqueUnit, string expectedStr)
    {
        var torque = new Torque(torqueUnit.Ratio);
        var resultStr = torque.FormatAs(torqueUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    /// <summary>
    /// Verifies that formatting a torque value using the specified unit with the long name option produces
    /// the expected plural long name string for plural values.
    /// </summary>
    /// <remarks>
    /// This test ensures that the FormatAs method correctly applies the  plural form of the
    /// unit's long name when formatting torque values.
    /// </remarks>
    /// <param name="torqueUnit">The torque unit to use when formatting the value.</param>
    /// <param name="torqueValue">The numeric value to be formatted.</param>
    /// <param name="expectedStr">The expected string result when formatting the torque value with the long name option.</param>
    [TestMethod]
    [DynamicData(nameof(TorqueLongNamePluralFormArgs))]
    public void TorqueUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Torque> torqueUnit, double torqueValue, string expectedStr)
    {
        var torque = new Torque(torqueValue * torqueUnit.Ratio);
        var resultStr = torque.FormatAs(torqueUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }
}
