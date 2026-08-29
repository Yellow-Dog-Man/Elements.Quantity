using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Elements.Quantity.Test.Mocks
{
    [ExcludeFromCodeCoverage]
    internal readonly struct MockQuantity : IQuantity<MockQuantity>,
        IDivisionOperators<MockQuantity, Ratio, MockQuantity>
    {
        public readonly double BaseValue;
        double IQuantity.BaseValue => BaseValue;

        public Unit<MockQuantity> DefaultUnit => throw new NotImplementedException();

        public string QuantityFamily => "Mock";

        public MockQuantity(double baseValue = 0) : this() { BaseValue = baseValue; }
        public bool Equals(MockQuantity other) { return BaseValue == other.BaseValue; }
        public int CompareTo(MockQuantity other) { return BaseValue.CompareTo(other.BaseValue); }

        public static MockQuantity Create(double baseValue) => throw new NotImplementedException();

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

        public static MockQuantity Parse(string str, Unit<MockQuantity>? defaultUnit = null) => throw new NotImplementedException();
        public static bool TryParse(string str, out MockQuantity q, Unit<MockQuantity>? defaultUnit = null) => throw new NotImplementedException();

        public static MockQuantity operator +(MockQuantity left, MockQuantity right) => throw new NotImplementedException();
        public static MockQuantity operator -(MockQuantity left, MockQuantity right) => throw new NotImplementedException();
        public static MockQuantity operator *(MockQuantity left, double right) => throw new NotImplementedException();
        public static MockQuantity operator *(MockQuantity left, Ratio right) => throw new NotImplementedException();
        public static MockQuantity operator /(MockQuantity left, double right) => throw new NotImplementedException();
        public static MockQuantity operator /(MockQuantity left, Ratio right) => throw new NotImplementedException();
        public static Ratio operator /(MockQuantity left, MockQuantity right) => throw new NotImplementedException();
        public static MockQuantity operator -(MockQuantity value) => throw new NotImplementedException();
        public static MockQuantity AdditiveIdentity => throw new NotImplementedException();
        public static Ratio MultiplicativeIdentity => Ratio.MultiplicativeIdentity;
    }
}
