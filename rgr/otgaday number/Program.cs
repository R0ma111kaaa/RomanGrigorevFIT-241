using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("input_s1_01.txt"))
        {
            int n = int.Parse(reader.ReadLine());
            int a = 1, b = 0;

            for (int i = 0; i < n; i++)
            {
                string[] parts = reader.ReadLine().Split(' ');
                char operation = parts[0][0];
                string operand = parts[1];

                int value = operand == "x" ? 1 : int.Parse(operand);

                switch (operation)
                {
                    case '+':
                        if (operand == "x")
                            a++;
                        else
                            b += value;
                        break;
                    case '-':
                        if (operand == "x")
                            a--;
                        else
                            b -= value;
                        break;
                    case '*':
                        a *= value;
                        b *= value;
                        break;
                }
            }

            int r = int.Parse(reader.ReadLine());
            int x = (r - b) / a;

            Console.WriteLine(x);
        }
    }
}
