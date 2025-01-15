using System;

class Animal
{
    public string Name;

    public Animal(string name)
    {
        Name = name;
    }
}

class Bird : Animal
{
    public string Habitat;
    public string WinteringPlace;

    public Bird(string name, string habitat, string winteringPlace) : base(name)
    {
        Habitat = habitat;
        WinteringPlace = winteringPlace;
    }
}

class Mammal : Animal
{
    public string Habitat;
    public double Weight;

    public Mammal(string name, string habitat, double weight) : base(name)
    {
        Habitat = habitat;
        Weight = weight;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("How many birds? ");
        int birdCount = int.Parse(Console.ReadLine());
        Bird[] birds = new Bird[birdCount];

        for (int i = 0; i < birdCount; i++)
        {
            Console.WriteLine($"Bird {i + 1}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Habitat: ");
            string habitat = Console.ReadLine();
            Console.Write("Wintering Place: ");
            string winteringPlace = Console.ReadLine();
            birds[i] = new Bird(name, habitat, winteringPlace);
        }

        Console.Write("How many mammals? ");
        int mammalCount = int.Parse(Console.ReadLine());
        Mammal[] mammals = new Mammal[mammalCount];

        for (int i = 0; i < mammalCount; i++)
        {
            Console.WriteLine($"Mammal {i + 1}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Habitat: ");
            string habitat = Console.ReadLine();
            Console.Write("Weight: ");
            double weight = double.Parse(Console.ReadLine());
            mammals[i] = new Mammal(name, habitat, weight);
        }

        Console.Write("Filter by habitat: ");
        string habitatFilter = Console.ReadLine();

        Console.WriteLine("Birds found:");
        foreach (var bird in birds)
        {
            if (bird.Habitat == habitatFilter)
            {
                Console.WriteLine($"{bird.Name} ({bird.WinteringPlace})");
            }
        }

        Console.WriteLine("Mammals found:");
        foreach (var mammal in mammals)
        {
            if (mammal.Habitat == habitatFilter)
            {
                Console.WriteLine($"{mammal.Name} (Weight: {mammal.Weight}kg)");
            }
        }

        Console.Write("Filter birds by wintering place: ");
        string winteringFilter = Console.ReadLine();

        Console.WriteLine("Birds found:");
        foreach (var bird in birds)
        {
            if (bird.WinteringPlace == winteringFilter)
            {
                Console.WriteLine(bird.Name);
            }
        }

        Console.Write("Filter mammals by minimum weight: ");
        double weightFilter = double.Parse(Console.ReadLine());

        Console.WriteLine("Mammals found:");
        foreach (var mammal in mammals)
        {
            if (mammal.Weight >= weightFilter)
            {
                Console.WriteLine(mammal.Name);
            }
        }
    }
}
