using System;

namespace LibrarySystem.Members
{
    public class Librarian
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }

        public Librarian(string employeeId, string name)
        {
            EmployeeId = employeeId;
            Name = name;
        }

        public void ManageBooks()
        {
            Console.WriteLine($"{Name} is managing books...");
        }
    }
}
