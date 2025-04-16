using System;
using System.Collections.Generic;

public class RPNProcessor
{
    public static double Evaluate(string input)
    {
        var memory = new Stack<double>();
        var elements = input.Split(' ');

        foreach (var item in elements)
        {
            if (double.TryParse(item, out double value))
            {
                memory.Push(value);
                continue;
            }

            if (memory.Count < 2)
            {
                throw new InvalidOperationException("Недостаточно данных для выполнения операции");
            }

            double b = memory.Pop();
            double a = memory.Pop();
            double output;

            switch (item)
            {
                case "+":
                    output = a + b;
                    break;
                case "-":
                    output = a - b;
                    break;
                case "*":
                    output = a * b;
                    break;
                case "/":
                    if (b == 0) throw new DivideByZeroException("Попытка деления на ноль");
                    output = a / b;
                    break;
                default:
                    throw new InvalidOperationException($"Оператор не распознан: {item}");
            }

            memory.Push(output);
        }

        if (memory.Count != 1)
        {
            throw new InvalidOperationException("Ошибка в структуре выражения");
        }

        return memory.Pop();
    }

    public static void Main(string[] args)
    {
        Console.Write("Введите постфикс-выражение: ");
        string userInput = Console.ReadLine();

        try
        {
            double finalResult = Evaluate(userInput);
            Console.WriteLine($"Ответ: {finalResult}");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Произошла ошибка: {error.Message}");
        }
    }
}
