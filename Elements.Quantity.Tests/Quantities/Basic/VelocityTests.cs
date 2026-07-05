using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public class VelocityTests : BaseQuantityTests<VelocityTests, Velocity>, IQuantityTestData<Velocity>
{
    /// <inheritdoc/>
    public static QuantityTestData<Velocity>[] TestDataTuples =>
    [
        new(Velocity.MetersPerSecond, "{0} m/s", "1 meter per second", "{0} meters per second", "Quantity.Unit.Velocity.MetersPerSecond"),
        new(Velocity.KilometersPerHour, "{0} km/h", "1 kilometer per hour", "{0} kilometers per hour", "Quantity.Unit.Velocity.KilometersPerHour"),
        new(Velocity.MilesPerHour, "{0} mph", "1 mile per hour", "{0} miles per hour", "Quantity.Unit.Velocity.MilesPerHour"),
        new(Velocity.FeetPerSecond, "{0} ft/s", "1 foot per second", "{0} feet per second", "Quantity.Unit.Velocity.FeetPerSecond"),
        new(Velocity.Knots, "{0} kn", "1 knot", "{0} knots", "Quantity.Unit.Velocity.Knots")
    ];

    /// <inheritdoc/>
    public static IEnumerable<QuantityFormatTestData<Velocity>>? CompoundFormatInfoDataTuples => null;
}
