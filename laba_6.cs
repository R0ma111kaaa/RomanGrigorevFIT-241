using System;
using System.Linq;

namespace roma111kaaa
{
    public class Laba6
    {
        public static void Main()
        {
            Console.Write("Введите M: ");
            int m = int.Parse(Console.ReadLine());
            
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());

            int[][] array = new int[m][];
            
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine($"Введите {n} чисел для строки {i + 1}, разделенных пробелом:");
                string str = Console.ReadLine();
                
                int[] subArray = str
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                array[i] = subArray;
            }

            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            // Задача 1: Сортировка столбцов по суммам
            array = SortColumnsBySum(array);
            Console.WriteLine("Массив после сортировки столбцов по суммам:");
            PrintArray(array);

            // Задача 2: Нахождение одинаковых строк
            FindDuplicateRows(array);

            // Задача 3: Поиск минимаксов
            FindMinimaxPositions(array);
        }

        // Вывод двумерного массива
        public static void PrintArray(int[][] array)
        {
            foreach (var row in array)
            {
                Console.WriteLine(string.Join("\t", row));
            }
            Console.WriteLine();
        }

        // Задача 1: Сортировка столбцов по суммам
        public static int[][] SortColumnsBySum(int[][] array)
        {
            int m = array.Length;
            int n = array[0].Length;

            // Транспонируем и получаем сумму каждого столбца
            var columns = Enumerable.Range(0, n)
                .Select(col => new { 
                    Sum = array.Sum(row => row[col]),
                    Values = array.Select(row => row[col]).ToArray()
                })
                .OrderBy(col => col.Sum)
                .Select(col => col.Values)
                .ToArray();

            // Обратно транспонируем
            int[][] sortedArray = new int[m][];
            for (int i = 0; i < m; i++)
            {
                sortedArray[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    sortedArray[i][j] = columns[j][i];
                }
            }

            return sortedArray;
        }

        // Задача 2: Нахождение одинаковых строк
        public static void FindDuplicateRows(int[][] array)
        {
            int m = array.Length;

            Console.WriteLine("Пары одинаковых строк:");
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    if (array[i].OrderBy(x => x).SequenceEqual(array[j].OrderBy(x => x)))
                    {
                        Console.WriteLine($"Строка {i} и Строка {j}");
                    }
                }
            }
        }

        // Задача 3: Поиск минимаксов
        public static void FindMinimaxPositions(int[][] array)
        {
            int m = array.Length;
            int n = array[0].Length;

            Console.WriteLine("Позиции элементов минимаксов:");

            for (int i = 0; i < m; i++)
            {
                int rowMin = array[i].Min();
                int rowMax = array[i].Max();

                for (int j = 0; j < n; j++)
                {
                    int colMax = array.Max(row => row[j]);
                    int colMin = array.Min(row => row[j]);

                    // Проверка на минимакс
                    if (array[i][j] == rowMin && array[i][j] == colMax)
                    {
                        Console.WriteLine($"Минимакс (мин в строке и макс в столбце) в позиции ({i}, {j})");
                    }
                    else if (array[i][j] == rowMax && array[i][j] == colMin)
                    {
                        Console.WriteLine($"Минимакс (макс в строке и мин в столбце) в позиции ({i}, {j})");
                    }
                }
            }
        }
    }
}
