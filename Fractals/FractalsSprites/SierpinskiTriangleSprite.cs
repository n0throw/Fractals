using SFML.Graphics;

namespace Fractals.FractalsSprites;

internal class SierpinskiTriangleSprite : Transformable, Drawable
{
    private readonly List<Vertex> vertexes;

    public SierpinskiTriangleSprite(List<Point> points, Color color)
    {
        vertexes = new(points.Capacity);
        points.ForEach(point =>
            vertexes.Add(new Vertex(point, color)));
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        states.Transform *= Transform;
        target.Draw(vertexes.ToArray(), PrimitiveType.Points, states);
    }
}
