using System;
using System.Collections.Generic;


// Форд-Буеллман 

class Edge
{
    public int From, To, Weight;
    public Edge(int from, int to, int weight)
    {
        From = from;
        To = to;
        Weight = weight;
    }
}

class Program
{
    public static void Main()
    {
        int vertices = 5;
        int edgesCount = 8;
        int source = 0;

        // ПРИМЕР списка ребер графа
        List<Edge> edges = new List<Edge>
        {
            new Edge(0, 1, 6),
            new Edge(0, 2, 7),
            new Edge(1, 2, 8),
            new Edge(1, 3, -4),
            new Edge(1, 4, 5),
            new Edge(2, 3, 9),
            new Edge(2, 4, -3),
            new Edge(3, 1, -2),
            new Edge(4, 3, 7)
        };

        int[] distance = new int[vertices];
        for (int i = 0; i < vertices; i++)
            distance[i] = int.MaxValue;

        distance[source] = 0;

        // Основной цикл: V - 1 раз релаксируем все рёбра
        for (int i = 1; i < vertices; i++)
        {
            foreach (var edge in edges)
            {
                if (distance[edge.From] != int.MaxValue && distance[edge.From] + edge.Weight < distance[edge.To])
                {
                    distance[edge.To] = distance[edge.From] + edge.Weight;
                }
            }
        }

        // Проверка на наличие отрицательного цикла
        foreach (var edge in edges)
        {
            if (distance[edge.From] != int.MaxValue && distance[edge.From] + edge.Weight < distance[edge.To])
            {
                Console.WriteLine("Граф содержит цикл отрицательного веса");
                return;
            }
        }

        // Вывод результата
        Console.WriteLine("Кратчайшие расстояния от вершины " + source + ":");
        for (int i = 0; i < vertices; i++)
        {
            Console.WriteLine($"До вершины {i}: {(distance[i] == int.MaxValue ? "∞" : distance[i].ToString())}");
        }
    }
}
