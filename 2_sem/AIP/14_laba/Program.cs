class Program
{

    class ComputerModel
    {
        public int ID { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
    }

    class OperatingSystem
    {
        public int ID { get; set; }
        public required string Name { get; set; }
    }

    class User
    {
        public int UserID { get; set; }
        public required string FullName { get; set; }
        public bool HasLaptop { get; set; }
        public string? LaptopBrand { get; set; }
        public int? OS_ID { get; set; }
    }
     static void Main()
    {
        var computerModels = new List<ComputerModel>
        {
            new ComputerModel { ID = 1, Brand = "HP", Model = "s" },
            new ComputerModel { ID = 2, Brand = "Dell", Model = "m" },
            new ComputerModel { ID = 3, Brand = "Lenovo", Model = "m5" }
        };

        var operatingSystems = new List<OperatingSystem>
        {
            new OperatingSystem { ID = 1, Name = "Windows 10" },
            new OperatingSystem { ID = 2, Name = "Ubuntu" },
            new OperatingSystem { ID = 3, Name = "macOS" }
        };

        var users = new List<User>
        {
            new User { UserID = 1, FullName = "Ушаков В.", HasLaptop = true, LaptopBrand = "HP", OS_ID = 1 },
            new User { UserID = 2, FullName = "Россинский А.", HasLaptop = true, LaptopBrand = "Dell", OS_ID = 2 },
            new User { UserID = 3, FullName = "Кравченко В.", HasLaptop = false, LaptopBrand = null, OS_ID = null },
            new User { UserID = 4, FullName = "Кудинов К.", HasLaptop = true, LaptopBrand = "Lenovo", OS_ID = 1 },
            new User { UserID = 5, FullName = "Снижний Р.", HasLaptop = false, LaptopBrand = null, OS_ID = null }
        };

        // 1. Группировка по наличию компьютера
        Console.WriteLine("1. Пользователи по наличию ноутбука:");
        var groupByLaptop = users.GroupBy(u => u.HasLaptop);
        foreach (var group in groupByLaptop)
        {
            Console.WriteLine(group.Key ? "С ноутбуком:" : "Без ноутбука:");
            foreach (var user in group)
                Console.WriteLine($"  {user.FullName}");
        }

        // 2. по марке
        Console.WriteLine("\n2. Пользователи по марке ноутбука:");
        var groupByBrand = users
            .Where(u => u.HasLaptop)
            .GroupBy(u => u.LaptopBrand);
        foreach (var group in groupByBrand)
        {
            Console.WriteLine($"Марка: {group.Key}");
            foreach (var user in group)
                Console.WriteLine($"  {user.FullName}");
        }

        // 3. по ос
        Console.WriteLine("\n3. Пользователи по операционной системе:");
        var groupByOS = users
            .Where(u => u.HasLaptop)
            .GroupBy(u => u.OS_ID)
            .Select(g => new
            {
                OSName = operatingSystems.FirstOrDefault(os => os.ID == g.Key)?.Name ?? "Нет ОС",
                Users = g
            });
        foreach (var group in groupByOS)
        {
            Console.WriteLine($"ОС: {group.OSName}");
            foreach (var user in group.Users)
                Console.WriteLine($"  {user.FullName}");
        }

        // 4. Все данные: ФИО, наличие ноутбука, марка, модель, ОС
        Console.WriteLine("\n4. Все данные:");
        var allData = from u in users
                      join cm in computerModels on u.LaptopBrand equals cm.Brand into cmJoin
                      from cm in cmJoin.DefaultIfEmpty()
                      join os in operatingSystems on u.OS_ID equals os.ID into osJoin
                      from os in osJoin.DefaultIfEmpty()
                      select new
                      {
                          u.FullName,
                          u.HasLaptop,
                          Brand = cm?.Brand ?? "—",
                          Model = cm?.Model ?? "—",
                          OS = os?.Name ?? "—"
                      };

        foreach (var entry in allData)
        {
            Console.WriteLine($"{entry.FullName} | Ноутбук: {(entry.HasLaptop ? "Да" : "Нет")}, Марка: {entry.Brand}, Модель: {entry.Model}, ОС: {entry.OS}");
        }
    }
}