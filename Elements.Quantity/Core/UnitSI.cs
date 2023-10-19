using System;
using System.Collections.Generic;
using System.Linq;

namespace Elements.Quantity
{
    public class UnitSI<T> : Unit<T> where T : unmanaged, IQuantitySI<T>
    {
        static UnitSI() { SIPower = default(T).SIPower; }
        static double SIPower;

        public UnitSI(int nFactor, string shortPrefix, string longPrefix) :
            base(Math.Pow(Math.Pow(10, nFactor), SIPower),
                new UnitGroup[] { UnitGroup.Metric },
                new string[] { " " + shortPrefix + "{0}" },
                new string[] { " " + longPrefix +  "{0}" })
        {
            if (nFactor % 3 == 0)
                UnitGroup.MetricThousands.RegisterUnit(this);
        }

        public UnitSI(int nFactor, string[] shortPrefixes, string[] longPrefixes) :
            base(Math.Pow(Math.Pow(10, nFactor), SIPower),
                new UnitGroup[] { UnitGroup.Metric },
                shortPrefixes.Select(p => " " + p + "{0}").ToArray(),
                longPrefixes.Select(p => " " + p + "{0}").ToArray())
        {
            if (nFactor % 3 == 0)
                UnitGroup.MetricThousands.RegisterUnit(this);
        }
    }

}
