﻿using LibraryApp.Interfaces;
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
        private readonly IFileService _fileService;
        private List<Book> Books;

        public LibraryService()
        {
            _logger = new LoggerService();
            _fileService = new FileService(_logger);
            Books = new List<Book>();
        }

        public async Task InitializeAsync()
        {
            Books = await LoadBooksFromFile();
        }

        public async Task AddBook(Book book)
        {
            if (Books.Any(b => b.Id == book.Id))
            {
                _logger.Log("The book already exists.");
                return;
            }

            book.ReadingProgress = CalculateReadingProgress(book.NumberOfPages, book.CurrentPage);
            if (book.NumberOfPages >= book.CurrentPage)
            {
                Books.Add(book);
                await _fileService.SaveToFileAsync(Books);
            }
            else _logger.Log("Invalid number of current page");
            
        }

        public Book FindBookById(Guid id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }

        public async Task<bool> RemoveBookById(Guid id)
        {
            var book = FindBookById(id);
            if (book != null)
            {
                Books.Remove(book);
                await _fileService.SaveToFileAsync(Books);
                _logger.Log("Book deleted.");
                return true;
            }

            _logger.NotifyBookNotFound();
            return false;
        }

        private async Task<List<Book>> LoadBooksFromFile()
        {
            return await _fileService.LoadFromFileAsync<Book>();
        }

        private decimal CalculateReadingProgress(int numberOfPages, int currentPage)
        {
            if (numberOfPages <= 0 || currentPage > numberOfPages) return 0;

            decimal progress = (decimal)currentPage / numberOfPages * 100;
            return Math.Round(Math.Min(progress, 100), 2);
        }

        public string GetReadingProgress(string author)
        {
            decimal averageProgress = 0;
            var booksByAuthor = Books.Where(b => b.Author == author);

            if (booksByAuthor.Any())
            {
                averageProgress = booksByAuthor.Average(b => b.ReadingProgress);
            }

            return averageProgress.ToString("F2") + "%";
        }

        public Dictionary<DateTime, int> GetBookCountByDate()
        {
            var bookCountByDate = Books
                .GroupBy(b => b.Date.Date) 
                .ToDictionary(g => g.Key, g => g.Count()); 

            return bookCountByDate;
        }
    }
}