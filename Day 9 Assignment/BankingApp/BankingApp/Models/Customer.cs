namespace BankingApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        // Added in second migration
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
