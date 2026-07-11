using System.Collections.Generic;

namespace Elements.Quantity;

/// <summary>
/// An equality comparer for <see cref="IUnit"/> instances.
/// </summary>
public sealed class UnitEqualityComparer : IEqualityComparer<IUnit>
{
    /// <summary>
    /// A singleton instance of <see cref="UnitEqualityComparer"/>.
    /// </summary>
    public static readonly UnitEqualityComparer Instance = new();

    /// <inheritdoc/>
    public bool Equals(IUnit? x, IUnit? y) =>
        (x is not null && x.Equals(y)) || (x is null && y is null);

    /// <inheritdoc/>
    public int GetHashCode(IUnit unit) => unit.GetHashCode();
}
