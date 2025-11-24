using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement
{
    public class EmployeeCollection
    {
        private List<Employee> employees = new List<Employee>();

        // Add Employee
        public void AddEmployee()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            if (!double.TryParse(Console.ReadLine(), out double salary))
            {
                Console.WriteLine("Invalid salary input!");
                return;
            }

            Console.Write("Enter Employee Type (Permanent/Contract): ");
            string type = Console.ReadLine();

            Employee emp = new Employee(name, salary, type);
            employees.Add(emp);
            Console.WriteLine($"Employee added successfully! Assigned ID: {emp.Id}");
        }

        // Remove Employee by ID
        public void RemoveEmployee()
        {
            Console.Write("Enter Employee ID to remove: ");
            string id = Console.ReadLine();

            Employee emp = employees.FirstOrDefault(e => e.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (emp == null)
            {
                Console.WriteLine($"No Employee found with Id {id}");
            }
            else
            {
                employees.Remove(emp);
                Console.WriteLine($"Employee {id} removed successfully.");
            }
        }

        // Display All Employees
        public void DisplayAllEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees available.");
                return;
            }

            Console.WriteLine("\nEmployee List:");
            foreach (var emp in employees)
            {
                emp.Display();
            }
        }

        // Search Employee by Name
        public void SearchEmployeeByName()
        {
            Console.Write("Enter Employee Name to search: ");
            string name = Console.ReadLine();

            var result = employees.Where(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No Employee found with that name.");
            }
            else
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var emp in result)
                {
                    emp.Display();
                }
            }
        }
    }
}
