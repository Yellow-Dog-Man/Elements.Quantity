using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public class LuminanceTests : BaseQuantityTests<LuminanceTests, Luminance>, IQuantityTestData<Luminance>
{
    /// <inheritdoc/>
    public static QuantityTestData<Luminance>[] TestDataTuples =>
    [
        new(Luminance.CandelaPerSquareMeter, "{0} cd/m²", "1 candela per square meter", "{0} candelas per square meter", "Quantity.Unit.Luminance.CandelasPerSquareMeter"),
        new(Luminance.Nit, "{0} nt", "1 nit", "{0} nits", "Quantity.Unit.Luminance.Nits")
    ];

    /// <inheritdoc/>
    public static IEnumerable<QuantityFormatTestData<Luminance>>? CompoundFormatInfoDataTuples => null;
}
