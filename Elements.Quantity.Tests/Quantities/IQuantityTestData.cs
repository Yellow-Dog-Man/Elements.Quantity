using System.Collections.Generic;

namespace Elements.Quantity.Test.Quantities;

public interface IQuantityTestData<TQuantity>
where TQuantity : unmanaged, IQuantity<TQuantity>
{
    /// <summary>
    /// An array of test data tuples representing different <typeparamref name="TQuantity"/> units and their display formats. Each
    /// element in the array contains information about a <typeparamref name="TQuantity"/> unit, the short name, the singular
    /// long name, plural long name, and unit key.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests.
    /// </remarks>
    static abstract QuantityTestData<TQuantity>[] TestDataTuples { get; }

    /// <summary>
    /// An array of test data tuples representing different combinations of <see cref="CompoundFormatInfo{TQuantity}"/> and
    /// <typeparamref name="TQuantity"/> with their expected text representation.
    /// Each element in the array contains the format, input base value, and expected string.
    /// </summary>
    /// <remarks>
    /// This property is intended for use in unit tests. Return <code>null</code> if there are no test cases.
    /// </remarks>
    static abstract IEnumerable<QuantityFormatTestData<TQuantity>>? CompoundFormatInfoDataTuples { get; }
}
