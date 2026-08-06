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

    internal static IEnumerable<double> Numbers => DataProvider.UnitQuantityShortNameNumberValues;

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

    /// <summary>
    /// Verifies that the default unit definition for a quantity returns the expected unit.
    /// </summary>
    [TestMethod]
    public void DefaultUnitDefinition_WhenAccessed_ReturnsExpectedUnit()
    {
        Assert.AreSame(MockProvider.MockUnit, MockQuantity.DefaultUnitDefinition);
    }

    /// <summary>
    /// Verifies that the default unit on an instance of a quantity returns the expected unit.
    /// </summary>
    /// <remarks>
    /// This property is currently marked as obsolete. Once <see cref="IQuantity{TQuantity}.DefaultUnit"/> is removed,
    /// this test should be removed as well.
    /// </remarks>
    [TestMethod]
    public void DefaultUnitOnInstance_WhenAccessed_ReturnsExpectedUnit()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        var actualDefaultUnit = default(MockQuantity).DefaultUnit;
#pragma warning restore CS0618 // Type or member is obsolete

        Assert.AreSame(MockProvider.MockUnit, actualDefaultUnit);
    }

    /// <summary>
    /// Verifies that <see cref="Unit{T}.Parse(string, Unit{T})"/> can parse a number only string into a quantity using the
    /// default unit's ratio.
    /// </summary>
    /// <param name="number">The number to parse.</param>
    [TestMethod]
    [DynamicData(nameof(Numbers))]
    public void ParseString_NumberOnlyString_ParsesAsDefaultUnit(double number)
    {
        var expectedValue = new MockQuantity(number * MockProvider.MockUnit.Ratio);
        var actualValue = Unit<MockQuantity>.Parse(number.ToString());

        Assert.AreEqual(expectedValue, actualValue);
    }

    /// <summary>
    /// Verifies that <see cref="Unit{T}.TryParse(string, out T, Unit{T})"/> can parse a number only string into a quantity
    /// using the default unit's ratio, returning <c>true</c> upon success.
    /// </summary>
    /// <param name="number">The number to parse.</param>
    [TestMethod]
    [DynamicData(nameof(Numbers))]
    public void TryParseString_NumberOnlyString_ParsesAsDefaultUnit(double number)
    {
        var expectedValue = new MockQuantity(number * MockProvider.MockUnit.Ratio);
        var hasParsed = Unit<MockQuantity>.TryParse(number.ToString(), out MockQuantity actualValue);

        Assert.IsTrue(hasParsed);
        Assert.AreEqual(expectedValue, actualValue);
    }
}
