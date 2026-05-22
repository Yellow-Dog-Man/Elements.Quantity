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

}
