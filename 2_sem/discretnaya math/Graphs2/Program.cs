using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs2
{
    static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите количество узлов: ");
            int width = int.Parse(Console.ReadLine());
            bool[][] netMatrix = new bool[width][];

            for (int i = 0; i < width; i++)
            {
                string input = Console.ReadLine();
                netMatrix[i] = input.Split(" ").Select(x => x == "1").ToArray();
            }

            // Инициализируем список для хранения компонента связности для каждого узла
            int[] components = new int[width];
            for (int i = 0; i < width; i++) components[i] = i; // Каждый узел инициализируется своим номером

            // Функция для поиска начального узла компонента связности
            int Find(int node)
            {
                if (components[node] != node)
                    components[node] = Find(components[node]);
                return components[node];
            }

            // Проходим по всем парам узлов в порядке возрастания индексов
            for (int i = 0; i < width; i++)
            {
                for (int j = i + 1; j < width; j++)
                {
                    if (netMatrix[i][j])
                    {
                        // Находим компоненты для двух узлов
                        int componentI = Find(i);
                        int componentJ = Find(j);

                        // Если компоненты разные, объединяем их, присваивая меньший номер
                        if (componentI != componentJ)
                        {
                            if (componentI < componentJ)
                            {
                                components[componentJ] = componentI;
                            }
                            else
                            {
                                components[componentI] = componentJ;
                            }
                        }
                    }
                }
            }

            // Создаём список для отображения компонентов связности
            Dictionary<int, List<int>> connectedComponents = new Dictionary<int, List<int>>();
            for (int i = 0; i < width; i++)
            {
                int componentRoot = Find(i);
                if (!connectedComponents.ContainsKey(componentRoot))
                {
                    connectedComponents[componentRoot] = new List<int>();
                }
                connectedComponents[componentRoot].Add(i);
            }

            // Выводим компоненты связности
            Console.WriteLine("\nКомпоненты (каждая на новой строке): ");
            foreach (var component in connectedComponents.Values)
            {
                Console.WriteLine(string.Join(", ", component));
            }
        }
    }
}
