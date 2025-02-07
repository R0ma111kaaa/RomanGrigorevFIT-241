using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> inputLines = new List<string>();
        Console.WriteLine("Введите строки (пустая строка для завершения ввода):");

        // Считываем строки до пустой строки
        while (true)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrEmpty(line))
                break;
            inputLines.Add(line);
        }

        int countAsteriskB = 0;
        List<int> maxSubstrLengths = new List<int>();

        foreach (var line in inputLines)
        {
            // 1. Определить количество строк с a*b
            if (ContainsAsteriskB(line))
            {
                countAsteriskB++;
            }

            // 2. Найти максимальную длину подстроки abc
            int maxLen = FindMaxAbcSubstringLength(line);
            maxSubstrLengths.Add(maxLen);
        }

        // Вывод результатов
        Console.WriteLine($"Количество строк с сочетаниями a*b: {countAsteriskB}");

        Console.WriteLine("Максимальные длины подстрок в каждой строке:");
        for (int i = 0; i < maxSubstrLengths.Count; i++)
        {
            Console.WriteLine($"Строка {i + 1}: {maxSubstrLengths[i]}");
        }
    }

    // Метод для проверки наличия a*b в строке
    static bool ContainsAsteriskB(string line)
    {
        for (int i = 0; i < line.Length - 2; i++)
        {
            if (line[i] == 'a' && line[i + 2] == 'b')
            {
                return true;
            }
        }
        return false;
    }

    // Метод для нахождения максимальной длины подстроки abc
    static int FindMaxAbcSubstringLength(string line)
    {
        string pattern = "ABCabc";
        int maxLength = 0;
        int currentLength = 0;

        foreach (char c in line)
        {
            if (pattern.Contains(c))
            {
                currentLength++;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }
            }
            else
            {
                currentLength = 0;
            }
        }

        return maxLength;
    }
}
