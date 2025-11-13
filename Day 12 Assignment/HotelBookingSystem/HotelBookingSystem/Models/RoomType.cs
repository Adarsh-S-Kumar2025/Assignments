namespace HotelBookingSystem.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }

        public List<Room> Rooms { get; set; } = new();
    }
}
