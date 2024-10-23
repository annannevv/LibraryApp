using LibraryApp.Interfaces;
using LibraryApp.Models;
using LibraryApp.Services;
using System;

class Program
{
    static void Main(string[] args)
    {
        ILibraryService library = new LibraryService();

        while (true)
        {
            Console.WriteLine("Select an action: ");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Find a book by ID");
            Console.WriteLine("3. Delete a book by ID");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter book ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();

                    library.AddBook(new Book(id, name));
                    break;
                case "2":
                    Console.Write("Enter book ID: ");
                    id = int.Parse(Console.ReadLine());

                    var book = library.FindBookById(id);
                    if (book != null)
                        Console.WriteLine($"Book: {book.Name}");
                    else
                        Console.WriteLine("Not found.");
                    break;
                case "3":
                    Console.Write("Enter the ID of the book to be deleted: ");
                    id = int.Parse(Console.ReadLine());

                    library.RemoveBookById(id);
                    break;
                case "4":
                    return;

                default:
                    Console.WriteLine("Wrong choice.");
                    break;
            }
        }
    }
}
