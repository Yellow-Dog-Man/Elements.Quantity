using System;

namespace Elements.Quantity;

public static class QuantityExtensions
{

    extension<T>(T quantity)
    where T : unmanaged, IQuantity<T>
    {

        [Obsolete("Use Create")]
        public T New(double baseValue) => T.Create(baseValue);

        [Obsolete("Use System.Numerics interfaces")]
        public T Add(T q) => T.Create(quantity.BaseValue) + q;

        [Obsolete("Use System.Numerics interfaces")]
        public T Subtract(T q) => T.Create(quantity.BaseValue) - q;

        [Obsolete("Use System.Numerics interfaces")]
        public T Multiply(double n) => T.Create(quantity.BaseValue) * n;

        [Obsolete("Use System.Numerics interfaces")]
        public T Divide(double n) => T.Create(quantity.BaseValue) / n;

        [Obsolete("Use System.Numerics interfaces")]
        public Ratio Divide(T q) => T.Create(quantity.BaseValue) / q;

    }

}
