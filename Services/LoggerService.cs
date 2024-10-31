using LibraryApp.Interfaces;
using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Services
{
    internal class LoggerService : ILoggerService
    {
        public void LogInfo(string message)
        {
            Console.WriteLine($"{message}");
        }

        public void NotifyBookAdded()
        {
            Console.WriteLine($"Book added.");
        }

        public void NotifyBookDeleted()
        {
            Console.WriteLine($"Book deleted.");
        }

        public void NotifyBookNotFound()
        {
            Console.WriteLine($"Book not found.");
        }

        public void NotifyBookExists()
        {
            Console.WriteLine($"The book already exists.");
        }

        public void ShowMenu()
        {
            Console.WriteLine("Select an action: ");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Find a book by ID");
            Console.WriteLine("3. Delete a book by ID");
            Console.WriteLine("4. Exit");
        }

        public void NotifyInvalidNumber()
        {
            Console.WriteLine("Invalid ID. Please enter a valid number.");
        }
    }
}
