using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество элементов последовательности: ");
        int n = int.Parse(Console.ReadLine());
        // task 1
        int maxCountSameElems = 1, currentCountSameElems = 1;
        // task 2
        int minCountEvenElems = int.MaxValue, currentCountEvenElems;
        // task 3
        int maxSumEvenElems, currentSumEvenElems;


        int num, abs_num;
        Console.WriteLine("Вводите элементы через Enter: ");
        int previous = int.Parse(Console.ReadLine());
        currentCountEvenElems = previous % 2 == 0 ? 1 : 0;
        maxSumEvenElems = currentSumEvenElems = previous % 2 == 0? previous : 0;
        for (int i = 1; i < n; i++)
        {
            num = int.Parse(Console.ReadLine());
            abs_num = Math.Abs(num);
            // 1 задача

            if (num == previous) {
                currentCountSameElems++;
            } else {
                currentCountSameElems = 1;
            }
            if (currentCountSameElems > maxCountSameElems) {
                maxCountSameElems = currentCountSameElems;
            }
            // 2 задача
            if (Math.Abs(num)% 2 == 0) {
                currentCountEvenElems++;
            } else {
                if (currentCountEvenElems > 0 && currentCountEvenElems < minCountEvenElems) {
                    minCountEvenElems = currentCountEvenElems;
                }
                currentCountEvenElems = 0;
            }
            // 3 задача
            if (Math.Abs(num)% 2 == 0) {
                currentSumEvenElems += num;
            } else {
                currentSumEvenElems = 0;
            }
            if (maxSumEvenElems < currentSumEvenElems) {
                    maxSumEvenElems = currentSumEvenElems;
            }

            // finally
            previous = num;
        }
        if (currentCountEvenElems > 0 && currentCountEvenElems < minCountEvenElems) {
                    minCountEvenElems = currentCountEvenElems;
        }
        Console.WriteLine($"ответ на задание 1: {maxCountSameElems} (максимальный размер последовательности из одинаковых элементов)");
        Console.WriteLine($"ответ на задание 2: {(minCountEvenElems == int.MaxValue ? 0 : minCountEvenElems)} (минимальный размер последовательности из четных)");
        Console.WriteLine($"ответ на задание 3: {maxSumEvenElems} (макс сумма последовательности из четных)");

    }
}
