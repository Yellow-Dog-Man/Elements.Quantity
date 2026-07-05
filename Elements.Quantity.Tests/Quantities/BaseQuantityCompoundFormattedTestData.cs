using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elements.Quantity.Test.Quantities;

[TestClass]
[ExcludeFromCodeCoverage]
public abstract class BaseQuantityCompoundFormattedTests<TData, TQuantity> : BaseQuantityTests<TData, TQuantity>
where TData : IQuantityCompoundFormattedTestData<TQuantity>
where TQuantity : unmanaged, IQuantity<TQuantity>
{
    public static IEnumerable<object[]> PredefinedCompoundFormatInfoArgs =>
        TData.CompoundFormatInfoDataTuples.Select(row => (object[])[row.Format, row.Value, row.ExpectedStr]);

    /// <summary>
    /// Test that <typeparamref name="TQuantity"/> is correctly formatted when using <see cref="CompoundFormatInfo{TQuantity}"/>
    /// </summary>
    /// <param name="format">Format Info used</param>
    /// <param name="value">Quantity value in <see cref="TQuantity.DefaultUnit"/> Unit.</param>
    /// <param name="expectedStr">Expected format result</param>
    [TestMethod]
    [DynamicData(nameof(PredefinedCompoundFormatInfoArgs))]
    public void FormatQuantityAsCompound_PredefinedCompoundFormat_FormatsQuantityAsString(CompoundFormatInfo<TQuantity> format, double value, string expectedStr)
    {
        var quantity = default(TQuantity).New(value);
        var resultStr = quantity.FormatCompound(format);

        Assert.AreEqual(expectedStr, resultStr);
    }
}
