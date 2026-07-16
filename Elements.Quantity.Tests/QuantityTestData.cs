namespace Elements.Quantity.Test;

public readonly record struct QuantityTestData<T>(
    Unit<T> unit,
    string shortName,
    string longNameSingle,
    string longNamePlural,
    string unitKey
) where T : unmanaged, IQuantity<T>;
