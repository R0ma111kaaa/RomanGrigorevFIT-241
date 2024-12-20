using System;

class MyClass
{
    // Поля
    private int value1;
    private int value2;

    // Конструктор без аргументов
    public MyClass()
    {
        value1 = 0;
        value2 = 0;
    }

    // Конструктор с одним аргументом
    public MyClass(int v1)
    {
        value1 = v1;
        value2 = 0;
    }

    // Конструктор с двумя аргументами
    public MyClass(int v1, int v2)
    {
        value1 = v1;
        value2 = v2;
    }

    // Метод для суммирования двух переменных
    public int Sum()
    {
        return value1 + value2;
    }

    // Метод для произведения двух переменных
    public int Multiply()
    {
        return value1 * value2;
    }

    // Метод для разности двух переменных
    public int Subtract()
    {
        return value1 - value2;
    }

    // Метод для деления первого аргумента на второй
    public double Divide()
    {
        if (value2 == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль!");
            return double.NaN; // Возвращаем "не число", если деление невозможно
        }
        return (double)value1 / value2;
    }
}

class Program
{
    static void Main()
    {
        MyClass obj1 = new MyClass();
        Console.WriteLine($"Сумма: {obj1.Sum()}");
        Console.WriteLine($"Произведение: {obj1.Multiply()}");
        Console.WriteLine($"Разность: {obj1.Subtract()}");
        Console.WriteLine($"Деление: {obj1.Divide()}");
        
        Console.WriteLine();

        MyClass obj2 = new MyClass(5); // Конструктор с одним аргументом
        Console.WriteLine($"Сумма: {obj2.Sum()}");
        Console.WriteLine($"Произведение: {obj2.Multiply()}");
        Console.WriteLine($"Разность: {obj2.Subtract()}");
        Console.WriteLine($"Деление: {obj2.Divide()}");

        Console.WriteLine();

        MyClass obj3 = new MyClass(10, 2); // Конструктор с двумя аргументами
        Console.WriteLine($"Сумма: {obj3.Sum()}");
        Console.WriteLine($"Произведение: {obj3.Multiply()}");
        Console.WriteLine($"Разность: {obj3.Subtract()}");
        Console.WriteLine($"Деление: {obj3.Divide()}");
    }
}
