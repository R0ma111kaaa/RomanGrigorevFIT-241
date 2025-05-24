namespace Graphs1 {
    static class Program {
        public static void Main() {
            Console.WriteLine("Введите количество узлов: ");
            int width = int.Parse(Console.ReadLine());
            bool[][] netMatrix = new bool[width][];
            for (int i = 0; i < width; i++) {
                string input = Console.ReadLine();
                netMatrix[i] = input.Split(" ").Select(x => x == "1").ToArray();
            }
            // bool[][] netMatrix = new bool[][] {
            //     new bool[] {false, true, true, false, false, false, false, false},
            //     new bool[] {true, false, true, false, false, false, true, false},
            //     new bool[] {true, true, false, true, false, false, false, false},
            //     new bool[] {false, false, true, false, false, false, true, false},
            //     new bool[] {false, false, false, false, false, false, false, false},
            //     new bool[] {false, false, false, false, false, false, true, false},
            //     new bool[] {false, true, false, true, false, true, false, true},
            //     new bool[] {false, false, false, false, false, false, true, false},
            // };
            var Nodes = Enumerable.Range(0, width).ToList();
            List<List<int>> netComps = new List<List<int>>();
            List<int> currentNetComps = new List<int>();
            int Current = 0;
            while (true) {
                currentNetComps.Add(Current);
                Nodes.Remove(Current);
                for (int i = 0; i < width; i++) {
                    int currentNode;
                    if (currentNetComps.Count() > i)
                    {
                        currentNode = currentNetComps[i];
                    }
                    else { break; }
                    for (int j = Current; j < width; j++) {
                        if (netMatrix[currentNode][j] && (Nodes.Contains(j))) {
                            currentNetComps.Add(j);
                            Nodes.Remove(j);
                        }
                    }
                }
                netComps.Add(new List<int>(currentNetComps));
                currentNetComps.Clear();
                if (Nodes.Count != 0) {
                    Current = Nodes[0];
                    continue;
                } else {
                    break;
                }
            }
            Console.WriteLine("\nКомпоненты (каждая на новой строке): ");
            foreach (var nc in netComps) {
                Console.WriteLine(string.Join(", ", nc));
            }
        }
    }
}