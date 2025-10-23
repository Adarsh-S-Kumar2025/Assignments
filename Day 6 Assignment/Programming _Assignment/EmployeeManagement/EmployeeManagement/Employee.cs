using System;

namespace EmployeeManagement
{
    public class Employee
    {
        private static int counter = 1000;

        public string Id { get; private set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string EmployeeType { get; set; } // "Permanent" or "Contract"

        public Employee(string name, double salary, string employeeType)
        {
            Id = $"Emp{counter++}";
            Name = name;
            Salary = salary;
            EmployeeType = employeeType;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Salary: {Salary}, Type: {EmployeeType}");
        }
    }
}
