using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество элементов в массиве: ");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[5];
        Console.WriteLine("Вводите элементы через энтер: ");
        for (int i = 0; i < n; i++) {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\n\n");
        
        int current;
        // Task 1
        int counter = 0;
        int last;
        int[] evenOnly = new int[n];
        int index = 0;
        for (int i = 0; i < n; i++) {
            current = numbers[i];
            bool is_even = true;
            while (current != 0) {
                last = current % 10;
                if (last % 2 == 1) {
                    is_even = false;
                    break;
                } else {
                    current /= 10;
                }
            }
            if (is_even) {
                evenOnly[index] = numbers[i];
                index++;
            }
        }
        Console.WriteLine("Ответ 1 (Количество эл. со всеми четными): " + index.ToString());

        // Task 2
        int[] boolean = new int[n];
        Console.Write("Ответ 2 (Четные - 0, нечетные 1): ");
        for (int i = 0; i < n; i++) {
            current = numbers[i] % 2 == 0 ? 0 : 1;
            Console.Write(current.ToString() + " ");
        }

        // Task 3
        int[] result = new int[n];
        int resCounter = 0;
        for (int i = 0; i < n; i++) {
            if (numbers[i] % 2 == 0) {
                result[resCounter] = numbers[i];
                resCounter++;
            }
        }
        for (int i = 0; i < n; i++) {
            if (numbers[i] % 2 == 1) {
                result[resCounter] = numbers[i];
                resCounter++;
            }
        }
        Console.Write("\nМассив сначала четные, потом нечетные: ");
        for (int i = 0; i < n; i++) {
            Console.Write(result[i].ToString() + " ");
        }
    }
}
