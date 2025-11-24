using HotelBookingSystem.DTOs.Review;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services.Interfaces
{
    public interface IReviewService
    {
        Task<Review> AddAsync(ReviewAddDto dto);
        Task<Review?> UpdateAsync(ReviewUpdateDto dto);
        Task<Review?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<IReadOnlyList<Review>> ListAsync();
    }
}
