using System;

public delegate int CustomDelegate();

class MathHandler
{
    private int a, b;

    public MathHandler(int x, int y)
    {
        a = x;
        b = y;
    }

    public int Sum() => a + b;

    public int Diff() => a - b;

    public int Prod() => a * b;

    public int Quotient()
    {
        if (b == 0)
            throw new InvalidOperationException("Zero division");
        return a / b;
    }
}

class EntryPoint
{
    static void Main(string[] args)
    {
        var obj1 = new MathHandler(10, 5);
        var obj2 = new MathHandler(20, 4);

        CustomDelegate del1 = () =>
        {
            var x = obj1.Sum();
            Console.WriteLine($"Step 1: {x}");
            var y = x * obj1.Quotient();
            Console.WriteLine($"Step 2: {y}");
            var z = y / obj1.Quotient();
            Console.WriteLine($"Step 3: {z}");
            return z;
        };

        CustomDelegate del2 = () =>
        {
            var r = obj2.Quotient();
            Console.WriteLine($"Phase 1: {r}");
            var s = r - obj2.Diff();
            Console.WriteLine($"Phase 2: {s}");
            var t = s * obj2.Diff();
            Console.WriteLine($"Phase 3: {t}");
            return t;
        };

        Console.WriteLine("Выполнение первой цепочки:");
        del1();

        Console.WriteLine("\nВыполнение второй цепочки:");
        del2();
    }
}
