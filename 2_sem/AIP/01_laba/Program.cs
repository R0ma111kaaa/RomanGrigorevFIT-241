using System;
using System.Collections.Generic;

class Contact
{
    public string FullName { get; set; }
    public List<string> Numbers { get; set; }
    public string Carrier { get; set; }
    public int ActivationYear { get; set; }
    public string Location { get; set; }

    public Contact(string fullName, List<string> numbers, string carrier, int activationYear, string location)
    {
        FullName = fullName;
        Numbers = numbers;
        Carrier = carrier;
        ActivationYear = activationYear;
        Location = location;
    }

    public override string ToString()
    {
        return $"Контакт: {FullName}, Телефоны: {string.Join(", ", Numbers)}, Сеть: {Carrier}, Год: {ActivationYear}, Регион: {Location}";
    }
}

class ContactBook
{
    private List<Contact> entries = new List<Contact>();

    private void CreateEntry()
    {
        Console.Write("Имя: ");
        var name = Console.ReadLine();

        Console.Write("Телефоны через запятую: ");
        var phones = new List<string>(Console.ReadLine().Split(','));

        Console.Write("Сотовый оператор: ");
        var network = Console.ReadLine();

        Console.Write("Год подключения: ");
        var year = int.Parse(Console.ReadLine());

        Console.Write("Город: ");
        var region = Console.ReadLine();

        entries.Add(new Contact(name, phones, network, year, region));
        Console.WriteLine("Контакт добавлен");
    }

    private void SearchByCarrier()
    {
        Console.Write("Введите оператора: ");
        var input = Console.ReadLine();
        var found = entries.FindAll(c => c.Carrier.Equals(input, StringComparison.OrdinalIgnoreCase));

        if (found.Count > 0)
            foreach (var c in found) Console.WriteLine(c);
        else
            Console.WriteLine("Ничего не найдено");
    }

    private void SearchByYear()
    {
        Console.Write("Введите год: ");
        int y = int.Parse(Console.ReadLine());
        var results = entries.FindAll(c => c.ActivationYear == y);

        if (results.Count > 0)
            foreach (var c in results) Console.WriteLine(c);
        else
            Console.WriteLine("Ничего не найдено");
    }

    private void SearchByNumber()
    {
        Console.Write("Введите номер: ");
        string num = Console.ReadLine().Trim();
        var matches = entries.FindAll(c => c.Numbers.Contains(num));

        if (matches.Count > 0)
            foreach (var c in matches) Console.WriteLine(c);
        else
            Console.WriteLine("Ничего не найдено");
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Новый контакт");
            Console.WriteLine("2. Поиск по оператору");
            Console.WriteLine("3. Поиск по году");
            Console.WriteLine("4. Поиск по номеру");
            Console.WriteLine("5. Завершить");

            Console.Write("Номер опции: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": CreateEntry(); break;
                case "2": SearchByCarrier(); break;
                case "3": SearchByYear(); break;
                case "4": SearchByNumber(); break;
                case "5": return;
                default: Console.WriteLine("Некорректный ввод"); break;
            }
        }
    }
}

class EntryPoint
{
    static void Main(string[] args)
    {
        var book = new ContactBook();
        book.Start();
    }
}
