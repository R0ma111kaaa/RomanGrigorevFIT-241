using System;
using System.Linq;


namespace vivid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество узлов в графе:");
            int nodeCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите весовую матрицу отношений");

            int[][] matrix = new int[nodeCount][];
            for (int i = 0; i < nodeCount; i++)
            {
                string line = Console.ReadLine();
                matrix[i] = line.Split(' ').Select(int.Parse).ToArray();
            }
        }
    }
}