using SFML.Graphics;
using SFML.System;

namespace FractalsAlgorithms.Core;

public class PointFloat
{
    public float X { get; init; }
    public float Y { get; init; }

    public PointFloat(float x, float y)
    {
        this.X = x;
        this.Y = y;
    }

    public bool IsEmpty => X == 0 && Y == 0;

    public static implicit operator Vector2i(PointFloat p)
        => new((int)p.X, (int)p.Y);

    public static implicit operator Vector2f(PointFloat point)
        => new(point.X, point.Y);

    public static implicit operator PointFloat(View view)
        => new((uint)view.Size.X, (uint)view.Size.Y);

    public static implicit operator PointInt(PointFloat p)
        => new((int)p.X, (int)p.Y);

    public static implicit operator PointUint(PointFloat p)
        => new((uint)p.X, (uint)p.Y);

    public override string ToString()
        => $"{{X:{X},Y:{Y}}}";
}