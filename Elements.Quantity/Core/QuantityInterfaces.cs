using System;
using System.Numerics;

namespace Elements.Quantity;

public interface IQuantity
{
    double BaseValue { get; }

    string[] GetShortBaseNames();
    string[] GetLongBaseNames();
}

public interface IQuantity<T> : IQuantity, IComparable<T>, IEquatable<T>,
    IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>,
    IMultiplyOperators<T, double, T>, IMultiplyOperators<T, Ratio, T>,
    IDivisionOperators<T, double, T>, IDivisionOperators<T, T, Ratio>,
    IUnaryNegationOperators<T, T>,
    IAdditiveIdentity<T, T>, IMultiplicativeIdentity<T, Ratio>
    where T : unmanaged, IQuantity<T>
{
    static abstract T Create(double baseValue);

    T New(double baseValue) => T.Create(baseValue);

    [Obsolete("Use System.Numerics interfaces")]
    T Add(T q) => T.Create(BaseValue) + q;

    [Obsolete("Use System.Numerics interfaces")]
    T Subtract(T q) => T.Create(BaseValue) - q;

    [Obsolete("Use System.Numerics interfaces")]
    T Multiply(double n) => T.Create(BaseValue) * n;

    [Obsolete("Use System.Numerics interfaces")]
    T Divide(double n) => T.Create(BaseValue) / n;

    [Obsolete("Use System.Numerics interfaces")]
    Ratio Divide(T q) => T.Create(BaseValue) / q;

    Unit<T> DefaultUnit { get; }

    static abstract T Parse(string str, Unit<T>? defaultUnit = null);
    static abstract bool TryParse(string str, out T q, Unit<T>? defaultUnit = null);

    /// <summary>
    /// The quantity family that this quantity type belongs to.
    /// </summary>
    /// <remarks>
    /// This is used to generate the value for <see cref="Unit{T}.UnitKey"/>. For quantity
    /// types that fall under the 'Basic' family, an empty string should always be returned.
    /// </remarks>
    string QuantityFamily { get; }
}

public interface IQuantitySI
{
    double SIPower { get; }
    IUnit[] GetCommonSIUnits();
    IUnit[] GetExludedSIUnits();
}

public interface IQuantitySI<T> : IQuantitySI, IQuantity<T> where T : unmanaged, IQuantity<T>
{

}
