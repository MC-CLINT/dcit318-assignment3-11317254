using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InventoryRecordsSystem
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _log = new();

        private readonly string _filePath;

        public InventoryLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(T item)
        {
            _log.Add(item);
        }

        public List<T> GetAll()
        {
            return new List<T>(_log);
        }

        public void SaveToFile()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(_log, options);

                using var writer = new StreamWriter(_filePath, false); 
                writer.Write(json);
            }
            catch (IOException ioEx)
            {
                Console.Error.WriteLine($"I/O error while saving: {ioEx.Message}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                Console.Error.WriteLine($"Access denied: {uaEx.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error during save: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("Log file not found. Starting with empty log.");
                    return;
                }

                using var reader = new StreamReader(_filePath);
                string json = reader.ReadToEnd();

                var items = JsonSerializer.Deserialize<List<T>>(json);
                if (items != null)
                {
                    _log = items;
                }
            }
            catch (JsonException jsonEx)
            {
                Console.Error.WriteLine($"JSON parsing error: {jsonEx.Message}");
            }
            catch (IOException ioEx)
            {
                Console.Error.WriteLine($"I/O error while loading: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error during load: {ex.Message}");
            }
        }
    }
}
