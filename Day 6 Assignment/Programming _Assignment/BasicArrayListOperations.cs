using System;
using System.Collections;  // Required for ArrayList

class Program
{
    static void Main()
    {
        // 1️ Create an ArrayList to store student names
        ArrayList students = new ArrayList();

        // 2️ Add 5 student names to the list
        students.Add("Alice");
        students.Add("Bob");
        students.Add("Charlie");
        students.Add("David");
        students.Add("Eve");

        // 3️ Display all names
        Console.WriteLine("Initial list of students:");
        foreach (string student in students)
        {
            Console.WriteLine(student);
        }

        // 4️ Remove one name from the list
        students.Remove("Charlie");  // Removes "Charlie"

        // 5️ Insert a new name at index 2
        students.Insert(2, "Frank");  // Insert "Frank" at position 2

        // 6️ Print the final list using a for loop
        Console.WriteLine("\nFinal list using for loop:");
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine(students[i]);
        }

        // 6️ Print the final list using a foreach loop
        Console.WriteLine("\nFinal list using foreach loop:");
        foreach (string student in students)
        {
            Console.WriteLine(student);
        }
    }
}
