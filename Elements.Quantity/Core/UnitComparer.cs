using System.Collections.Generic;

namespace Elements.Quantity;

/// <summary>
/// A comparer for <see cref="IUnit"/> instances.
/// </summary>
/// <remarks>
/// Since the comparer is expecting <see cref="IUnit"/> as parameters, it must implement
/// its own comparison logic without calling the object's <c>CompareTo</c> method, which
/// is not guaranteed to follow the same logic between different implementations of
/// <see cref="IUnit"/>.
/// </remarks>
public sealed class UnitComparer : Comparer<IUnit>
{
    /// <summary>
    /// A singleton instance of the <see cref="UnitEqualityComparer"/> class.
    /// </summary>
    public static readonly UnitComparer Instance = new();

    /// <summary>
    /// Performs a comparison of two <see cref="IUnit"/> instances and returns a
    /// value indicating whether one instance is less than, equal to, or greater
    /// than the other.
    /// </summary>
    /// <remarks>
    /// The comparer should always determine the return value if one or both
    /// parameters are null. Otherwise, 
    /// </remarks>
    /// <inheritdoc/>
    public override int Compare(IUnit? x, IUnit? y) =>
        (x, y) switch
        {
            (null, null) => 0,
            (null, _) => -1,
            (_, null) => 1,
            _ => CompareInternal(x, y)
        };

    /// <summary>
    /// Performs a comparison of two <see cref="IUnit"/> instances internally and
    /// returns a value indicating whether one instance is less than, equal to, or
    /// greater than the other.
    /// </summary>
    /// <remarks>
    /// The ratio of the two units is compared first. If the ratios are equal, then
    /// the unit keys are compared.
    /// </remarks>
    /// <returns>
    /// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>,
    /// as shown in the following list.
    /// <list type="bullet">
    ///   <item><b>Value</b> - Meaning</item>
    ///   <item><b>Less than zero</b> - <paramref name="x"/> is less than <paramref name="y"/>.</item>
    ///   <item><b>Zero</b> - <paramref name="x"/> equals <paramref name="y"/>.</item>
    ///   <item><b>Greater than zero</b> - <paramref name="x"/> is greater than <paramref name="y"/>.</item>
    /// </list>
    /// </returns>
    private static int CompareInternal(IUnit x, IUnit y)
    {
        var ratioCompareResult = x.Ratio.CompareTo(y.Ratio);
        return ratioCompareResult != 0 ? ratioCompareResult : x.UnitKey.CompareTo(y.UnitKey);
    }
}
