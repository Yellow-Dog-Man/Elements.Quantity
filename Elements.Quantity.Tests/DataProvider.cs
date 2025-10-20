using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Quantity.Test
{
    internal static class DataProvider
    {
        internal static IEnumerable<double> UnitQuantityPluralNumberValues => new[]
        {
            -2.3, -0.8, 0, 0.9, 1.2
        };

        internal static IEnumerable<double> UnitQuantityShortNameNumberValues =>
            UnitQuantityPluralNumberValues.Union(new[] { 1d });
    }
}
