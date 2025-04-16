using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStorage
{
    public struct Publication
    {
        public string Author { get; }
        public string Name { get; }
        public int ReleaseYear { get; }
        public string PublishingHouse { get; }
        public DateTime? DateIssued { get; }
        public DateTime? DateReturned { get; }

        public Publication(string author, string name, int releaseYear, string publishingHouse, DateTime? dateIssued, DateTime? dateReturned)
        {
            Author = author;
            Name = name;
            ReleaseYear = releaseYear;
            PublishingHouse = publishingHouse;
            DateIssued = dateIssued;
            DateReturned = dateReturned;
        }
    }

    public class BookCollection
    {
        private List<Publication> publications;

        public BookCollection()
        {
            publications = new List<Publication>();
        }

        public void AddPublication(Publication publication)
        {
            publications.Add(publication);
        }

        public List<Publication> GetUnissuedBooks()
        {
            return publications.Where(pub => pub.DateIssued == null).ToList();
        }

        public List<Publication> GetUnreturnedBooks()
        {
            return publications.Where(pub => pub.DateIssued != null && pub.DateReturned == null).ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BookCollection collection = new BookCollection();

            collection.AddPublication(new Publication("Ivanov", "Book 1", 2021, "Publisher A", null, null));
            collection.AddPublication(new Publication("Petrov", "Book 2", 2022, "Publisher B", DateTime.Now.AddDays(-12), null));
            collection.AddPublication(new Publication("Sidorov", "Book 3", 2018, "Publisher C", null, null));
            collection.AddPublication(new Publication("Kuznetsov", "Book 4", 2023, "Publisher D", DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3)));

            var unissuedBooks = collection.GetUnissuedBooks();
            Console.WriteLine("Books that have never been issued:");
            foreach (var pub in unissuedBooks)
            {
                Console.WriteLine($"{pub.Name} ({pub.Author}, {pub.ReleaseYear})");
            }

            var unreturnedBooks = collection.GetUnreturnedBooks();
            Console.WriteLine("\nBooks that have not been returned:");
            foreach (var pub in unreturnedBooks)
            {
                Console.WriteLine($"{pub.Name} ({pub.Author}, {pub.ReleaseYear})");
            }
        }
    }
}
