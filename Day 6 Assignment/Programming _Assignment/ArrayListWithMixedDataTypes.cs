using System;
using System.Collections; // Required for ArrayList

class Program
{
    static void Main()
    {
        // Create an ArrayList
        ArrayList list = new ArrayList();

        // Add elements of different data types
        list.Add("John");     // string
        list.Add(25);         // int
        list.Add(75.5);       // double
        list.Add(true);       // bool

        // Iterate through the ArrayList
        foreach (var item in list)
        {
            Console.WriteLine($"Value: {item}, Type: {item.GetType()}");
        }
    }
}
