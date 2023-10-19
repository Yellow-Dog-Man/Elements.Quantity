using System;
using System.Collections.Generic;
using System.Text;


namespace Elements.Quantity
{
    public class UnitNonLinear<T> : Unit<T> where T : unmanaged, IQuantity<T>
    {
        Func<double, double> convertToFunc;
        Func<double, double> convertFromFunc;

        public UnitNonLinear(
            Func<double, double> convertToFunc,
            Func<double, double> convertFromFunc,
            ICollection<UnitGroup> unitGroups,
            string[] shortNames,
            string[] longNames) : base(0f, unitGroups, shortNames, longNames)
        {
            this.convertToFunc = convertToFunc;
            this.convertFromFunc = convertFromFunc;
        }

        public override T ConvertFrom(double val)
        {
            return default(T).New(convertFromFunc(val));
        }

        public override double ConvertTo(T q)
        {
            return convertToFunc(q.BaseValue);
        }
    }
}