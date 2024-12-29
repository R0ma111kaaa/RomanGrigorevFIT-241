using System;
using System.IO;

namespace Savage
{
    class Program
    {
        static void Main()
        {
            string inputFilePath = "input1.txt";

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int n = int.Parse(reader.ReadLine());

                double minimumPM = double.MaxValue;
                int bestIndex = 0;

                for (int i = 1; i <= n; i++)
                {
                    string line = reader.ReadLine()?.Replace('.', ',');
                    if (string.IsNullOrEmpty(line))
                        continue;

                    string[] parts = line.Split(' ');

                    int x1 = int.Parse(parts[0]);
                    int y1 = int.Parse(parts[1]);
                    int z1 = int.Parse(parts[2]);
                    int x2 = int.Parse(parts[3]);
                    int y2 = int.Parse(parts[4]);
                    int z2 = int.Parse(parts[5]);

                    double c1 = double.Parse(parts[6]);
                    double c2 = double.Parse(parts[7]);

                    int surfaceArea1 = 2 * (x1 * y1 + y1 * z1 + z1 * x1);
                    int surfaceArea2 = 2 * (x2 * y2 + y2 * z2 + z2 * x2);

                    int volume1 = x1 * y1 * z1;
                    int volume2 = x2 * y2 * z2;

                    double pm = 1000 * (c2 - c1 * surfaceArea2 / surfaceArea1) / (volume2 - volume1 * surfaceArea2 / surfaceArea1);
                    pm = Math.Round(pm, 2);

                    if (pm < minimumPM)
                    {
                        minimumPM = pm;
                        bestIndex = i;
                    }
                }

                Console.WriteLine($"{bestIndex} {minimumPM:0.00}");
            }
        }
    }
}