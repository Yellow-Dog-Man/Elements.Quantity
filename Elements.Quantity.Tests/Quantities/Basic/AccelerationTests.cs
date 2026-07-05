using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public sealed class AccelerationTests : BaseQuantityTests<AccelerationTests, Acceleration>, IQuantityTestData<Acceleration>
{
    /// <inheritdoc/>
    public static QuantityTestData<Acceleration>[] TestDataTuples =>
    [
        new(Acceleration.MetersPerSecondPerSecond, "{0} m/s^2", "1 meter per second squared", "{0} meters per second squared", "Quantity.Unit.Acceleration.MetersPerSecondSquared")
    ];

    /// <inheritdoc/>
    public static IEnumerable<QuantityFormatTestData<Acceleration>>? CompoundFormatInfoDataTuples => null;
}
