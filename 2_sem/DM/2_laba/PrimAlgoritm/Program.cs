using System;
using System.Linq;
using System.Collections.Generic;



// РАБОЧИЙ ПРИМЕР

// Введите количество узлов в графе:
// 7
// Введите весовую матрицу отношений
// строки отделяются пробелом, столбцы отеделяются энтером
// 0 2 0 6 0 0 0  
// 2 0 3 8 5 0 0  
// 0 3 0 0 7 0 0
// 6 8 0 0 9 0 0  
// 0 5 7 9 0 1 2
// 0 0 0 0 1 0 4
// 0 0 0 0 2 4 0 
// 
// 19




namespace vivid
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество узлов в графе:");
            int nodeCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите весовую матрицу отношений");
            Console.WriteLine("строки отделяются пробелом, столбцы отеделяются энтером");

            int[][] matrix = new int[nodeCount][];
            for (int i = 0; i < nodeCount; i++)
            {
                string line = Console.ReadLine();
                matrix[i] = line.Trim().Split(' ').Select(int.Parse).ToArray();
            }

            List<int> usedNodes = new List<int> {0};

            int resultSum = 0;
            while (usedNodes.Count != nodeCount) {
                int minPath = int.MaxValue;
                int minNode = -1;
                foreach (int i in usedNodes) {
                    for (int  j= 0; j < nodeCount; j++) {
                        if (!usedNodes.Contains(j)) {
                            int currentPath = matrix[i][j];
                            if (currentPath < minPath && currentPath > 0) {
                                minPath = currentPath;
                                minNode = j;
                            }
                        }
                    }
                }
                usedNodes.Add(minNode);
                resultSum += minPath;
            }
            Console.WriteLine(resultSum);
        }
    }
}