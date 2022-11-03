using SFML.Graphics;
using SFML.System;

namespace FractalsAlgorithms.Core;

internal record class PointUint
{
    internal uint X { get; init; }
    internal uint Y { get; init; }

    internal PointUint(uint x, uint y)
    {
        X = x;
        Y = y;
    }

    internal bool IsEmpty => X == 0 && Y == 0;

    public static implicit operator Vector2i(PointUint p)
        => new((int)p.X, (int)p.Y);

    public static implicit operator Vector2f(PointUint point)
        => new(point.X, point.Y);

    public static implicit operator PointUint(View view)
        => new((uint)view.Size.X, (uint)view.Size.Y);

    public static implicit operator PointInt(PointUint p)
    => new((int)p.X, (int)p.Y);

    public static implicit operator PointFloat(PointUint p)
        => new(p.X, p.Y);

    public override string ToString()
        => $"{{X:{X},Y:{Y}}}";
}