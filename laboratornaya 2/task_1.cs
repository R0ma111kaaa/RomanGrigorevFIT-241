using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество элементов: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 3) {
            Console.WriteLine("Последовательность слишком короткая для поиска локальных минимумов.");
            return;
        }

        Console.WriteLine("Введите элементы последовательности:");
        int prev = int.Parse(Console.ReadLine());
        int current = int.Parse(Console.ReadLine());

        int localMinCount = 0;

        for (int i = 2; i < n; i++)
        {
            int next = int.Parse(Console.ReadLine());
            if (current < prev && current < next)
            {
                localMinCount++;
            }
            prev = current;
            current = next;
        }

        Console.WriteLine($"Количество локальных минимумов: {localMinCount}");
    }
}