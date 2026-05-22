using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Elements.Quantity.Test.Mocks;

namespace Elements.Quantity.Test.Core;

using CopyToArrayTestData = (Array? array, int index);

[TestClass]
[ExcludeFromCodeCoverage]
public class UnitGroupTests
{
    /// <summary>
    /// Verifies that the mockUnit mockGroup can register units.
    /// </summary>
    [TestMethod]
    public void AddUnitToUnitGroup_ValidUnit_AddsUnitToGroup()
    {
        var mockUnit = MockProvider.MockUnit;
        var mockGroup = new UnitGroup();

        mockGroup.RegisterUnit(mockUnit);

        CollectionAssert.Contains(mockGroup, mockUnit);
        Assert.IsTrue(mockGroup.HasQuantity(mockUnit.ValueType));
    }

    /// <summary>
    /// Verifies that two different units with the same ratio and family can be registered.
    /// together.
    /// </summary>
    /// <remarks>
    /// Additional asserts added due to https://github.com/Yellow-Dog-Man/Elements.Quantity/issues/45.
    /// </remarks>
    [TestMethod]
    public void AddUnitToUnitGroup_TwoUnitsOfSameRatio_AddsBothUnitsToGroup()
    {
        var mockUnitOne = MockProvider.MockUnit;
        var mockUnitTwo = new Unit<MockQuantity>(mockUnitOne.Ratio, [], ["u2"], ["mock 2 units", "mock 2 unit"]);
        var mockGroup = new UnitGroup();

        mockGroup.RegisterUnit(mockUnitOne);
        CollectionAssert.Contains(mockGroup, mockUnitOne);
        CollectionAssert.DoesNotContain(mockGroup, mockUnitTwo);
        Assert.AreEqual(1, mockGroup.Count);
        Assert.IsTrue(mockGroup.HasQuantity(mockUnitOne.ValueType));

        mockGroup.RegisterUnit(mockUnitTwo);
        CollectionAssert.Contains(mockGroup, mockUnitOne);
        CollectionAssert.Contains(mockGroup, mockUnitTwo);
        Assert.AreEqual(2, mockGroup.Count);
        Assert.IsTrue(mockGroup.HasQuantity(mockUnitOne.ValueType));
    }

    /// <summary>
    /// Verifies that the unit group returns <c>true</c> when it contains the given unit.
    /// </summary>
    [TestMethod]
    public void CheckUnitInGroup_ExistingUnit_ReturnsTrue()
    {
        var mockUnit = MockProvider.MockUnit;
        var mockGroup = new UnitGroup();

        mockGroup.RegisterUnit(mockUnit);
        Assert.IsTrue(mockGroup.HasUnit(mockUnit));
    }

    /// <summary>
    /// Verifies that the unit group returns <c>false</c> if the given unit is not in the
    /// group even if the given unit's ratio is shared with another unit that is registered
    /// in the group.
    /// </summary>
    /// <remarks>
    /// The ratio value is shared between the two units due to
    /// https://github.com/Yellow-Dog-Man/Elements.Quantity/issues/45.
    /// </remarks>
    [TestMethod]
    public void CheckUnitInGroup_UnitWithSameRatioAsExistingUnit_ReturnsFalse()
    {
        var mockExistingUnit = MockProvider.MockUnit;
        var mockNonexistingUnit = new Unit<MockQuantity>(mockExistingUnit.Ratio, [], ["neu"], ["non-existing units", "non-existing unit"]);
        var mockGroup = new UnitGroup();

        mockGroup.RegisterUnit(mockExistingUnit);
        Assert.IsFalse(mockGroup.HasUnit(mockNonexistingUnit));
    }

    /// <summary>
    /// Verifies that the unit group returns <c>false</c> if the given unit is not in the
    /// group and the quantity set associated with that unit is not created if that quantity
    /// set was never a part of the group.
    /// </summary>
    [TestMethod]
    public void CheckUnitInGroup_NonexistingUnit_ReturnsFalse()
    {
        var mockNonexistingUnit = MockProvider.MockUnit;
        var mockGroup = new UnitGroup();

        Assert.IsFalse(mockGroup.HasUnit(mockNonexistingUnit));
        Assert.IsFalse(mockGroup.HasQuantity(mockNonexistingUnit.ValueType));
    }

    /// <summary>
    /// Verifies that the unit group removes the exact given unit from the group and removes
    /// any empty quantity sets after the last unit in the set is removed.
    /// </summary>
    /// <remarks>
    /// The first group of asserts is present due to
    /// https://github.com/Yellow-Dog-Man/Elements.Quantity/issues/45.
    /// </remarks>
    [TestMethod]
    public void RemoveUnitInGroup_ValidUnit_RemovesUnitAndEmptyQuantitySet()
    {
        var mockUnitOne = MockProvider.MockUnit;
        var mockUnitTwo = new Unit<MockQuantity>(mockUnitOne.Ratio, [], ["u2"], ["mock 2 units", "mock 2 unit"]);
        var mockGroup = new UnitGroup();

        mockGroup.RegisterUnit(mockUnitOne);

        mockGroup.RemoveUnit(mockUnitTwo);

        Assert.IsTrue(mockGroup.HasUnit(mockUnitOne));
        Assert.IsFalse(mockGroup.HasUnit(mockUnitTwo));
        Assert.IsTrue(mockGroup.HasQuantity(mockUnitOne.ValueType));

        mockGroup.RegisterUnit(mockUnitTwo);
        mockGroup.RemoveUnit(mockUnitOne);

        Assert.IsFalse(mockGroup.HasUnit(mockUnitOne));
        Assert.IsTrue(mockGroup.HasUnit(mockUnitTwo));
        Assert.IsTrue(mockGroup.HasQuantity(mockUnitOne.ValueType));

        mockGroup.RemoveUnit(mockUnitTwo);

        Assert.IsFalse(mockGroup.HasUnit(mockUnitOne));
        Assert.IsFalse(mockGroup.HasUnit(mockUnitTwo));
        Assert.IsFalse(mockGroup.HasQuantity(mockUnitOne.ValueType));
    }
    }

}
