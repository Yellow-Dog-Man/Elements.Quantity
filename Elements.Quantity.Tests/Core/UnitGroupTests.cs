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
    /// An array of test data tuples representing one or more invalid arguments to be passed
    /// to <c>CopyTo</c>.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    internal static CopyToArrayTestData[] InvalidCopyToArrayTestData =>
    [
        new (new IUnit[0], 0),
        new (new IUnit[100], -1),
        new (new IUnit[5,5], 0),
        new (null, 0),
        new (new IUnit[10], 10)
    ];

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

    /// <summary>
    /// Verifies that a unit group can be copied to an array.
    /// </summary>
    [TestMethod]
    public void CopyUnitGroupToArray_ValidArray_CopiesUnitsToArray()
    {
        var mockUnitOne = MockProvider.MockUnit;
        var mockUnitTwo = new Unit<MockQuantity>(mockUnitOne.Ratio, [], ["u2"], ["mock 2 units", "mock 2 unit"]);
        var mockUnitThree = new Unit<MockQuantity>(mockUnitOne.Ratio, [], ["u3"], ["mock 3 units", "mock 3 unit"]);
        var mockUnitFour = new Unit<MockQuantity>(mockUnitOne.Ratio, [], ["u4"], ["mock 4 units", "mock 4 unit"]);
        var mockUnitFive = new Unit<MockQuantity>(mockUnitOne.Ratio, [], ["u5"], ["mock 5 units", "mock 5 unit"]);
        var expectedArray = new[] { mockUnitOne, mockUnitTwo, mockUnitThree, mockUnitFour, mockUnitFive };

        var mockGroup = new UnitGroup();
        mockGroup.RegisterUnit(mockUnitOne);
        mockGroup.RegisterUnit(mockUnitTwo);
        mockGroup.RegisterUnit(mockUnitThree);
        mockGroup.RegisterUnit(mockUnitFour);
        mockGroup.RegisterUnit(mockUnitFive);

        IUnit[] copyArray = new IUnit[5];

        mockGroup.CopyTo(copyArray, 0);

        CollectionAssert.AreEquivalent(copyArray, expectedArray);
    }

    /// <summary>
    /// Verifies that invalid argument supplied to the unit group's <c>CopyTo</c> method
    /// will throw an exception.
    /// </summary>
    /// <param name="arrayToCopyTo">The valid or invalid array to copy the unit group's units to.</param>
    /// <param name="index">The valid or invalid starting index in the given array to start copying to.</param>
    /// <remarks>
    /// One or more arguments are invalid.
    /// </remarks>
    [TestMethod]
    [DynamicData(nameof(InvalidCopyToArrayTestData))]
    public void CopyUnitGroupToArray_InvalidArguments_ThrowsException(Array arrayToCopyTo, int index)
    {
        var mockUnitOne = MockProvider.MockUnit;
        var mockUnitTwo = new Unit<MockQuantity>(mockUnitOne.Ratio, [], ["u2"], ["mock 2 units", "mock 2 unit"]);
        var mockUnitThree = new Unit<MockQuantity>(mockUnitOne.Ratio, [], ["u3"], ["mock 3 units", "mock 3 unit"]);

        var mockGroup = new UnitGroup();
        mockGroup.RegisterUnit(mockUnitOne);
        mockGroup.RegisterUnit(mockUnitTwo);
        mockGroup.RegisterUnit(mockUnitThree);

        Assert.Throws<Exception>(() => mockGroup.CopyTo(arrayToCopyTo, index));
    }

    /// <summary>
    /// Verifies that enumerating a unit group will return all registered units and returns them in the
    /// correct order.
    /// </summary>
    /// <remarks>
    /// The enumeration order is determined by when a quantity set has been registered followed by the
    /// unit's ratio value in ascending order.
    /// </remarks>
    [TestMethod]
    public void EnumerateUnitGroup_ValidUnitGroup_ReturnsUnits()
    {
        var mockGroup = new UnitGroup();
        mockGroup.RegisterUnit(Acceleration.MetersPerSecondPerSecond);
        mockGroup.RegisterUnit(Velocity.MetersPerSecond);
        mockGroup.RegisterUnit(MockProvider.MockUnit);
        mockGroup.RegisterUnit(Density.GramPerCubicCentimeter);
        mockGroup.RegisterUnit(Velocity.Knots);
        mockGroup.RegisterUnit(Density.KilogramPerCubicMeter);

        var expectedOrder = new IUnit[]
        {
            Acceleration.MetersPerSecondPerSecond,
            Velocity.Knots,
            Velocity.MetersPerSecond,
            MockProvider.MockUnit,
            Density.KilogramPerCubicMeter,
            Density.GramPerCubicCentimeter
        };

        var actualOrder = new List<IUnit>();

        foreach (var unit in mockGroup)
        {
            actualOrder.Add(unit);
        }

        CollectionAssert.AreEqual(expectedOrder, actualOrder);
    }

    /// <summary>
    /// Verifies that calling the unit group's enumerator's <c>Reset</c> method should throw an
    /// exception.
    /// </summary>
    /// <remarks>
    /// This is very typical to do since it appears that this method is required to be defined
    /// due to legacy reasons.
    /// </remarks>
    [TestMethod]
    public void ResetEnumerator_CallMethod_ThrowsException()
    {
        var mockGroup = new UnitGroup();
        mockGroup.RegisterUnit(MockProvider.MockUnit);

        var enumerator = mockGroup.GetEnumerator();
        enumerator.MoveNext();

        Assert.ThrowsExactly<NotSupportedException>(() => enumerator.Reset());

        enumerator.Dispose();
    }
}
