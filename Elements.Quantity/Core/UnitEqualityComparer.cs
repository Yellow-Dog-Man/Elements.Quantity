using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Elements.Quantity;

/// <summary>
/// An equality comparer for <see cref="IUnit"/> instances.
/// </summary>
/// <remarks>
/// Since the comparer is expecting <see cref="IUnit"/> as parameters, it must implement
/// its own equality comparison logic without calling the object's <c>Equals</c> and
/// <c>GetHashCode</c> methods, which is not guaranteed to follow the same logic between
/// different implementations of <see cref="IUnit"/>.
/// </remarks>
public sealed class UnitEqualityComparer : EqualityComparer<IUnit>
{
    /// <summary>
    /// A singleton instance of the <see cref="UnitEqualityComparer"/> class.
    /// </summary>
    public static readonly UnitEqualityComparer Instance = new();

    /// <summary>
    /// Determines whether two objects of type <see cref="IUnit"/> are equal.
    /// </summary>
    /// <inheritdoc/>
    public override bool Equals(IUnit? x, IUnit? y) =>
        x is null ? y is null : x.UnitKey == y?.UnitKey && x.Ratio == y!.Ratio;

    /// <summary>
    /// Serves as a hash function for the specified <see cref="IUnit"/> for hashing
    /// algorithms and data structures, such as a hash table.
    /// </summary>
    /// <remarks>
    /// Although the parameter can be changed to be nullable, the base class <see cref="EqualityComparer{T}"/>
    /// requires it to not be null. Therefore, <see cref="DisallowNullAttribute"/> is left on here.
    /// </remarks>
    /// <inheritdoc/>
    public override int GetHashCode([DisallowNull]IUnit unit) => HashCode.Combine(unit.UnitKey, unit.Ratio);
}
