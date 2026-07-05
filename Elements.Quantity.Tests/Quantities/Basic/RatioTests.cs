using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public class RatioTests : BaseQuantityTests<RatioTests, Ratio>, IQuantityTestData<Ratio>
{
    /// <inheritdoc/>
    public static QuantityTestData<Ratio>[] TestDataTuples =>
    [
        new(Ratio.RatioValue, "{0}", "1", "{0}", "Quantity.Unit.Ratio"),
        new(Ratio.Percent, "{0} %", "1 percent", "{0} percent", "Quantity.Unit.Ratio.Percent")
    ];

    /// <inheritdoc/>
    public static IEnumerable<QuantityFormatTestData<Ratio>>? CompoundFormatInfoDataTuples => null;
}
