using System;
using System.Collections.Generic;
using System.Threading;

public class Runner
{
    public string Label { get; }
    public double TrackPosition { get; private set; }

    public Runner(string label, double start)
    {
        Label = label;
        TrackPosition = start;
    }

    public void Advance()
    {
        double increment = new Random().NextDouble() * 0.9 + 0.1;
        TrackPosition += increment;
    }
}

public class Competition
{
    private List<Runner> participants;
    private double goalLine;

    public Competition(List<Runner> participants, double goal)
    {
        this.participants = participants;
        this.goalLine = goal;
    }

    public void Begin()
    {
        var active = true;
        while (active)
        {
            foreach (var p in participants)
            {
                p.Advance();
                Console.WriteLine($"{p.Label} сейчас на {p.TrackPosition:F2}");

                if (p.TrackPosition >= goalLine)
                {
                    Console.WriteLine($"Финиширует первой: {p.Label}!");
                    active = false;
                    break;
                }
            }
            Thread.Sleep(400);
        }
    }
}

public class Launch
{
    public static void Main(string[] args)
    {
        var team = new List<Runner>
        {
            new Runner("Участник A", 0),
            new Runner("Участник B", 0),
            new Runner("Участник C", 0)
        };

        double boundary = 10;

        Console.WriteLine("Подготовка A");
        Thread.Sleep(600);
        Console.WriteLine("Подготовка B");
        Thread.Sleep(600);
        Console.WriteLine("Подготовка C");
        Thread.Sleep(400);
        Console.WriteLine("Позиции заняты");
        Thread.Sleep(700);
        Console.WriteLine("Сосредоточьтесь...");
        Thread.Sleep(900);
        Console.WriteLine("СТАРТ!");

        var game = new Competition(team, boundary);
        game.Begin();
    }
}
