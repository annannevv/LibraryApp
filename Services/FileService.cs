using LibraryApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryApp.Services
{
    internal class FileService : IFileService
    {
        private const string FilePath = "books.json";
        private readonly ILoggerService _logger;

        public FileService(ILoggerService logger)
        {
            _logger = logger;
        }

        public void SaveToFile<T>(List<T> data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(FilePath, jsonData);
            _logger.Log("Book added.");
        }

        public List<T> LoadFromFile<T>()
        {
            if (!File.Exists(FilePath)) return new List<T>();

            var jsonData = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
        }
    }
}
