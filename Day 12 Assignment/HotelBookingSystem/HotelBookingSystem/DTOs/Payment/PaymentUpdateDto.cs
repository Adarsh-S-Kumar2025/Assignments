using HotelBookingSystem.Models;

namespace HotelBookingSystem.DTOs.Payment
{
    public record PaymentUpdateDto(
        int Id,
        int BookingId,
        decimal Amount,
        PaymentMethod Method,
        PaymentStatus Status
    );
}