using System;

class Program {
    static void Main() {
        bool all_even = true;
        Console.WriteLine("Введите количество элементов: ");
        int quan = int.Parse(Console.ReadLine());
        for (int i = 0; i < quan; i++) {
            int element = int.Parse(Console.ReadLine());
            if (element % 2 != 0) all_even = false;
        }
        if (all_even) {
            Console.WriteLine("Все четные");
        } else {
            Console.WriteLine("Есть нечетные");
        }
    }
}
