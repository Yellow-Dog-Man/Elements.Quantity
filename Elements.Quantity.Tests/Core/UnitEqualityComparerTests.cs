using Elements.Quantity.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity.Test.Core;

[TestClass]
[ExcludeFromCodeCoverage]
public sealed class UnitEqualityComparerTests
{
    private static readonly UnitEqualityComparer _comparer = UnitEqualityComparer.Instance;

    private static IEnumerable<IUnit> _differntUnitTypes =>
    [
        MockProvider.MockUnit,
        new MockUnit()
    ];

    /// <summary>
    /// Verifies that <see cref="UnitEqualityComparer.Equals(IUnit?, IUnit?)"/> correctly determines equality when
    /// both units are different references but have equal properties.
    /// </summary>
    [TestMethod]
    public void CompareEquality_UnitsAreEqual_ReturnsTrue()
    {
        var mockUnitA = MockProvider.MockUnit;
        Unit<MockQuantity> mockUnitB = new(mockUnitA.Ratio, [], MockProvider.MockUnitShortNames, MockProvider.MockUnitLongNames);

        var actualResult = _comparer.Equals(mockUnitA, mockUnitB);
        Assert.IsTrue(actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="UnitEqualityComparer.Equals(IUnit?, IUnit?)"/> correctly determines equality when
    /// both units are the same reference.
    /// </summary>
    [TestMethod]
    public void CompareEquality_UnitsAreSameReferences_ReturnsTrue()
    {
        var actualResult = _comparer.Equals(MockProvider.MockUnit, MockProvider.MockUnit);
        Assert.IsTrue(actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="UnitEqualityComparer.Equals(IUnit?, IUnit?)"/> correctly determines equality when
    /// both units are null.
    /// </summary>
    /// <param name="leftIsNull">Indicates whether the left unit is null.</param>
    /// <param name="rightIsNull">Indicates whether the right unit is null.</param>
    /// <param name="expectedResult">The expected result of the equality comparison.</param>
    /// <param name="failureMessage">The message to display if the test fails.</param>
    [TestMethod(UnfoldingStrategy = TestDataSourceUnfoldingStrategy.Unfold)]
    [DataRow(true, true, true, "Two null params should be considered equal.")]
    [DataRow(true, false, false, "A null left param and non-null right param cannot be considered equal.")]
    [DataRow(false, true, false, "A non-null left param and null right param cannot be considered equal.")]
    public void CompareEquality_NullParams_ReturnsExpectedResult(bool leftIsNull, bool rightIsNull, bool expectedResult, string failureMessage)
    {
        IUnit? left = leftIsNull ? null : MockProvider.MockUnit;
        IUnit? right = rightIsNull ? null : MockProvider.MockUnit;
        var actualResult = _comparer.Equals(left, right);
        Assert.AreEqual(expectedResult, actualResult, failureMessage);
    }

    /// <summary>
    /// Verifies that <see cref="UnitEqualityComparer.Equals(IUnit?, IUnit?)"/> correctly determines inequality.
    /// </summary>
    [TestMethod]
    public void CompareEquality_UnitsAreDifferent_ReturnsFalse()
    {
        var mockUnitA = MockProvider.MockUnit;
        Unit<MockQuantity> mockUnitB = new(3.0, null, ["m2"], ["mock2"]);
        var actualResult = _comparer.Equals(mockUnitA, mockUnitB);
        Assert.IsFalse(actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="UnitEqualityComparer.GetHashCode(IUnit)"/> returns the same hash code as the one from
    /// <see cref="IUnit.UnitKey"/>.
    /// </summary>
    /// <param name="unit">The unit to get the hash code for.</param>
    [TestMethod(UnfoldingStrategy = TestDataSourceUnfoldingStrategy.Unfold)]
    [DynamicData(nameof(_differntUnitTypes))]
    public void GetHashCode_SameUnits_ReturnsSameHashCodeValue(IUnit unit)
    {
        var expectedHashCode = HashCode.Combine(unit.UnitKey, unit.Ratio);
        var actualHashCode = _comparer.GetHashCode(unit);

        Assert.AreEqual(expectedHashCode, actualHashCode);
    }
}

/// <summary>
/// A mock implementation of the <see cref="IUnit"/> interface for testing purposes. <see cref="UnitKey"/>
/// and <see cref="GetHashCode()"/> methods are overridden to provide a unique implementation that should
/// be ignored by the comparer.
/// </summary>
file sealed class MockUnit : IUnit
{
    public double Ratio => 2.0d;

    public Type ValueType => throw new NotImplementedException();

    public string DefaultShortUnitName => throw new NotImplementedException();

    public string DefaultLongUnitNamePluralForm => throw new NotImplementedException();

    public string DefaultLongUnitNameSingularForm => throw new NotImplementedException();

    public string UnitKey => "MockUnitKey";

    public int CompareTo(IUnit? other) => throw new NotImplementedException();

    public ICollection<string> GetUnitNames() => throw new NotImplementedException();

    public override int GetHashCode() => UnitKey.GetHashCode() + 1;

    public override string ToString() => "MockUnit";
}
