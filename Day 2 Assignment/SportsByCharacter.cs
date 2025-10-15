using System;

namespace AssignmentApp
{
    public class SportsByCharacter
    {
        public void Execute()
        {
            Console.Write("Enter character (c/f/h/t/b): ");
            char ch = Char.ToLower(Convert.ToChar(Console.ReadLine()));
            string sport = ch switch
            {
                'c' => "Cricket",
                'f' => "Football",
                'h' => "Hockey",
                't' => "Tennis",
                'b' => "Badminton",
                _ => "Invalid character"
            };
            Console.WriteLine("Sport: " + sport);
        }
    }
}
