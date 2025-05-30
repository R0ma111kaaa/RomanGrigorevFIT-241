using System;
using System.Collections.Generic;
using System.Linq;


class Phone
{
    public string? Brand { get; set; }
    public int? Year { get; set; }
    public string? Country { get; set; }

    public override string ToString()
    {
        return $"Марка: {Brand ?? "нету"}, Год: {Year?.ToString() ?? "нету"}, Страна: {Country ?? "нету"}";
    }
}

class Program
{
    static List<Phone> phones = new List<Phone>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить телефон");
            Console.WriteLine("2. Сгруппировать телефоны по стране");
            Console.WriteLine("3. Вывести телефоны по заданному году выпуска");
            Console.WriteLine("4. Сгруппировать телефоны по марке");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите пункт меню: ");

            string? input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    AddPhone();
                    break;
                case "2":
                    GroupByCountry();
                    break;
                case "3":
                    FilterByYear();
                    break;
                case "4":
                    GroupByBrand();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Повторите попытку.");
                    break;
            }
        }
    }

    static void AddPhone()
    {
        Console.Write("Введите марку телефона: ");
        string? brand = Console.ReadLine();

        Console.Write("Введите год выпуска: ");
        string? answer = Console.ReadLine();
        int? year = !string.IsNullOrWhiteSpace(answer) ? int.Parse(answer) : null;

        Console.Write("Введите страну использования: ");
        string? country = Console.ReadLine();

        phones.Add(new Phone { Brand = brand, Year = year, Country = country });
        Console.WriteLine("Телефон добавлен.");
    }

    static void GroupByCountry()
    {
        var grouped = phones.GroupBy(p => p.Country);

        foreach (var group in grouped)
        {
            Console.WriteLine($"\nСтрана: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  {phone}");
            }
        }
    }

    static void FilterByYear()
    {
        Console.Write("Введите нужный год выпуска: ");
        string? anwser = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(anwser))
        {
            Console.WriteLine("эта пустая строка чел...");
            return; 
        }
        int year = int.Parse(Console.ReadLine()!);

        var filtered = phones.Where(p => p.Year == year);

        Console.WriteLine($"\nТелефоны, выпущенные в {year} году:");
        foreach (var phone in filtered)
        {
            Console.WriteLine(phone);
        }
    }

    static void GroupByBrand()
    {
        var grouped = phones.GroupBy(p => p.Brand);

        foreach (var group in grouped)
        {
            Console.WriteLine($"\nМарка: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  {phone}");
            }
        }
    }
}

