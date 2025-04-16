using System;

public abstract class GeometricObject
{
    public string Label { get; private set; }

    protected GeometricObject(string label)
    {
        Label = label;
    }
}

public interface IMetric
{
    double GetPerimeter();
    double GetArea();
}

public class RoundShape : GeometricObject, IMetric
{
    public double Radius { get; }

    public RoundShape(string label, double radius) : base(label)
    {
        Radius = radius;
    }

    public double GetPerimeter() => 2 * Math.PI * Radius;
    public double GetArea() => Math.PI * Math.Pow(Radius, 2);
}

public class FourSide : GeometricObject, IMetric
{
    public double Edge { get; }

    public FourSide(string label, double edge) : base(label)
    {
        Edge = edge;
    }

    public double GetPerimeter() => 4 * Edge;
    public double GetArea() => Edge * Edge;
}

public class ThreeSide : GeometricObject, IMetric
{
    public double Side { get; }

    public ThreeSide(string label, double side) : base(label)
    {
        Side = side;
    }

    public double GetPerimeter() => 3 * Side;
    public double GetArea() => (Math.Sqrt(3) / 4) * Side * Side;
}

public class Launcher
{
    public static void Main(string[] parameters)
    {
        var circle = new RoundShape("Окружность", 5);
        var square = new FourSide("Квадрат", 4);
        var triangle = new ThreeSide("Треуголка", 6);

        Console.WriteLine($"{circle.Label}: Периметр = {circle.GetPerimeter():F2}, Площадь = {circle.GetArea():F2}");
        Console.WriteLine($"{square.Label}: Периметр = {square.GetPerimeter():F2}, Площадь = {square.GetArea():F2}");
        Console.WriteLine($"{triangle.Label}: Периметр = {triangle.GetPerimeter():F2}, Площадь = {triangle.GetArea():F2}");
    }
}
