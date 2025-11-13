using HotelBookingSystem.Models;

namespace HotelBookingSystem.DTOs.Payment
{
    public record PaymentAddDto(
        int BookingId,
        decimal Amount,
        PaymentMethod Method,
        PaymentStatus Status = PaymentStatus.Pending
    );
}