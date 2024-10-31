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
        private readonly ILoggerService _logger;
        private readonly IFileService FileService;
        private List<Book> Books;

        public LibraryService()
        {
            FileService = new FileService();
            Books = LoadBooksFromFile();
        }

        public void AddBook(Book book)
        {
            if (Books.Any(b => b.Id == book.Id))
            {
                _logger.NotifyBookExists();
                return;
            }

            Books.Add(book);
            FileService.SaveToFile(Books);
        }

        public Book FindBookById(Guid id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }

        public bool RemoveBookById(Guid id)
        {
            var book = FindBookById(id);
            if (book != null)
            {
                Books.Remove(book);
                FileService.SaveToFile(Books);
                _logger.NotifyBookDeleted();
                return true;
            }

            _logger.NotifyBookNotFound();
            return false;
        }

        private List<Book> LoadBooksFromFile()
        {
            return FileService.LoadFromFile<Book>();
        }
    }
}