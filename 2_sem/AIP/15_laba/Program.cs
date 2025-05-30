using System;

class Program
{
    unsafe static void Main(string[] args)
    {
        Console.Write("Введите количество элементов массива: ");
        int n = int.Parse(Console.ReadLine()!);

        // Выделение памяти под массив
        int* array = stackalloc int[n];

        // Ввод элементов массива
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            array[i] = int.Parse(Console.ReadLine()!);
        }

        // Подсчет количества элементов, кратных двум
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (array[i] % 2 == 0)
            {
                count++;
            }
        }

        Console.WriteLine($"Количество элементов, кратных двум: {count}");
    }
}
