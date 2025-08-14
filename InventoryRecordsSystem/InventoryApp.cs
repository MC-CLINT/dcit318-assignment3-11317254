using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryRecordsSystem.InventoryRecordsSystem;

namespace InventoryRecordsSystem
{
    public class InventoryApp
    {
        private readonly InventoryLogger<InventoryItem> _logger;

        private string filePath;
        public InventoryApp(string filePath)
        {
            this.filePath = filePath;
            _logger = new InventoryLogger<InventoryItem>(filePath);
        }

        public void SeedSampleData()
        {
            _logger.Add(new InventoryItem(1, "Dell Laptop", 40, DateTime.Now));
            _logger.Add(new InventoryItem(2, "Optical Mouse", 50, DateTime.Now));
            _logger.Add(new InventoryItem(3, "Iphone Type C Cables", 10, DateTime.Now));
            _logger.Add(new InventoryItem(4, "HP System Units", 25, DateTime.Now));
            _logger.Add(new InventoryItem(5, "USB and Printer Cables", 100, DateTime.Now));
        }

        public void SaveData()
        {
            _logger.SaveToFile();
        }

        public void LoadData()
        {
            _logger.LoadFromFile();
        }

        public void PrintAllItems()
        {
            var items = _logger.GetAll();
            if (items.Count == 0)
            {
                Console.WriteLine("No inventory items found.");
                return;
            }

            Console.WriteLine("Inventory Items:");
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded}");
            }
        }
    }
}
