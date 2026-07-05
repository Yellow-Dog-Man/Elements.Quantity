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
}
