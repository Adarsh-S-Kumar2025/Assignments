using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs.Review;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly HotelBookingContext _db;
        public ReviewService(HotelBookingContext db) => _db = db;

        public async Task<Review> AddAsync(ReviewAddDto dto)
        {
            var review = new Review
            {
                HotelId = dto.HotelId,
                CustomerId = dto.CustomerId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                ReviewDate = DateTime.UtcNow
            };
            _db.Reviews.Add(review);
            await _db.SaveChangesAsync();
            return review;
        }

        public async Task<Review?> UpdateAsync(ReviewUpdateDto dto)
        {
            var r = await _db.Reviews.FindAsync(dto.Id);
            if (r == null) return null;
            r.Rating = dto.Rating; r.Comment = dto.Comment;
            await _db.SaveChangesAsync();
            return r;
        }

        public Task<Review?> GetByIdAsync(int id) => _db.Reviews.FirstOrDefaultAsync(r => r.Id == id);

        public async Task DeleteAsync(int id)
        {
            var r = await _db.Reviews.FindAsync(id);
            if (r != null) { _db.Reviews.Remove(r); await _db.SaveChangesAsync(); }
        }

        public async Task<IReadOnlyList<Review>> ListAsync()
        {
            var list = await _db.Reviews.AsNoTracking().ToListAsync();
            return list.AsReadOnly();
        }
    }
}
