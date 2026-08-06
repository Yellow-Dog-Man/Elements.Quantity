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

    /// <summary>
    /// Verifies that <see cref="Unit{T}.Equals(Unit{T})"/> returns true when two units have equal values.
    /// </summary>
    [TestMethod]
    public void TypedEquals_ObjectsHaveEqualValues_ReturnsTrue()
    {
        var mockUnitB = new Unit<MockQuantity>(MockProvider.MockUnitBaseRatio, null, MockProvider.MockUnitShortNames, MockProvider.MockUnitLongNames);

        var actualResult = MockProvider.MockUnit.Equals(mockUnitB);
        Assert.IsTrue(actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="Unit{T}.Equals(Unit{T})"/> returns false when two units have different values.
    /// </summary>
    [TestMethod]
    public void TypedEquals_ObjectsHaveDifferentValues_ReturnsFalse()
    {
        var mockUnitB = new Unit<MockQuantity>(3.0, null, ["M2"], ["MockTwo"]);

        var actualResult = MockProvider.MockUnit.Equals(mockUnitB);
        Assert.IsFalse(actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="Unit{T}.Equals(Unit{T})"/> returns false when the other unit is null.
    /// </summary>
    [TestMethod]
    public void TypedEquals_OtherObjectIsNull_ReturnsFalse()
    {
        IUnit? mockUnitB = null;

        var actualResult = MockProvider.MockUnit.Equals(mockUnitB);
        Assert.IsFalse(actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="Unit{T}.Equals(object)"/> returns true when two objects have equal values.
    /// </summary>
    [TestMethod]
    public void ObjectEquals_ObjectHasEqualValues_ReturnsTrue()
    {
        object otherObject = new Unit<MockQuantity>(MockProvider.MockUnitBaseRatio, null, MockProvider.MockUnitShortNames, MockProvider.MockUnitLongNames);

        var actualResult = MockProvider.MockUnit.Equals(otherObject);
        Assert.IsTrue(actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="Unit{T}.Equals(object)"/> returns false when two objects have different values.
    /// </summary>
    [TestMethod]
    public void ObjectEquals_ObjectHasDifferentValues_ReturnsFalse()
    {
        object otherObject = new Unit<MockQuantity>(3.0, null, ["M2"], ["MockTwo"]);

        var actualResult = MockProvider.MockUnit.Equals(otherObject);
        Assert.IsFalse(actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="Unit{T}.Equals(object)"/> returns false when the other object is null.
    /// </summary>
    [TestMethod]
    public void ObjectEquals_ObjectIsNull_ReturnsFalse()
    {
        object? otherObject = null;

        var actualResult = MockProvider.MockUnit.Equals(otherObject);
        Assert.IsFalse(actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="Unit{T}.Equals(object)"/> returns false when the other object is a different type.
    /// </summary>
    [TestMethod]
    public void ObjectEquals_ObjectIsDifferentType_ReturnsFalse()
    {
        var otherObject = new object();

        var actualResult = MockProvider.MockUnit.Equals(otherObject);
        Assert.IsFalse(actualResult);
    }

    /// <summary>
    /// Verifies that the equality operator (==) returns true when two units have equal values.
    /// </summary>
    [TestMethod]
    public void EqualityOperator_OperandsHaveEqualValues_ReturnsTrue()
    {
        var mockUnitA = MockProvider.MockUnit;
        var mockUnitB = new Unit<MockQuantity>(MockProvider.MockUnitBaseRatio, null, MockProvider.MockUnitShortNames, MockProvider.MockUnitLongNames);

        var actualResult = mockUnitA == mockUnitB;
        Assert.IsTrue(actualResult);
    }

    /// <summary>
    /// Verifies that the equality operator (==) returns false when two units have different values.
    /// </summary>
    [TestMethod]
    public void EqualityOperator_OperandsHaveDifferentValues_ReturnsFalse()
    {
        var mockUnitA = MockProvider.MockUnit;
        var mockUnitB = new Unit<MockQuantity>(3.0, null, ["M2"], ["MockTwo"]);

        var actualResult = mockUnitA == mockUnitB;
        Assert.IsFalse(actualResult);
    }

    /// <summary>
    /// Verifies that the equality operator (==) returns the expected value when one or both operands are null.
    /// </summary>
    /// <param name="leftIsNull">Indicates whether the left operand is null.</param>
    /// <param name="rightIsNull">Indicates whether the right operand is null.</param>
    /// <param name="expectedResult">The expected result of the equality comparison.</param>
    /// <param name="failureMessage">The message to display if the test fails.</param>
    [TestMethod(UnfoldingStrategy = TestDataSourceUnfoldingStrategy.Unfold)]
    [DataRow(true, true, true, "Two null operands should be considered equal.")]
    [DataRow(true, false, false, "A null left operand and non-null right operand cannot be considered equal.")]
    [DataRow(false, true, false, "A non-null left operand and null right operand cannot be considered equal.")]
    public void EqualityOperator_NullOperands_ReturnsExpectedResult(bool leftIsNull, bool rightIsNull, bool expectedResult, string failureMessage)
    {
        Unit<MockQuantity>? left = leftIsNull ? null : MockProvider.MockUnit;
        Unit<MockQuantity>? right = rightIsNull ? null : MockProvider.MockUnit;

        var actualResult = left == right;
        Assert.AreEqual(expectedResult, actualResult, failureMessage);
    }

    /// <summary>
    /// Verifies that the inequality operator (!=) returns false when two units have equal values.
    /// </summary>
    [TestMethod]
    public void InequalityOperator_OperandsHaveEqualValues_ReturnsFalse()
    {
        var mockUnitA = MockProvider.MockUnit;
        var mockUnitB = new Unit<MockQuantity>(MockProvider.MockUnitBaseRatio, null, MockProvider.MockUnitShortNames, MockProvider.MockUnitLongNames);

        var actualResult = mockUnitA != mockUnitB;
        Assert.IsFalse(actualResult);
    }

    /// <summary>
    /// Verifies that the inequality operator (!=) returns true when two units have different values.
    /// </summary>
    [TestMethod]
    public void InequalityOperator_OperandsHaveDifferentValues_ReturnsTrue()
    {
        var mockUnitA = MockProvider.MockUnit;
        var mockUnitB = new Unit<MockQuantity>(3.0, null, ["M2"], ["MockTwo"]);

        var actualResult = mockUnitA != mockUnitB;
        Assert.IsTrue(actualResult);
    }

    /// <summary>
    /// Verifies that the inequality operator (!=) returns the expected value when one or both operands are null.
    /// </summary>
    /// <param name="leftIsNull">Indicates whether the left operand is null.</param>
    /// <param name="rightIsNull">Indicates whether the right operand is null.</param>
    /// <param name="expectedResult">The expected result of the inequality comparison.</param>
    /// <param name="failureMessage">The message to display if the test fails.</param>
    [TestMethod(UnfoldingStrategy = TestDataSourceUnfoldingStrategy.Unfold)]
    [DataRow(true, true, false, "Two null operands cannot be considered unequal.")]
    [DataRow(true, false, true, "A null left operand and non-null right operand should be considered unequal.")]
    [DataRow(false, true, true, "A non-null left operand and null right operand should be considered unequal.")]
    public void InequalityOperator_NullOperands_ReturnsExpectedResult(bool leftIsNull, bool rightIsNull, bool expectedResult, string failureMessage)
    {
        Unit<MockQuantity>? left = leftIsNull ? null : MockProvider.MockUnit;
        Unit<MockQuantity>? right = rightIsNull ? null : MockProvider.MockUnit;

        var actualResult = left != right;
        Assert.AreEqual(expectedResult, actualResult, failureMessage);
    }

    /// <summary>
    /// Verifies that <see cref="Unit{T}.GetHashCode()"/> returns the expected hash code based on <see cref="Unit{T}.UnitKey"/>
    /// and <see cref="Unit{T}.Ratio"/>.
    /// </summary>
    [TestMethod]
    public void GetHashCode_Call_ReturnsExpectedHashCode()
    {
        var mockUnit = MockProvider.MockUnit;

        var expectedResult = HashCode.Combine(mockUnit.UnitKey, mockUnit.Ratio);
        var actualResult = mockUnit.GetHashCode();

        Assert.AreEqual(expectedResult, actualResult);
    }
}
