using System;
using System.Collections.Generic;

class ExpressionValidator
{
    static bool ValidateBrackets(string input)
    {
        var openStack = new Stack<char>();
        var match = new Dictionary<char, char>
        {
            ['('] = ')',
            ['['] = ']',
            ['{'] = '}'
        };

        foreach (var symbol in input)
        {
            if (match.ContainsKey(symbol))
            {
                openStack.Push(symbol);
            }
            else if (match.ContainsValue(symbol))
            {
                if (openStack.Count == 0 || match[openStack.Pop()] != symbol)
                {
                    return false;
                }
            }
        }

        return openStack.Count == 0;
    }

    static void Main()
    {
        Console.Write("Введите выражение: ");
        var input = Console.ReadLine();

        Console.WriteLine(ValidateBrackets(input) ? "Скобки расставлены верно" : "Ошибка в скобках");
    }
}
