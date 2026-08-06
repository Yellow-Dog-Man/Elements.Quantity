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

        /// <summary>
        /// The overarching family that this quantity type belongs to.
        /// </summary>
        /// <remarks>
        /// This member should eventually be removed in the future in favor of
        /// <see cref="IQuantity{T}.Family"/> before a major library release.
        /// </remarks>
        [Obsolete("Use 'IQuantity<T>.Family' instead.")]
        string QuantityFamily { get; }

        /// <summary>
        /// The overarching family that this quantity type belongs to.
        /// </summary>
        /// <remarks>
        /// This can be used to generate a value for <see cref="IUnit.UnitKey"/>.
        /// </remarks>
        static abstract QFamily Family { get; }
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
