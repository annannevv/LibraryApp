using LibraryApp.Interfaces;
using LibraryApp.Models;
using LibraryApp.Services;
using System;

class Program
{
    static void Main(string[] args)
    {
        ILibraryService library = new LibraryService();
        ILoggerService logger = new LoggerService();

        while (true)
        {
            logger.ShowMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();

                    library.AddBook(new Book(name)); 
                    break;

                case "2":
                    Console.Write("Enter book ID: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid id))
                    {
                        var book = library.FindBookById(id);
                        if (book != null)
                            Console.WriteLine($"Book: {book.Name}");
                        else
                            logger.NotifyBookNotFound();
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid GUID.");
                    }
                    break;

                case "3":
                    Console.Write("Enter the ID of the book to be deleted: ");
                    if (Guid.TryParse(Console.ReadLine(), out id))
                    {
                        library.RemoveBookById(id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid GUID.");
                    }
                    break;

                case "4":
                    return;

                default:
                    logger.NotifyInvalidNumber();
                    break;
            }
        }
    }
}
