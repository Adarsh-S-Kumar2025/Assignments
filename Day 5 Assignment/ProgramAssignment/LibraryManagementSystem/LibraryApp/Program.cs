using System;
using LibrarySystem.Books;
using LibrarySystem.Members;
using LibrarySystem.Transactions;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("The Alchemist", "Paulo Coelho", "ISBN1234");
            Magazine mag1 = new Magazine("Tech World", 15);
            Journal jour1 = new Journal("AI Research", "Machine Learning");

            Member member1 = new Member("M001", "John Doe");
            Librarian librarian1 = new Librarian("L001", "Alice Johnson");

            BorrowTransaction borrow = new BorrowTransaction(member1, book1);
            ReturnTransaction ret = new ReturnTransaction(member1, book1);

            Console.WriteLine("=== Library Management System ===\n");
            book1.DisplayInfo();
            mag1.DisplayInfo();
            jour1.DisplayInfo();
            Console.WriteLine();
            member1.DisplayInfo();
            librarian1.ManageBooks();
            Console.WriteLine();
            borrow.DisplayInfo();
            ret.DisplayInfo();
        }
    }
}
