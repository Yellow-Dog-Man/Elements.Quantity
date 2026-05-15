using Elements.Quantity.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Quantity.Test;

internal static class MockProvider
{
    internal static readonly Unit<MockQuantity> MockUnit =
        new (1, null, [" u"], [" units", " unit"]);
}
