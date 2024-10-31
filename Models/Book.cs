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
        public Guid Id { get; set; }

        public Book(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}