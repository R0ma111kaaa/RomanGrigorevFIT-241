using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        
        Console.Write("Введите исходную строку: ");
        string input = Console.ReadLine();

        // Task 1

        // Убираем лишние пробелы, оставляя между словами ровно по одному пробелу
        string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string formattedString = string.Join(" ", words);
        Console.WriteLine("1) Отформатированная строка: " + formattedString);

        // Task 2

        Console.Write("2) Палиндромы: ");
        foreach (string word in words) {
            string newWord = isPalindrome(word) ? word + " " : "";
            Console.Write(newWord);
        }
        Console.WriteLine();

        // Task 3
        string answer = isPalindrome(formattedString) ? "Строка является палиндромом" : "Строка не является палиндромом";
        Console.WriteLine($"3){answer}");

        // Task 4

        // ввод
        Console.WriteLine("------------------" + "Задание 4" + "------------------");
        Console.WriteLine("Вводите строки через ENTER (конец ввода - пустая строка):");
        List<string> strings = new List<string>();

        string new_str;
        while (!string.IsNullOrEmpty(input = Console.ReadLine())) {
            strings.Add(input);
        }
        Console.WriteLine("Строки, в которых количество гласных больше, чем количество согласных:");
        foreach (string str in strings) {
            if (moreVowel(str.ToLower())) {
                Console.WriteLine(str);
            }
        }
        
    }

    static bool isPalindrome(string word) {
        int length = word.Length;
        for (int i = 0; i < length / 2; i++) {
            if (word[i] != word[length-i-1]) {
                return false;
            }
        }    
        return true;
    }

    static bool moreVowel(string str) {
        // aлфавит
        HashSet<char> vowelLetters = new HashSet<char>("аеёиоуыэюя");
        HashSet<char> consonantLetters = new HashSet<char>("бвгджзйклмнпрстфхцчшщьъ");

        int vowelCounter = 0;
        int consonantCounter = 0;
        for (int i = 0; i < str.Length; i++) {
            if (vowelLetters.Contains(str[i])) {
                vowelCounter++;
            } else if (consonantLetters.Contains(str[i])) {
                consonantCounter++;
            }
        }
        return vowelCounter > consonantCounter;
    }
}
