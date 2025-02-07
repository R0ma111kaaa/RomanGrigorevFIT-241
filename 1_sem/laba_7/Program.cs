using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        // Задание 1. Дан ступенчатый массив, размерностью 4 (4 ссылки на массивы)
        // задать размерность и элементы каждого массива

        // для каждого массива определить количество четных и нечетных элементов

        int[][] mass = new int[4][];

        for (int x = 0; x < 4; x++)
        {
            Console.Write("Введите количество элементов текущего массива: ");
            int n = int.Parse(Console.ReadLine());
            mass[x] = new int[n];

            Console.WriteLine("Вводите элементы массива: ");
            for (int i = 0; i < n; i++)
            {
                mass[x][i] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine();
        Console.WriteLine("\n_______________________________ЗАДАНИЕ 1_________________________________\n");
        for (int i =0; i < 4; i++)
        {
            int k_chet = 0;
            int k_nechet = 0;
            for (int j = 0; j < mass[i].Length; j++)
            {
                if (mass[i][j] % 2 == 0)
                {
                    k_chet++;
                }
                else
                {
                    k_nechet++;
                }

            }
            Console.WriteLine();
            Console.WriteLine($"Строка {i+1}. Количество чётных: " + k_chet + " /// " +"Количество нечётных: " + k_nechet);
            
        }
        Console.WriteLine("\n_______________________________ЗАДАНИЕ 2_________________________________\n");

        for (int i = 0; i < 4; i++)
        {
            
            int sum = 0;
            for (int j = 0;j < mass[i].Length; j++)
            {
                sum += mass[i][j];
                
                
            }
            
            int uslovie = 0;
            string posicion = "";
            int checker = 0;
            for (int j = 0; j < mass[i].Length; j++)
            {
                int element = mass[i][j];
                
                if (sum - element < element)
                {
                    
                    uslovie = element;
                    posicion = $"({i},{j})";
                    checker = element;
                }
                
            }
            if (uslovie != 0)
            {
                Console.WriteLine($"В строке {i+1} элементом является {checker}, его позиция в массиве {posicion}");
            }
            else
            {
                Console.WriteLine($"В стркое {i+1} нет подхоядщих элементов"); 
            }
        }
        Console.WriteLine();
        Console.WriteLine("МАССИВ");
        Console.WriteLine();

        for (int i = 0;i < 4; i++)
        {
            for (int j = 0;j < mass[i].Length; j++)
            {
                Console.Write(mass[i][j] + " ");
            }
            Console.WriteLine() ;
        }
    }
}
