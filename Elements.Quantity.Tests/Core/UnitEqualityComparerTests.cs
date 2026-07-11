using Elements.Quantity.Test;
using Elements.Quantity.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity.Test.Core;

[TestClass]
[ExcludeFromCodeCoverage]
public sealed class UnitEqualityComparerTests
{
    private static readonly UnitEqualityComparer _comparer = UnitEqualityComparer.Instance;

    /// <summary>
    /// Verifies that the <see cref="UnitEqualityComparer.Equals(IUnit?, IUnit?)"/> method correctly determines equality when
    /// both units are different references but have equal properties.
    /// </summary>
    [TestMethod]
    public void CheckEqualityOfUnits_UnitsAreEqual_ReturnsTrue()
    {
        var mockUnitA = MockProvider.MockUnit;
        var mockUnitB = new Unit<MockQuantity>(mockUnitA.Ratio, [], MockProvider.MockUnitShortNames, MockProvider.MockUnitLongNames);

        var actualResult = _comparer.Equals(mockUnitA, mockUnitB);
        Assert.IsTrue(actualResult);
    }

    /// <summary>
    /// Verifies that the <see cref="UnitEqualityComparer.Equals(IUnit?, IUnit?)"/> method correctly determines equality when
    /// both units are the same reference.
    /// </summary>
    [TestMethod]
    public void CheckEqualityOfUnits_UnitsAreSameRef_ReturnsTrue()
    {
        var actualResult = _comparer.Equals(MockProvider.MockUnit, MockProvider.MockUnit);
        Assert.IsTrue(actualResult);
    }

    /// <summary>
    /// Verifies that the <see cref="UnitEqualityComparer.Equals(IUnit?, IUnit?)"/> method correctly determines equality when
    /// both units are null.
    /// </summary>
    [TestMethod]
    public void CheckEqualityOfUnits_UnitsAreNull_ReturnsTrue()
    {
        var actualResult = _comparer.Equals(null, null);
        Assert.IsTrue(actualResult);
    }

    /// <summary>
    /// Verifies that the <see cref="UnitEqualityComparer.Equals(IUnit?, IUnit?)"/> method correctly determines inequality.
    /// </summary>
    [TestMethod]
    public void CheckEqualityOfUnits_UnitsAreDifferent_ReturnsFalse()
    {
        var mockUnitA = MockProvider.MockUnit;
        var mockUnitB = new Unit<MockQuantity>(0, [], ["m2"], ["mockUnit2"]);

        var actualResult = _comparer.Equals(mockUnitA, mockUnitB);
        Assert.IsFalse(actualResult);
    }

    /// <summary>
    /// Verifies that the <see cref="UnitEqualityComparer.GetHashCode(IUnit)"/> method returns the same hash code as the one from
    /// <see cref="IUnit.GetHashCode()"/>.
    /// </summary>
    [TestMethod]
    public void GetHashCode_SameUnits_ReturnsSameHashCodeValue()
    {
        var mockUnit = MockProvider.MockUnit;

        var expectedHashCode = mockUnit.GetHashCode();
        var actualHashCode = _comparer.GetHashCode(mockUnit);

        Assert.AreEqual(expectedHashCode, actualHashCode);
    }
}
