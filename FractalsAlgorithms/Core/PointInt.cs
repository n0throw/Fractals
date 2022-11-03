using SFML.Graphics;
using SFML.System;

namespace FractalsAlgorithms.Core;

public record class PointInt
{
    public int X { get; init; }
    public int Y { get; init; }

    public PointInt(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool IsEmpty => X == 0 && Y == 0;

    public static implicit operator Vector2i(PointInt p)
        => new(p.X, p.Y);

    public static implicit operator Vector2f(PointInt point)
        => new(point.X, point.Y);

    public static implicit operator PointInt(View view)
        => new((int)view.Size.X, (int)view.Size.Y);

    public static implicit operator PointUint(PointInt p)
        => new((uint)p.X, (uint)p.Y);

    public static implicit operator PointFloat(PointInt p)
        => new(p.X, p.Y);

    public override string ToString()
        => $"{{X:{X},Y:{Y}}}";
}