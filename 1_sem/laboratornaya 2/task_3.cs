using System;

class Program {
    static void Main() {
        Console.WriteLine("Введите количество элементов: ");
        int quan = int.Parse(Console.ReadLine());
        Console.WriteLine($"Введите {quan} элементов: ");
        int max1 = int.Parse(Console.ReadLine());
        int max2 = int.Parse(Console.ReadLine());
        
        if (max1 < max2) {
            int temp = max1;
            max1 = max2;
            max2 = temp;
        }
        
        for (int i = 0; i < quan - 2; i++) {
            int element = int.Parse(Console.ReadLine());
            if (element > max1) {
                max2 = max1;
                max1 = element;
            } else if (element > max2) {
                max2 = element;
            }
        }
        Console.WriteLine($"Максимумы: {max1}, {max2};");
    }
}