using LibraryApp.Interfaces;
using LibraryApp.Models;
using LibraryApp.Services;
using System;
using System.Transactions;

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

                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();

                    Console.Write("Enter total number of pages:");
                    if (Int32.TryParse(Console.ReadLine(), out int numberOfPages))
                    {

                        Console.Write("Enter your current page:");
                        if (Int32.TryParse(Console.ReadLine(), out int currentPage))
                        {
                            library.AddBook(new Book(name, author, numberOfPages, currentPage));
                        }
                    }
                    else logger.NotifyInvalidNumber();                   
                    break;

                case "2":
                    Console.Write("Enter book ID: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid id))
                    {
                        var book = library.FindBookById(id);
                        if (book != null)
                        {
                            Console.WriteLine($"Book: {book.Name}");
                        }                          
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
                    Console.Write("Enter author: ");
                    string auth = Console.ReadLine();
                    Console.WriteLine(library.GetReadingProgress(auth));
                    break;
                case "5":
                    var bookCountByDate = library.GetBookCountByDate();
                    foreach (var entry in bookCountByDate)
                    {
                        Console.WriteLine($"Date: {entry.Key.ToShortDateString()}, Quantity: {entry.Value}");
                    }
                    break;
                case "6":
                    return;

                default:
                    logger.NotifyInvalidNumber();
                    break;
            }
        }
    }
}
