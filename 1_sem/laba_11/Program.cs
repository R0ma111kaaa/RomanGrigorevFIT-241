using System;

public class Student
{
    public string FullName { get; set; }
    public int BirthYear { get; set; }
    public string MotherName { get; set; }
    public string FatherName { get; set; }
    public string Address { get; set; }

    public Student(string fullName, int birthYear, string motherName = null, string fatherName = null, string address = null)
    {
        FullName = fullName;
        BirthYear = birthYear;
        MotherName = motherName;
        FatherName = fatherName;
        Address = address;
    }

    public override string ToString()
    {
        return $"ФИО: {FullName}, Год рождения: {BirthYear}, Мама: {MotherName ?? "Информация отсутствует"}, Папа: {FatherName ?? "Информация отсутствует"}, Адрес: {Address ?? "Информация отсутствует"}";
    }
}

public class Program
{
    private static Student[] students = new Student[100];
    private static int studentCount = 0;

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nГлавное меню:");
            Console.WriteLine("1. Добавить данные об ученике");
            Console.WriteLine("2. Редактировать данные ученика");
            Console.WriteLine("3. Найти учеников по начальной букве ФИО");
            Console.WriteLine("4. Найти учеников по адресу");
            Console.WriteLine("5. Найти учеников по году рождения");
            Console.WriteLine("6. Выйти из программы");
            Console.Write("Выберите пункт: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    EditStudent();
                    break;
                case "3":
                    SearchByInitial();
                    break;
                case "4":
                    SearchByAddress();
                    break;
                case "5":
                    SearchByBirthYear();
                    break;
                case "6":
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    private static void AddStudent()
    {
        if (studentCount >= students.Length)
        {
            Console.WriteLine("Массив студентов заполнен.");
            return;
        }

        Console.Write("Введите ФИО ученика: ");
        string fullName = Console.ReadLine();
        Console.Write("Введите год рождения: ");
        int birthYear = int.Parse(Console.ReadLine());
        Console.Write("Введите имя матери (или пропустите): ");
        string motherName = Console.ReadLine();
        Console.Write("Введите имя отца (или пропустите): ");
        string fatherName = Console.ReadLine();
        Console.Write("Введите адрес проживания (или пропустите): ");
        string address = Console.ReadLine();

        students[studentCount++] = new Student(fullName, birthYear, motherName, fatherName, address);
        Console.WriteLine("Данные успешно сохранены.");
    }

    private static void EditStudent()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("Список студентов пуст.");
            return;
        }

        Console.Write("Введите ФИО ученика, данные которого нужно изменить: ");
        string nameToEdit = Console.ReadLine();

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].FullName.Equals(nameToEdit, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите обновленный год рождения: ");
                students[i].BirthYear = int.Parse(Console.ReadLine());
                Console.Write("Введите обновленное имя матери (или пропустите): ");
                students[i].MotherName = Console.ReadLine();
                Console.Write("Введите обновленное имя отца (или пропустите): ");
                students[i].FatherName = Console.ReadLine();
                Console.Write("Введите обновленный адрес (или пропустите): ");
                students[i].Address = Console.ReadLine();

                Console.WriteLine("Данные успешно обновлены.");
                return;
            }
        }

        Console.WriteLine("Ученик с указанным ФИО не найден.");
    }

    private static void SearchByInitial()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("Список студентов пуст.");
            return;
        }

        Console.Write("Введите первую букву ФИО: ");
        char initial = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        bool isFound = false;
        foreach (var student in students)
        {
            if (student != null && student.FullName.StartsWith(initial.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(student);
                isFound = true;
            }
        }

        if (!isFound)
        {
            Console.WriteLine($"Студенты, начинающиеся с буквы '{initial}', не найдены.");
        }
    }

    private static void SearchByAddress()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("Список студентов пуст.");
            return;
        }

        Console.Write("Введите адрес для поиска: ");
        string searchAddress = Console.ReadLine();

        bool isFound = false;
        foreach (var student in students)
        {
            if (student != null && !string.IsNullOrEmpty(student.Address) && student.Address.Contains(searchAddress, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(student);
                isFound = true;
            }
        }

        if (!isFound)
        {
            Console.WriteLine($"Студенты, проживающие по адресу '{searchAddress}', не найдены.");
        }
    }

    private static void SearchByBirthYear()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("Список студентов пуст.");
            return;
        }

        Console.Write("Введите год рождения для поиска: ");
        int birthYear = int.Parse(Console.ReadLine());

        bool isFound = false;
        foreach (var student in students)
        {
            if (student != null && student.BirthYear == birthYear)
            {
                Console.WriteLine(student);
                isFound = true;
            }
        }

        if (!isFound)
        {
            Console.WriteLine($"Студенты, родившиеся в {birthYear} году, не найдены.");
        }
    }
}
