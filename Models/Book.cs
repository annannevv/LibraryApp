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
        public int Id { get; set; }

        public Book(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}