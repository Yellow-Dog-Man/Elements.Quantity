using System.Collections.Generic;

namespace Elements.Quantity.Test.Quantities;

public interface IQuantityCompoundFormattedTestData<TQuantity> : IQuantityTestData<TQuantity>
where TQuantity : unmanaged, IQuantity<TQuantity>
{
    /// <summary>
    /// An array of test data tuples representing different combinations of <see cref="CompoundFormatInfo{TQuantity}"/> and
    /// <typeparamref name="TQuantity"/> with their expected text representation.
    /// Each element in the array contains the format, input base value, and expected string.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    static abstract IEnumerable<QuantityFormatTestData<TQuantity>> CompoundFormatInfoDataTuples { get; }
}