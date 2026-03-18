using System;

namespace OOPlesson
{
    public class Program
    {
        public static void Main()
        {
            
        }

        private static void People()
        {
            Person valkyrie = new Person("Valkyrie", 16);
            Console.WriteLine(valkyrie);
            Person Joe = new Person("Joe", 999999999);
            Console.WriteLine(Joe);
        }

        private static void formatBook()
        {
            Console.WriteLine("Input book name: ");
            string name = Console.ReadLine();
            int bookCount = 0;
            while(name.ToLower() != "quit")
            {
                Console.WriteLine("Input author name: ");
                string author = Console.ReadLine();
                Console.WriteLine("Input ISBN: ");
                string isbn = Console.ReadLine();
                Console.WriteLine("Is book available (Yes/No)?");
                string isAvailable = Console.ReadLine();
                bool availability = isAvailable.ToLower() == "yes";
                
                Book book1 = new Book(name, author, isbn, availability);
                bookCount++;
                
                Console.WriteLine("Input book name: ");
                name = Console.ReadLine();
            }
            Console.WriteLine($"Total books made: {bookCount}");
        }

        private static void Fairies()
        {
            Fairy nicholas = new Fairy("Nicholas", "Communist Red");
            Console.WriteLine(nicholas);
        }
    }
}