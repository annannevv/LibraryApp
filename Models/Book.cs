using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    internal class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }   
        public Guid Id { get; set; }
        public DateTime Date {  get; set; }
        public decimal ReadingProgress { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }


        public Book(string name, string author, int numberOfPages, int currentPage)
        {
            Id = Guid.NewGuid();
            Name = name;
            NumberOfPages = numberOfPages;
            CurrentPage = currentPage;
            Author = author;
            Date = DateTime.Now;
        }
    }
}