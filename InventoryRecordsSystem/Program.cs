namespace InventoryRecordsSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("=== Inventory Records System ===");

                // Step 1: Create an instance of InventoryApp
                string path = "inventory_data.json";
                InventoryApp app = new InventoryApp(path);

                // Step 2: Seed sample data
                app.SeedSampleData();

                // Step 3: Save data to disk
                app.SaveData();
                Console.WriteLine("Data saved to disk.");

                // Step 4: Clear memory (simulate new session)
                app = null;
                Console.WriteLine("Memory cleared. Simulating new session...");

                // Step 5: Create new instance and load data
                InventoryApp newSessionApp = new InventoryApp(path);
                newSessionApp.LoadData();
                Console.WriteLine("Data loaded from disk.");

                // Step 6: Print all items to confirm recovery
                newSessionApp.PrintAllItems();
            }
        }
    }
}
