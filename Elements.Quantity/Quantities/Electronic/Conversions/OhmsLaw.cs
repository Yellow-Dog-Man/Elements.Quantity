using System.Numerics;

namespace Elements.Quantity;

// Ohm's Law: Voltage = Resistance * Current

public readonly partial struct Current : IMultiplyOperators<Current, Resistance, Voltage>
{
    public static Voltage operator *(Current i, Resistance r) => new(r.BaseValue * i.BaseValue);
}

public readonly partial struct Resistance : IMultiplyOperators<Resistance, Current, Voltage>
{
    public static Voltage operator *(Resistance r, Current i) => new(r.BaseValue * i.BaseValue);
}

public readonly partial struct Voltage :
    IDivisionOperators<Voltage, Resistance, Current>,
    IDivisionOperators<Voltage, Current, Resistance>
{
    public static Current operator /(Voltage v, Resistance r) => new(v.BaseValue / r.BaseValue);
    public static Resistance operator /(Voltage v, Current c) => new(v.BaseValue / c.BaseValue);
}
