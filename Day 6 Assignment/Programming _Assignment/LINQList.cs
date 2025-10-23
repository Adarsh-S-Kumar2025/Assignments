using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a List<string> with 6 names
        List<string> names = new List<string>
        {
            "Alice",
            "Bob",
            "Andrew",
            "Emma",
            "Alex",
            "John"
        };

        // Find all names that start with 'A'
        var namesStartingWithA = names.Where(name => name.StartsWith("A")).ToList();

        // Find names with length greater than 4
        var namesLongerThan4 = names.Where(name => name.Length > 4).ToList();

        // Display the results
        Console.WriteLine("Names starting with 'A':");
        foreach (var name in namesStartingWithA)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nNames with length greater than 4:");
        foreach (var name in namesLongerThan4)
        {
            Console.WriteLine(name);
        }
    }
}
