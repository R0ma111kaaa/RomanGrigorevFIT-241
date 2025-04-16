using System;
using System.Linq;
using System.Collections.Generic;

class EntryPoint
{
    static void Main(string[] input)
    {
        var data = new List<int> {5, 1, 2, 2, 5, 3, 4, 4, 4, 5};
        var distinctValues = data.Distinct();
        var occurrences = data.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        Console.WriteLine("Неповторяющиеся значения:");
        foreach (var val in distinctValues)
        {
            Console.WriteLine(val);
        }

        Console.WriteLine("\nСколько раз встречается каждое значение:");
        foreach (var pair in occurrences)
        {
            Console.WriteLine($"Значение {pair.Key} найдено {pair.Value} раз(а)");
        }
    }
}
