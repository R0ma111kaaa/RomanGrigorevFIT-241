using System;
using System.IO;


class Program
{
    static void Main()
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";
        if (!File.Exists(inputPath))
        {
            throw new Exception("файла нету");
        }

        string[] lines = File.ReadAllLines(inputPath);

        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            foreach (string line in lines)
            {
                if (hasNum(line))
                {
                    writer.WriteLine(line);
                }
            }
        }

        bool hasNum(string line)
        {
            string oddNums = "02468";
            bool isLastOdd = false;
            foreach (char ch in line)
            {
                if (oddNums.Contains(ch))
                {
                    isLastOdd = true;
                }
                else
                {
                    if (isLastOdd)
                    {
                        return true;
                    }
                    else
                    {
                        isLastOdd = false;
                    }
                }
            }
            return false;
        }
    }
}