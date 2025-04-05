namespace vivid
{
    class Shape
    {
        string Name;
        public Shape(string name)
        {
            Name = name;
        }
    }

    interface Methods
    {
        double GetPerimeter();
        double GetArea();
    }
    
    class Circle : Shape, Methods
    {
        public double Radius { get; set; }
        public Circle(double radius) : base("Окружность")
        {
            Radius = radius;
        }
        public double GetPerimeter() => 2 * Math.PI * Radius;
        public double GetArea() => Math.PI * Math.Pow(Radius, 2);
    }

    class Square : Shape, Methods
    {
        public double SideLength { get; set; }
        public Square(double sideLength) : base("Квадрат")
        {
            SideLength = sideLength;
        }
        public double GetPerimeter() => 4 * SideLength;
        public double GetArea() => Math.Pow(SideLength, 2);
    }

    class Rectangle: Shape, Methods
    {
        public double SideLength { get; set; }
        public Rectangle(double sideLength) : base("Ректальник")
        {
            SideLength = sideLength;
        }
        public double GetPerimeter() => 4 * SideLength;
        public double GetArea() => (Math.Sqrt(3) / 4) * Math.Pow(SideLength, 2);
    }

    class Program
    {
        static void Main()
        {
            Methods circle = new Circle(5);
            Methods square = new Square(4);
            Methods triangle = new Rectangle(3);

            Console.WriteLine("Фигура: Окружность");
            Console.WriteLine($"Периметр: {circle.GetPerimeter():F2}");
            Console.WriteLine($"Площадь: {circle.GetArea():F2}\n");

            Console.WriteLine("Фигура: Квадрат");
            Console.WriteLine($"Периметр: {square.GetPerimeter():F2}");
            Console.WriteLine($"Площадь: {square.GetArea():F2}\n");

            Console.WriteLine("Фигура: Равносторонний треугольник");
            Console.WriteLine($"Периметр: {triangle.GetPerimeter():F2}");
            Console.WriteLine($"Площадь: {triangle.GetArea():F2}");
        }
    }
}