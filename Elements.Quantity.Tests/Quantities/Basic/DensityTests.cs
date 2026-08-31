using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public class DensityTests : BaseQuantityTests<DensityTests, Density>, IQuantityTestData<Density>
{
    /// <inheritdoc/>
    public static QuantityTestData<Density>[] TestDataTuples =>
    [
        new(Density.KilogramPerCubicMeter, "{0} kg/m³", "1 kilogram per cubic meter", "{0} kilograms per cubic meter", "Quantity.Unit.Density.KilogramsPerCubicMeter"),
        new(Density.GramPerCubicCentimeter, "{0} g/cm³", "1 gram per cubic centimeter", "{0} grams per cubic centimeter", "Quantity.Unit.Density.GramsPerCubicCentimeter"),
        new(Density.PoundPerCubicFoot, "{0} lb/ft³", "1 pound per cubic foot", "{0} pounds per cubic foot", "Quantity.Unit.Density.PoundsPerCubicFoot")
    ];
}
