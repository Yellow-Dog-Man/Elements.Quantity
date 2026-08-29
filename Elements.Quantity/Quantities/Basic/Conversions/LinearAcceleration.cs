using System.Numerics;

namespace Elements.Quantity;

// linear acceleration: velocity = acceleration * time

public readonly partial struct Acceleration : IMultiplyOperators<Acceleration, Time, Velocity>
{
    public static Velocity operator *(Acceleration a, Time t) => new(a.BaseValue * t.BaseValue);
}

public readonly partial struct Time : IMultiplyOperators<Time, Acceleration, Velocity>
{
    public static Velocity operator *(Time t, Acceleration a) => a * t;
}

public readonly partial struct Velocity :
    IDivisionOperators<Velocity, Time, Acceleration>,
    IDivisionOperators<Velocity, Acceleration, Time>
{
    public static Acceleration operator /(Velocity v, Time t)
        => Acceleration.MetersPerSecondPerSecond * (v.BaseValue /* m/s */ / t.BaseValue /* s */);

    public static Time operator /(Velocity v, Acceleration a)
        => Time.Second * (v.BaseValue /* m/s */ / a.BaseValue /* m/s/s */);
}
