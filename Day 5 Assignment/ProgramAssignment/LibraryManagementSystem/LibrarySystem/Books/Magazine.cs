using System;

namespace LibrarySystem.Books
{
    public class Magazine
    {
        public string Title { get; set; }
        public int IssueNumber { get; set; }

        public Magazine(string title, int issueNumber)
        {
            Title = title;
            IssueNumber = issueNumber;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Magazine: {Title}, Issue #{IssueNumber}");
        }
    }
}
