using System;
using System.Collections.Generic;
using System.Linq; // Required for Average()

class Program
{
    static void Main()
    {
        // Create a List<int> to store marks
        List<int> marks = new List<int> { 78, 92, 67, 88, 95 };

        // Calculate and print the average mark
        double average = marks.Average();
        Console.WriteLine($"Average mark: {average:F2}");

        // Remove the lowest mark
        int lowestMark = marks.Min();
        marks.Remove(lowestMark);
        Console.WriteLine($"Removed the lowest mark: {lowestMark}");

        // Sort the list in ascending order
        marks.Sort();

        // Print the updated list
        Console.WriteLine("Updated list after sorting:");
        foreach (int mark in marks)
        {
            Console.WriteLine(mark);
        }
    }
}
