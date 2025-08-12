using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouseInventory.Interfaces;

namespace WareHouseInventory
{
    public class WareHouseManager
    {
        private InventoryRepository<ElectronicItem> _electronics = new InventoryRepository<ElectronicItem>();
        private InventoryRepository<GroceryItem> _groceries = new InventoryRepository<GroceryItem>();

        public void SeedData()
        {
            try
            {
                _electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "Dell", 24));
                _electronics.AddItem(new ElectronicItem(2, "Smartphone", 15, "Samsung", 12));
                _electronics.AddItem(new ElectronicItem(3, "Headphones", 20, "Sony", 6));

                _groceries.AddItem(new GroceryItem(101, "Milk", 30, DateTime.Now.AddDays(7)));
                _groceries.AddItem(new GroceryItem(102, "Bread", 25, DateTime.Now.AddDays(3)));
                _groceries.AddItem(new GroceryItem(103, "Eggs", 40, DateTime.Now.AddDays(10)));
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Seed Error: {ex.Message}");
            }
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            var items = repo.GetAllItems();
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
            }
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                int newQuantity = item.Quantity + quantity;
                repo.UpdateQuantity(id, newQuantity);
                Console.WriteLine($"Stock updated: {item.Name} now has {newQuantity} units.");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Stock Update Error: {ex.Message}");
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Stock Update Error: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Item with ID {id} removed successfully.");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Remove Error: {ex.Message}");
            }
        }

        // Optional: expose access to repositories if needed
        public InventoryRepository<ElectronicItem> ElectronicsRepo => _electronics;
        public InventoryRepository<GroceryItem> GroceriesRepo => _groceries;
    }

}
