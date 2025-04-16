using System;

class Program
{
    static void Main()
    {
        Func<double, double, double> sum = (x, y) => x + y;
        Func<double, double, double> difference = (x, y) => x - y;
        Func<double, double, double> product = (x, y) => x * y;
        Func<double, double, double> quotient = (x, y) =>
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Невозможно разделить на ноль");
            }
            return x / y;
        };

        double num1 = 10;
        double num2 = 0;

        Console.WriteLine($"Результат сложения: {sum(num1, num2)}");
        Console.WriteLine($"Результат вычитания: {difference(num1, num2)}");
        Console.WriteLine($"Результат умножения: {product(num1, num2)}");

        try
        {
            Console.WriteLine($"Результат деления: {quotient(num1, num2)}");
        }
        catch (DivideByZeroException error)
        {
            Console.WriteLine(error.Message);
        }
    }
}
