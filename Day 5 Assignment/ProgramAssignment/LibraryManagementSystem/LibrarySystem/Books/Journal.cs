using System;

namespace LibrarySystem.Books
{
    public class Journal
    {
        public string Title { get; set; }
        public string ResearchArea { get; set; }

        public Journal(string title, string researchArea)
        {
            Title = title;
            ResearchArea = researchArea;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Journal: {Title} - Research Area: {ResearchArea}");
        }
    }
}
