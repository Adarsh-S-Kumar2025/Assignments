using BusinessLogic;

namespace UI.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== UI.ConsoleApp Started ===");

            CustomerManager manager = new CustomerManager();
            manager.ProcessCustomer();

            Console.WriteLine("=== Operation Complete ===");
            Console.ReadKey();
        }
    }
}
