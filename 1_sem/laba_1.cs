using System;
using System.IO;
using System.Threading.Channels;
namespace roma111kaaa
{
    class Program
    {
        static void Main()
        {
            int a = 14;
            int b = 24;
            // 1 задача
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine(a);
            Console.WriteLine(b);

            // 2 задача
            double c = Math.Abs(a - b);
            Math.Round(c);
            double d = Math.Abs(a + b);
            Math.Round(d);
            Console.WriteLine(c/2 + d/2);

            // 3 задача
            // пусть kol - количество грядок, l - расстояние от колодца до первой грядки, n - ширина (параллельная дороге до колодца), m - длина
            int kol = 3;
            int l = 2;
            int n = 4;
            int m = 5;
            Console.WriteLine(m*2*kol+n*kol+n*kol*kol+l*2*kol);
        }   
    }
}