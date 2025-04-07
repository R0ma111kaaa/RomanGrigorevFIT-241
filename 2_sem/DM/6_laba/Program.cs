using System;


// Флойд

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество узлов в графе:");
        int nodeCount = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите весовую матрицу отношений");
        Console.WriteLine("строки отделяются пробелом, столбцы отделяются энтером");

        int[,] matrix = new int[nodeCount, nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            string line = Console.ReadLine();
            int[] values = line.Trim().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < nodeCount; j++)
            {
                matrix[i, j] = values[j];
            }
        }
        FloydAlgorithm(matrix);

    }

    static void FloydAlgorithm(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[,] resMatrix = new int[n, n];

        // Инициализация результирующей матрицы
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    resMatrix[i, j] = 0;
                }
                else if (matrix[i, j] != 0)
                {
                    resMatrix[i, j] = matrix[i, j];
                }
                else
                {
                    resMatrix[i, j] = int.MaxValue;
                }
            }
        }

        // Алгоритм Флойда
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (resMatrix[i, k] + resMatrix[k, j] < resMatrix[i, j])
                    {
                        resMatrix[i, j] = resMatrix[i, k] + resMatrix[k, j];
                    }
                }
            }
        }

        // Вывод результатов
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Расстояния из {i} до других:\t");
            for (int j = 0; j < n; j++)
            {
                string value = double.IsPositiveInfinity(resMatrix[i, j]) ? "∞" : resMatrix[i, j].ToString();
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}
