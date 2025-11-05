namespace DataAccess
{
    public class Database
    {
        public string GetCustomerData()
        {
            // Simulated database fetch
            return "Customer data retrieved from DataAccess layer.";
        }

        public void SaveCustomerData(string data)
        {
            Console.WriteLine($"[DataAccess] Saving data: {data}");
        }
    }
}
