using Elements.Quantity.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Elements.Quantity.Test.Core;

[TestClass]
[ExcludeFromCodeCoverage]
public sealed class UnitComparerTests
{
    private static readonly UnitComparer _comparer = UnitComparer.Instance;

    /// <summary>
    /// Verifies that <see cref="UnitComparer.Compare(IUnit?, IUnit?)"/> correctly returns 0
    /// when both units are equal in value.
    /// </summary>
    [TestMethod]
    public void Compare_UnitsAreEqual_ReturnsZero()
    {
        var mockUnitA = MockProvider.MockUnit;
        Unit<MockQuantity> mockUnitB = new(MockProvider.MockUnitBaseRatio, null, MockProvider.MockUnitShortNames, MockProvider.MockUnitLongNames);

        var actualResult = _comparer.Compare(mockUnitA, mockUnitB);
        Assert.AreEqual(0, actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="UnitComparer.Compare(IUnit?, IUnit?)"/> correctly returns 0
    /// when both units are the same reference.
    /// </summary>
    [TestMethod]
    public void Compare_UnitsAreSameReferences_ReturnsZero()
    {
        var actualResult = _comparer.Compare(MockProvider.MockUnit, MockProvider.MockUnit);
        Assert.AreEqual(0, actualResult);
    }

    /// <summary>
    /// Verifies that <see cref="UnitComparer.Compare(IUnit?, IUnit?)"/> correctly returns the
    /// expected value when one or both units are null.
    /// </summary>
    /// <param name="leftIsNull">Indicates whether the left unit is null.</param>
    /// <param name="rightIsNull">Indicates whether the right unit is null.</param>
    /// <param name="expectedResult">The expected result of the comparison.</param>
    /// <param name="failureMessage">The message to display if the test fails.</param>
    [TestMethod(UnfoldingStrategy = TestDataSourceUnfoldingStrategy.Unfold)]
    [DataRow(true, true, 0, "Two null params should return 0.")]
    [DataRow(true, false, -1, "A null left param and non-null right param should return -1.")]
    [DataRow(false, true, 1, "A non-null left param and null right param should return 1.")]
    public void Compare_NullParams_ReturnsExpectedResult(bool leftIsNull, bool rightIsNull, int expectedResult, string failureMessage)
    {
        IUnit? left = leftIsNull ? null : MockProvider.MockUnit;
        IUnit? right = rightIsNull ? null : MockProvider.MockUnit;

        var actualResult = _comparer.Compare(left, right);
        Assert.AreEqual(expectedResult, actualResult, failureMessage);
    }

    /// <summary>
    /// Verifies that <see cref="UnitComparer.Compare(IUnit?, IUnit?)"/> correctly sorts a list
    /// of units in ascending order based on <see cref="IUnit.UnitKey"/> first then by <see cref="IUnit.Ratio"/>.
    /// </summary>
    [TestMethod]
    public void SortWithComparer_DifferntUnitImplementations_SortsCorrectly()
    {
        LeastUnit leastUnit = new();
        GreatUnit greatUnit = new();
        IUnit otherUnit = new Unit<MockQuantity>(MockProvider.MockUnitBaseRatio, [], ["x"], [$"{MockProvider.MockUnitLongNames[0]}xxx"]);

        IUnit[] expectedResult =
        [
            leastUnit,
            MockProvider.MockUnit,
            otherUnit,
            greatUnit
        ];

        IUnit[] units =
        [
            otherUnit,
            MockProvider.MockUnit,
            greatUnit,
            leastUnit
        ];
        units.Sort(_comparer);

        CollectionAssert.AreEqual(expectedResult, units);
    }
}

/// <summary>
/// A mock implementation of the <see cref="IUnit"/> interface for testing purposes. <see cref="UnitKey"/>
/// and <see cref="CompareTo(IUnit?)"/> methods are overridden to provide a unique implementation that should
/// be ignored by the comparer. This unit should always be sorted to the beggining of the list.
/// </summary>
file sealed class LeastUnit : IUnit
{
    public double Ratio => long.MinValue;

    public Type ValueType => throw new NotImplementedException();

    public string DefaultShortUnitName => throw new NotImplementedException();

    public string DefaultLongUnitNamePluralForm => throw new NotImplementedException();

    public string DefaultLongUnitNameSingularForm => throw new NotImplementedException();

    public string UnitKey => "AAAA";

    public int CompareTo(IUnit? other) => 1;

    public ICollection<string> GetUnitNames() => throw new NotImplementedException();

    public override string ToString() => "LeastUnit";
}

/// <summary>
/// A mock implementation of the <see cref="IUnit"/> interface for testing purposes. <see cref="UnitKey"/>
/// and <see cref="CompareTo(IUnit?)"/> methods are overridden to provide a unique implementation that should
/// be ignored by the comparer. This unit should always be sorted to the end of the list.
/// </summary>
file sealed class GreatUnit : IUnit
{
    public double Ratio => long.MaxValue;

    public Type ValueType => throw new NotImplementedException();

    public string DefaultShortUnitName => throw new NotImplementedException();

    public string DefaultLongUnitNamePluralForm => throw new NotImplementedException();

    public string DefaultLongUnitNameSingularForm => throw new NotImplementedException();

    public string UnitKey => "ZZZZZ";

    public int CompareTo(IUnit? other) => -1;

    public ICollection<string> GetUnitNames() => throw new NotImplementedException();

    public override string ToString() => "GreatUnit";
}
