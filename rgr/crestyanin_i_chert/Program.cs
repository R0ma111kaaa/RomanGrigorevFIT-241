using System;

class Program
{
    static void Main()
    {
        long maxN = Convert.ToInt64(Console.ReadLine());
        long count = 0;

        // Проверяем различные значения Z
        for (int z = 1;; z++)
        {
            long pow2Z = 1L << z; // 2^z\
            Console.WriteLine(pow2Z);
            long denominator = pow2Z - 1; // 2^z - 1
            Console.WriteLine(denominator);
            Console.WriteLine("\n");

            // Если 2^z - 1 становится больше чем MaxN, прекращаем
            if (denominator > maxN)
                break;

            // Для данной Z, ищем количество возможных N
            long possibleN = maxN / denominator; // N должен быть <= maxN / (2^Z - 1)
            count += possibleN;
        }

        Console.WriteLine(count);
    }
}