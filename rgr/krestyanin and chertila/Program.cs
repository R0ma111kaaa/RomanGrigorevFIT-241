using System;


class MainClass
{
    static void Main()
    {
        int totalCount = 0;
        const int upperLimit = 1000;

        for (int number = 1; number <= upperLimit; number++)
        {
            for (int step = 2; step <= number * 1.34; step += 2)
            {
                int tempValue = number;

                for (int iteration = 1; iteration <= 20; iteration++)
                {
                    tempValue = tempValue * 2 - step;

                    if (tempValue == 0)
                    {
                        totalCount++;
                        break;
                    }

                    if (tempValue < 0)
                    {
                        break;
                    }
                }
            }
        }

        Console.WriteLine(totalCount + upperLimit);
    }
}
