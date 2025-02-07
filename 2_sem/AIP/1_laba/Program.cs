using System;
using System.Collections.Generic;
using System.Linq;

namespace laba_1 {
    static class Program {
        public static void Main() {
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            while (true) {
                Console.WriteLine("Телефонный справочник:");
                Console.WriteLine("1. Добавить запись");
                Console.WriteLine("2. Выборка по оператору связи");
                Console.WriteLine("3. Выборка по году подключения");
                Console.WriteLine("4. Выборка по номеру телефона");
                Console.WriteLine("5. Выход");
                Console.Write("Введите номер операции: ");
                string choice = Console.ReadLine();

                switch (choice) {
                    case "1":
                        AddPerson(data);
                        break;
                    case "2":
                        FilterByProvider(data);
                        break;
                    case "3":
                        FilterByYear(data);
                        break;
                    case "4":
                        FilterByNumber(data);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        // Добавление записи
        private static void AddPerson(List<Dictionary<string, string>> data) {
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Введите номер телефона: ");
            string number = Console.ReadLine();
            Console.Write("Введите оператора связи: ");
            string provider = Console.ReadLine();
            Console.Write("Введите год подключения: ");
            string year = Console.ReadLine();
            Console.Write("Введите город проживания: ");
            string city = Console.ReadLine();

            data.Add(new Dictionary<string, string> {
                { "name", name },
                { "number", number },
                { "provider", provider },
                { "year", year },
                { "city", city }
            });

            Console.WriteLine("Запись успешно добавлена.");
        }

        // Выборка по оператору связи
        private static void FilterByProvider(List<Dictionary<string, string>> data) {
            Console.Write("Введите оператора связи для поиска: ");
            string provider = Console.ReadLine();

            var result = data.Where(person => person["provider"].ToLower() == provider.ToLower()).ToList();
            DisplayResults(result);
        }

        // Выборка по году подключения
        private static void FilterByYear(List<Dictionary<string, string>> data) {
            Console.Write("Введите год подключения для поиска: ");
            string year = Console.ReadLine();

            var result = data.Where(person => person["year"] == year).ToList();
            DisplayResults(result);
        }

        // Выборка по номеру телефона
        private static void FilterByNumber(List<Dictionary<string, string>> data) {
            Console.Write("Введите номер телефона для поиска: ");
            string number = Console.ReadLine();

            var result = data.Where(person => person["number"] == number).ToList();
            DisplayResults(result);
        }

        // Отображение результатов выборки
        private static void DisplayResults(List<Dictionary<string, string>> result) {
            if (result.Count == 0) {
                Console.WriteLine("По вашему запросу ничего не найдено.");
            } else {
                foreach (var person in result) {
                    Console.WriteLine($"ФИО: {person["name"]}, Номер: {person["number"]}, Оператор: {person["provider"]}, Год подключения: {person["year"]}, Город: {person["city"]}");
                }
            }
        }
    }
}
