namespace Mindbox.Shapes.Basics;

public readonly record struct Circle(double Radius) : IShape
{
    public double Area => Math.PI * Radius * Radius;
}