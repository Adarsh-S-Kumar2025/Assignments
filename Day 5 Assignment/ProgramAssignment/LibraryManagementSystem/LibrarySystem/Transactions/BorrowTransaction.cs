using System;
using LibrarySystem.Books;
using LibrarySystem.Members;

namespace LibrarySystem.Transactions
{
    public class BorrowTransaction
    {
        public Member Borrower { get; set; }
        public Book BorrowedBook { get; set; }
        public DateTime BorrowDate { get; set; }

        public BorrowTransaction(Member borrower, Book book)
        {
            Borrower = borrower;
            BorrowedBook = book;
            BorrowDate = DateTime.Now;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Borrower.Name} borrowed \"{BorrowedBook.Title}\" on {BorrowDate.ToShortDateString()}");
        }
    }
}
