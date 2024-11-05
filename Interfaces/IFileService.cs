using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces
{
    internal interface IFileService
    {
        void SaveToFile<T>(List<T> data);
        List<T> LoadFromFile<T>();
    }
}
