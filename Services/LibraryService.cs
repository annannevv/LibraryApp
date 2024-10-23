using LibraryApp.Interfaces;
using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LibraryApp.Services
{
    internal class LibraryService : ILibraryService
    {
        private const string FilePath = "books.json";
        private List<Book> Books;

        public LibraryService()
        {
            Books = LoadBooksFromFile();
        }

        public void AddBook(Book book)
        {
            if (Books.Any(b => b.Id == book.Id))
            {
                Console.WriteLine($"Book with ID {book.Id} already exists.");
                return;
            }

            Books.Add(book);
            SaveBooksToFile();
            Console.WriteLine($"Book '{book.Name}' added.");
        }

        public Book FindBookById(int id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }

        public bool RemoveBookById(int id)
        {
            var book = FindBookById(id);
            if (book != null)
            {
                Books.Remove(book);
                SaveBooksToFile();
                Console.WriteLine($"Book ID {id} deleted.");
                return true;
            }

            Console.WriteLine($"Book with ID {id} not found.");
            return false;
        }

        private void SaveBooksToFile()
        {
            var json = JsonSerializer.Serialize(Books);
            File.WriteAllText(FilePath, json);
        }

        private List<Book> LoadBooksFromFile()
        {
            if (!File.Exists(FilePath)) return new List<Book>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }
    }
}