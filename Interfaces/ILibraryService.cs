using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces
{
    internal interface ILibraryService
    {
        void AddBook(Book book);
        Book FindBookById(int id);
        bool RemoveBookById(int id);
    }
}
