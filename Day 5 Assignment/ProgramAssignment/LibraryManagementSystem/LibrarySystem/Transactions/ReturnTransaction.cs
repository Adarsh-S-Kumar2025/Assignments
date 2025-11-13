using System;
using LibrarySystem.Books;
using LibrarySystem.Members;

namespace LibrarySystem.Transactions
{
    public class ReturnTransaction
    {
        public Member Borrower { get; set; }
        public Book ReturnedBook { get; set; }
        public DateTime ReturnDate { get; set; }

        public ReturnTransaction(Member borrower, Book book)
        {
            Borrower = borrower;
            ReturnedBook = book;
            ReturnDate = DateTime.Now;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Borrower.Name} returned \"{ReturnedBook.Title}\" on {ReturnDate.ToShortDateString()}");
        }
    }
}
