using System;

namespace EmployeeManagement
{
    class Employee
    {
        // Static field for generating unique employee IDs
        private static int idCounter;

        // Static constructor — runs only once when the class is first used
        static Employee()
        {
            idCounter = 1000;
        }

        // Properties
        public string Id { get; private set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string EmployeeType { get; set; } // Permanent / Contract

        // Constructor to create a new employee and auto-generate ID
        public Employee(string name, double salary, string employeeType)
        {
            Id = "Emp" + idCounter++;
            Name = name;
            Salary = salary;
            EmployeeType = employeeType;
        }

        // Display employee info
        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Employee Type: {EmployeeType}");
            Console.WriteLine("---------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create employee objects
            Employee emp1 = new Employee("Adarsh", 75000, "Permanent");
            Employee emp2 = new Employee("Sanal", 60000, "Contract");
            Employee emp3 = new Employee("Riya", 85000, "Permanent");

            // Display details
            emp1.DisplayDetails();
            emp2.DisplayDetails();
            emp3.DisplayDetails();

            Console.ReadLine();
        }
    }
}
