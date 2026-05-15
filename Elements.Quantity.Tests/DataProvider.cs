using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Quantity.Test;

internal static class DataProvider
{
    internal static IEnumerable<double> UnitQuantityPluralNumberValues =>
    [
        -2.3, -0.8, 0, 0.9, 1.2
    ];

    internal static IEnumerable<double> UnitQuantityShortNameNumberValues =>
        UnitQuantityPluralNumberValues.Union([1d]);

    internal static IEnumerable<string> ValidStringFormatsWithEscapedInvalidFormats =>
        ValidStringFormats.Concat(InvalidStringFormats.Select(format => $"\\{format}"));

    internal static readonly string[] ValidStringFormats =
    [
        ".",
        "#",
        "#.0",
        "#.00",
        "0",
        "0.0",
        "0.00",
        "0.#",
        "0.##",
        "0.###",
        "00.#",
        "000.#",
        "C",
        "E",
        "F",
        "G",
        "N",
        "P",
        "R",
        "My unit number is #",
        "X is #.0",
        "My Number is Gone!",
        "Providing no number format at all\\.",
        "Just some random text?",
        "Providing a Format to ToString like this replaces the whole text with this\\."
    ];

    internal static readonly string[] InvalidStringFormats =
    [
        "B",
        "D",
        "I",
        "M",
        "Q",
        "S",
        "X",
        "Y",
        "Z",
        "B2",
        "D2",
        "X4"
    ];
}
