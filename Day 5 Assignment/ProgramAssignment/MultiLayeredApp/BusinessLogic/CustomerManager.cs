using DataAccess;

namespace BusinessLogic
{
    public class CustomerManager
    {
        private readonly Database _db;

        public CustomerManager()
        {
            _db = new Database();
        }

        public void ProcessCustomer()
        {
            string data = _db.GetCustomerData();
            Console.WriteLine($"[BusinessLogic] Processing: {data}");

            string processedData = data.ToUpper();
            _db.SaveCustomerData(processedData);
        }
    }
}
