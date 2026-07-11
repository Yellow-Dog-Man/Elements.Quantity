using System;
using System.Linq;

namespace Elements.Quantity;

public class UnitSI<T> : Unit<T> where T : unmanaged, IQuantitySI<T>
{
    private static readonly double SIPower = default(T).SIPower;

    public UnitSI(int nFactor, string shortPrefix, string longPrefix) :
        this(nFactor, [shortPrefix], [longPrefix])
    {

    }

    public UnitSI(int nFactor, string[] shortPrefixes, string[] longPrefixes) :
        base(Math.Pow(Math.Pow(10, nFactor), SIPower),
            [UnitGroup.Metric],
            [.. shortPrefixes.Select(p => $" {p}{{0}}")],
            [.. longPrefixes.Select(p => $" {p}{{0}}")])
    {
        if (nFactor % 3 == 0)
        {
            UnitGroup.MetricThousands.RegisterUnit(this);
        }
    }
}
