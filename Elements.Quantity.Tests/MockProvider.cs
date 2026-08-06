using Elements.Quantity.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Quantity.Test;

internal static class MockProvider
{
    internal const double MockUnitBaseRatio = 1.0;

    internal static readonly string[] MockUnitShortNames = [" u"];

    internal static readonly string[] MockUnitLongNames = [" units", " unit"];

    internal const string MockUnitNameKeyOverride = "MockUnitNameKeyOverride";

    internal static readonly Unit<MockQuantity> MockUnit =
        new (MockUnitBaseRatio, null, MockUnitShortNames, MockUnitLongNames);
}
