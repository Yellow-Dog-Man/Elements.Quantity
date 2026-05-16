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

        T Add(T q);
        T Subtract(T q);

        T Multiply(double n);

        T Divide(double n);
        Ratio Divide(T q);

        Unit<T> DefaultUnit { get; }

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
}
