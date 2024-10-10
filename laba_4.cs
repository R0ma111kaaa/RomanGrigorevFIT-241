using System;
namespace savage
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите числа");
           
            while (true)
            {
                int a = int.Parse(Console.ReadLine());
                if (a<0)
                {
                    break;
                }
                int razryad = 1;
                int otv = 0;
                while (a>0)
                {
                    if ((a%10)%2==1)
                    {
                        otv += (a % 10) * razryad;
                        razryad *= 10;
                    }
                    a/= 10;
                }
                if (otv == 0) {
                    Console.WriteLine("Нет нечетных цифр");
                } else {
                    int new_otv = 0;
                    while (otv != 0) {
                        new_otv = new_otv * 10 + otv % 10;
                        otv /= 10;
                    }
                    Console.WriteLine(new_otv);
                }
            } 
        }
    }
}