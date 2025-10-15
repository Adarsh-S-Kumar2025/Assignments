using System;

namespace AssignmentApp
{
    public class PrintOddNumbers
    {
        public void Execute()
        {
            int i = 1;
            while (i < 50)
            {
                Console.WriteLine(i);
                i += 2;
            }
        }
    }
}
