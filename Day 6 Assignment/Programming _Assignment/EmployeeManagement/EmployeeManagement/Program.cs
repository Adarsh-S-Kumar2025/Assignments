using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeCollection collection = new EmployeeCollection();

            while (true)
            {
                Console.WriteLine("\nWelcome to the Employee Management System…");
                Console.WriteLine("Please choose one of the following:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Display All Employees");
                Console.WriteLine("4. Search Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        collection.AddEmployee();
                        break;
                    case "2":
                        collection.RemoveEmployee();
                        break;
                    case "3":
                        collection.DisplayAllEmployees();
                        break;
                    case "4":
                        collection.SearchEmployeeByName();
                        break;
                    case "5":
                        Console.WriteLine("Exiting... Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
