using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Elements.Quantity.Test.Mocks;
using System.Text.RegularExpressions;

namespace Elements.Quantity.Test.Core;

[TestClass]
[ExcludeFromCodeCoverage]
public partial class QuantityHelperTests
{
    internal static IEnumerable<object[]> ValueFormatArgs => SharedArgsProvider.ValidFormatArgs
        .Concat(SharedArgsProvider.InvalidFormatArgs)
        .Select(argsData => new[] { argsData.formatNum, MockUnitPrefixRegex().Replace(argsData.expectedValue, "m") });

    /// <summary>
    /// Tests that the <see cref="QuantityHelper.FormatAs"/> method correctly formats a quantity using a valid string
    /// format and unit.
    /// </summary>
    /// <param name="formatNum">The string format to apply to the quantity's numeric value.</param>
    /// <param name="expectedValue">The expected formatted string result.</param>
    [TestMethod]
    [DynamicData(nameof(ValueFormatArgs))]
    public void QuantityHelperFormatAs_ProvidedStringFormatAndUnitAreValid_FormatsUnitNumberInFormat(string formatNum, string expectedValue)
    {
        var unit = Distance.Meter;
        var quantity = new Distance(unit.Ratio);

        
        var formattedValue = quantity.FormatAs(unit, formatNum);
        Assert.AreEqual(expectedValue, formattedValue);
    }

    /// <summary>
    /// Tests that the <see cref="QuantityHelper.FormatAs"/> method correctly formats a unit number when
    /// provided with a valid string format and unit name.
    /// </summary>
    /// <remarks>In the future, all valid unit name strings will be collected to test against. For now, only <c>" m"</c>
    /// is used.</remarks>
    /// <param name="formatNum">The string format to apply to the quantity's numeric value.</param>
    /// <param name="expectedValue">The expected formatted string result.</param>
    [TestMethod]
    [DynamicData(nameof(ValueFormatArgs))]
    public void QuantityHelperFormatAs_ProvidedStringFormatAndUnitNameAreValid_FormatsUnitNumberInFormat(string formatNum, string expectedValue)
    {
        var unit = Distance.Meter;
        var quantity = new Distance(unit.Ratio);

        var formattedValue = quantity.FormatAs(" m", formatNum);
        Assert.AreEqual(expectedValue, formattedValue);
    }

    /// <summary>
    /// Verifies that the <see cref="QuantityHelper.FormatAs"/> method throws a  <see
    /// cref="UnitNameNotFoundException"/> when an invalid unit name is provided.
    /// </summary>
    [TestMethod]
    public void QuantityHelperFormatAs_ProvidedUnitNameIsInvalid_ThrowsException()
    {
        var quantity = new Distance(Distance.Meter.Ratio);
        Assert.ThrowsExactly<UnitNameNotFoundException>(() => quantity.FormatAs("mockunit", "#"));
    }

    [GeneratedRegex("u$", RegexOptions.Compiled)]
    private static partial Regex MockUnitPrefixRegex();
}
