namespace InventoryRecordsSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Inventory Records System");

                
                string path = "inventory_data.json";
                InventoryApp app = new InventoryApp(path);

               
                app.SeedSampleData();

                
                app.SaveData();
                Console.WriteLine("Data saved to disk.");

              
                app = null;
                Console.WriteLine("Memory cleared. Simulating new session...");

               
                InventoryApp newSessionApp = new InventoryApp(path);
                newSessionApp.LoadData();
                Console.WriteLine("Data loaded from disk.");

               
                newSessionApp.PrintAllItems();
            }
        }
    }
}
