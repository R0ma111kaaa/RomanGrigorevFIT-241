using System;
using System.Linq;
using System.Collections.Generic;



// Задание: найти мосты по остовному дереву.
// По сути то же самое, что и 2 задание, но в ответе список ребер




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

            int counter = 0;
            var edgeList = new (int, int, int)[nodeCount * nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                string input = Console.ReadLine();
                int[] currentLine = input.Trim().Split(' ').Select(int.Parse).ToArray();
                for (int j = i; j < nodeCount; j++) {
                    int currentElement = currentLine[j];
                    if (currentElement != 0) {
                        edgeList[counter] = (i, j, currentElement);
                        counter++;
                    }
                }
            }

            int[] parent = new int[nodeCount];
            for (int i = 0; i < nodeCount; i++) {
                parent[i] = i;
            }

            var mst = new System.Collections.Generic.List<(int, int, int)>();
            int sum = 0;
            foreach (var edge in edgeList.OrderBy(edge => edge.Item3).ToArray()) {
                int u = edge.Item1;
                int v = edge.Item2;
                int cost = edge.Item3;

                if (findParent(u) != findParent(v)) {
                    mst.Add(edge);
                    Console.WriteLine($"{u}-{v}: {cost}");
                    sum += cost;
                    union(u, v);
                }
            }
            Console.WriteLine(sum);

            int findParent(int x) {
                if (parent[x] != x) {
                    parent[x] = findParent(parent[x]);
                }
                return parent[x];
            }
  
            void union(int x, int y) {
                int py = findParent(y);
                int px = findParent(x);
                parent[py] = px;
            }
        }
    }
}