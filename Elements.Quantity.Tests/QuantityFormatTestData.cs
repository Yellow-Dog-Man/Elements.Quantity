namespace Elements.Quantity.Test;

public readonly record struct QuantityFormatTestData<TQuantity>(
    CompoundFormatInfo<TQuantity> Format,
    double Value,
    string ExpectedStr
)
where TQuantity : unmanaged, IQuantity<TQuantity>;
