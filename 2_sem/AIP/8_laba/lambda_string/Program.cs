using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var list = new List<string> 
        {
            "мир", "привет", "молоко", "яблоко", "машина", "книга", "медведь"
        };

        var selectedWords = list.Where(item => item.StartsWith("м")).ToList();

        Console.WriteLine("Слова с буквы 'м':");
        selectedWords.ForEach(Console.WriteLine);
    }
}
