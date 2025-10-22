using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Quantity.Test.Mocks
{
    [ExcludeFromCodeCoverage]
    internal readonly struct MockQuantity : IQuantity<MockQuantity>
    {
        public readonly double BaseValue;
        double IQuantity.BaseValue => BaseValue;

        public Unit<MockQuantity> DefaultUnit => throw new NotImplementedException();

        public MockQuantity(double baseValue = 0) : this() { BaseValue = baseValue; }
        public bool Equals(MockQuantity other) { return BaseValue == other.BaseValue; }
        public int CompareTo(MockQuantity other) { return BaseValue.CompareTo(other.BaseValue); }

        public MockQuantity New(double baseValue)
        {
            throw new NotImplementedException();
        }

        public MockQuantity Add(MockQuantity q)
        {
            throw new NotImplementedException();
        }

        public MockQuantity Subtract(MockQuantity q)
        {
            throw new NotImplementedException();
        }

        public MockQuantity Multiply(double n)
        {
            throw new NotImplementedException();
        }

        public MockQuantity Divide(double n)
        {
            throw new NotImplementedException();
        }

        public Ratio Divide(MockQuantity q)
        {
            throw new NotImplementedException();
        }

        public string[] GetShortBaseNames() => ["u"];

        public string[] GetLongBaseNames() => ["units", "unit"];

        public override bool Equals(object? obj)
        {
            return obj is MockQuantity quantity && Equals(quantity);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
