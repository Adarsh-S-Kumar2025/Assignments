using System;

namespace LibrarySystem.Members
{
    public class Member
    {
        public string MemberId { get; set; }
        public string Name { get; set; }

        public Member(string memberId, string name)
        {
            MemberId = memberId;
            Name = name;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Member: {Name} (ID: {MemberId})");
        }
    }
}
