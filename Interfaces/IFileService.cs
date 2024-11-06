using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces
{
    internal interface IFileService
    {
        Task SaveToFile<T>(List<T> data);
        Task<List<T>> LoadFromFile<T>();
    }
}
