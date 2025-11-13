namespace HotelBookingSystem.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public List<Room> Rooms { get; set; } = new();
        public List<Employee> Employees { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}
