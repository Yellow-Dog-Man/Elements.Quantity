using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Elements.Quantity.Test.Mocks;
using System.Linq;

namespace Elements.Quantity.Test.Core;

[TestClass]
[ExcludeFromCodeCoverage]
public class UnitTests
{
    internal static IEnumerable<object[]> ValueFormatArgs => SharedArgsProvider.ValidFormatArgs
        .Concat(SharedArgsProvider.InvalidFormatArgs)
        .Select(argsData => new [] { argsData.formatNum, argsData.expectedValue });

    /// <summary>
    /// Tests that the <see cref="Unit{T}.FormatAs(T, string, bool, string)"/> method correctly formats a
    /// unit's value using the specified string format.
    /// </summary>
    /// <param name="formatNum">The string format to apply to the unit's value.</param>
    /// <param name="expectedValue">The expected formatted value of the unit.</param>
    [TestMethod]
    [DynamicData(nameof(ValueFormatArgs))]
    public void UnitFormatAs_ProvidedStringFormatIsValid_FormatsUnitNumberInFormat(string formatNum, string expectedValue)
    {
        var unit = MockProvider.MockUnit;
        var quantity = new MockQuantity(unit.Ratio);

        var formattedValue = unit.FormatAs(quantity, formatNum);
        Assert.AreEqual(expectedValue, formattedValue);
    }
}
