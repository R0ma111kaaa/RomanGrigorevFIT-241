using System;
using System.Collections.Generic;

public delegate void VehicleHandler(Vehicle v);

public class Vehicle
{
    public int ReleaseYear { get; set; }
    public string Type { get; set; }
    public string Paint { get; set; }
    public bool NeedsWash { get; set; }

    public Vehicle(int year, string type, string paint, bool dirty)
    {
        ReleaseYear = year;
        Type = type;
        Paint = paint;
        NeedsWash = dirty;
    }

    public override string ToString()
    {
        return $"{ReleaseYear} {Type} ({Paint}) - Нужно мыть: {NeedsWash}";
    }
}

class Depot
{
    private List<Vehicle> fleet;

    public Depot()
    {
        fleet = new List<Vehicle>();
    }

    public void Register(Vehicle v)
    {
        fleet.Add(v);
    }

    public List<Vehicle> RetrieveAll()
    {
        return fleet;
    }
}

class Cleaner
{
    public void Clean(Vehicle v)
    {
        if (v.NeedsWash)
        {
            v.NeedsWash = false;
            Console.WriteLine($"{v.Type} очищена");
        }
        else
        {
            Console.WriteLine($"{v.Type} уже в порядке");
        }
    }
}

class EntryPoint
{
    static void Main(string[] args)
    {
        var depot = new Depot();
        depot.Register(new Vehicle(2017, "Toyota Camry", "Синий", true));
        depot.Register(new Vehicle(2008, "Honda Accord", "Черный", false));
        depot.Register(new Vehicle(2015, "Ford Focus", "Красный", true));
        depot.Register(new Vehicle(2004, "Nissan Primera", "Черный", false));

        var cleaner = new Cleaner();
        VehicleHandler handler = new VehicleHandler(cleaner.Clean);

        foreach (var item in depot.RetrieveAll())
        {
            Console.WriteLine(item);
            handler(item);
            Console.WriteLine();
        }
    }
}
