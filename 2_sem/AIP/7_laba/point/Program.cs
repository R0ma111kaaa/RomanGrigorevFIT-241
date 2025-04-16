using System;

class Vector2
{
    public double A { get; set; }
    public double B { get; set; }

    public Vector2(double a, double b)
    {
        A = a;
        B = b;
    }
}

class Zone
{
    public double Left { get; }
    public double Bottom { get; }
    public double Right { get; }
    public double Top { get; }

    public Zone(double left, double bottom, double right, double top)
    {
        Left = left;
        Bottom = bottom;
        Right = right;
        Top = top;
    }

    public bool Contains(Vector2 v)
    {
        return v.A >= Left && v.A <= Right && v.B >= Bottom && v.B <= Top;
    }
}

class Entry
{
    static Random rnd = new Random();

    static void Main(string[] args)
    {
        var zone = new Zone(0, 0, 2, 2);
        var pos = new Vector2(1, 1);

        Console.WriteLine($"Позиция старта: ({pos.A}, {pos.B})");

        for (int j = 0; j < 10; j++)
        {
            Shift(ref pos);
            Console.WriteLine($"Сдвиг: ({pos.A}, {pos.B})");

            if (!zone.Contains(pos))
            {
                Console.WriteLine("Вне зоны допустимого!");
                break;
            }
        }
    }

    static void Shift(ref Vector2 v)
    {
        double dx = rnd.NextDouble() * 2 - 1;
        double dy = rnd.NextDouble() * 2 - 1;
        v.A += dx;
        v.B += dy;
    }
}
