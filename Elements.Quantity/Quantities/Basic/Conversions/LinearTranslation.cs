using System.Numerics;

namespace Elements.Quantity;

// linear translation: distance = velocity * time

public readonly partial struct Time : IMultiplyOperators<Time, Velocity, Distance>
{
    public static Distance operator *(Time t, Velocity v) => v * t;
}

public readonly partial struct Velocity : IMultiplyOperators<Velocity, Time, Distance>
{
    public static Distance operator *(Velocity v, Time t)
        => Distance.Meter * (v.BaseValue /* m/s */ * t.BaseValue /* s */);
}

public readonly partial struct Distance :
    IDivisionOperators<Distance, Time, Velocity>,
    IDivisionOperators<Distance, Velocity, Time>
{
    public static Velocity operator /(Distance l, Time t)
        => Velocity.MetersPerSecond * (l.BaseValue /* m */ / t.BaseValue /* s */);

    public static Time operator /(Distance l, Velocity v)
        => Time.Second * (l.BaseValue /* m */ / v.BaseValue /* m/s */);
}
