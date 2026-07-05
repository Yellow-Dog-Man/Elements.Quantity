using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public class TorqueTests : BaseQuantityTests<TorqueTests, Torque>, IQuantityTestData<Torque>
{
    /// <inheritdoc/>
    public static QuantityTestData<Torque>[] TestDataTuples =>
    [
        new(Torque.NewtonMeter, "{0} N m", "1 newton meter", "{0} newton meters", "Quantity.Unit.Torque.NewtonMeters"),
        new(Torque.PoundFoot, "{0} lb·ft", "1 pound-foot", "{0} pound-feet", "Quantity.Unit.Torque.Pound-feet")
    ];

    /// <inheritdoc/>
    public static IEnumerable<QuantityFormatTestData<Torque>>? CompoundFormatInfoDataTuples => null;
}
