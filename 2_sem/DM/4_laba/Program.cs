class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество узлов в графе:");
        int nodeCount = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Введите номер точки, длины путей от которой искать (с нуля нумерация): ");
        int startNodeIndex = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите весовую матрицу отношений");
        Console.WriteLine("строки отделяются пробелом, столбцы отделяются энтером");

        int[][] matrix = new int[nodeCount][];
        for (int i = 0; i < nodeCount; i++)
        {
            string line = Console.ReadLine();
            matrix[i] = line.Trim().Split(' ').Select(int.Parse).ToArray();
        }

        // непосредственно Алгоритм Дейкстры
        int[] distances = new int[nodeCount];
        int[] previous = new int[nodeCount];
        bool[] visited = new bool[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            distances[i] = int.MaxValue;
            previous[i] = -1;
            visited[i] = false;
        }
        distances[startNodeIndex] = 0;

        for (int count = 0; count < nodeCount; count++)
        {
            int minDistance = int.MaxValue;
            int currentNode = -1;

            for (int i = 0; i < nodeCount; i++)
            {
                if (!visited[i] && distances[i] < minDistance)
                {
                    minDistance = distances[i];
                    currentNode = i;
                }
            }

            if (currentNode == -1) break; // все доступные узлы посещены и граф не связный

            visited[currentNode] = true;

            // Обновляем расстояния до соседей
            for (int i = 0; i < nodeCount; i++)
            {
                if (!visited[i] && matrix[currentNode][i] > 0) // проверяем, есть ли ребро
                {
                    int newDistance = distances[currentNode] + matrix[currentNode][i];
                    if (newDistance < distances[i])
                    {
                        distances[i] = newDistance;
                        previous[i] = currentNode;
                    }
                }
            }
        }

        // Вывод результатов
        for (int i = 0; i < nodeCount; i++)
        {
            if (distances[i] == int.MaxValue)
                Console.WriteLine($"Длина пути {startNodeIndex}->{i} недостижима");
            else
                Console.WriteLine($"Длина пути {startNodeIndex}->{i} равна {distances[i]}, предыдущий узел: {previous[i]}");
        }
    }
}