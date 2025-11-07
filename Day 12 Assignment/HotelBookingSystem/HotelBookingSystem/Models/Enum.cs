namespace HotelBookingSystem.Models
{
    public enum RoomStatus { Available, Booked, UnderMaintenance }
    public enum BookingStatus { Pending, Confirmed, Cancelled, Completed }
    public enum PaymentStatus { Pending, Paid, Failed }
    public enum PaymentMethod { Cash, Card, UPI, Online }
}
