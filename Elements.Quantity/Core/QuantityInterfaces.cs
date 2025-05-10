using System;
using System.Collections.Generic;

using System.Text;


namespace Elements.Quantity
{
    public interface IQuantity
    {
        double BaseValue { get; }

        string[] GetShortBaseNames();
        string[] GetLongBaseNames();
    }

    public interface IQuantity<T> : IQuantity, IComparable<T>, IEquatable<T>
        where T : unmanaged, IQuantity<T>
    {
        T New(double baseValue);

        T Min(T q);
        T Max(T q);

        T Add(T q);
        T Subtract(T q);

        T Multiply(double n);

        T Divide(double n);
        Ratio Divide(T q);

        T Lerp(T q, double lerp);
        T LerpUnclamped(T q, double lerp);

        Unit<T> DefaultUnit { get; }
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
}
