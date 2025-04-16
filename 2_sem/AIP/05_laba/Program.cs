using System;
using System.Collections.Generic;

class Contact
{
    public string Number { get; set; }
    public string Owner { get; set; }
    public string Provider { get; set; }

    public Contact(string number, string owner, string provider)
    {
        Number = number;
        Owner = owner;
        Provider = provider;
    }
}

class EntryPoint
{
    static void Main(string[] args)
    {
        var entries = new List<Contact>
        {
            new Contact("1234567890", "Иванов Иван", "МТС"),
            new Contact("0987654321", "Петров Петр", "Билайн"),
            new Contact("1112223333", "Сидоров Сидор", "Билайн"),
            new Contact("4445556666", "Кузнецов Кузьма", "Теле2"),
            new Contact("7778889999", "Иванов Иван", "МТС"),
            new Contact("2223334445", "Петров Петр", "Билайн"),
        };

        var popularProvider = GetTopProvider(entries);
        Console.WriteLine($"Самый популярный провайдер: {popularProvider}");
    }

    static string GetTopProvider(List<Contact> contacts)
    {
        var stats = new Dictionary<string, int>();

        foreach (var entry in contacts)
        {
            if (!stats.TryAdd(entry.Provider, 1))
                stats[entry.Provider]++;
        }

        string leader = null;
        int highest = 0;

        foreach (var item in stats)
        {
            if (item.Value > highest)
            {
                highest = item.Value;
                leader = item.Key;
            }
        }

        return leader;
    }
}
