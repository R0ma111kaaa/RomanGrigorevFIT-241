using System;

class Program
{
    public static void Main(string[] args)
    {
        int CalculateKol3(int n)
        {
            if (n < 3) return 0;
            if (n == 3) return 1;

            int half = n / 2;
            return (n % 2 == 0) ? 2 * CalculateKol3(half) : CalculateKol3(half) + CalculateKol3(half + 1);
        }

        int inputNumber = int.Parse(Console.ReadLine());
        Console.WriteLine(CalculateKol3(inputNumber));
    }
}
