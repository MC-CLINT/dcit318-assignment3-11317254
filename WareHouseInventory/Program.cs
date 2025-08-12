namespace WareHouseInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new WareHouseManager();

            
            manager.SeedData();

            
            Console.WriteLine("\n📦 Grocery Inventory:");
            manager.PrintAllItems(manager.GroceriesRepo);

            
            Console.WriteLine("\n🔌 Electronic Inventory:");
            manager.PrintAllItems(manager.ElectronicsRepo);

            
            Console.WriteLine("\n⚠️ Attempting to add duplicate electronic item...");
            try
            {
                manager.ElectronicsRepo.AddItem(new ElectronicItem(1, "Laptop", 5, "HP", 12)); 
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            
            Console.WriteLine("\n⚠️ Attempting to remove non-existent grocery item...");
            manager.RemoveItemById(manager.GroceriesRepo, 999); 

           
            Console.WriteLine("\n⚠️ Attempting to update with invalid quantity...");
            manager.IncreaseStock(manager.ElectronicsRepo, 2, -10); 

            Console.WriteLine("\n✅ Inventory operations complete.");
        }
    }
}
