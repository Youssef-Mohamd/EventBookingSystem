using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Application.DTOs.Requests;
using EventBooking.Application.DTOs.Responses;
using EventBooking.Application.Interfaces;
using EventBooking.Domain.Entities;
using EventBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;
        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddReviewAsync(int userId, int eventId, CreateReviewRequest request)
        {
            //  Check event exists
            var ev = await _context.Events.FindAsync(eventId);
            if (ev == null)
                throw new Exception("Event not found");

            //  Check user booked this event
            var hasBooking = await _context.Bookings
                .AnyAsync(b => b.UserId == userId && b.EventId == eventId);

            if (!hasBooking)
                throw new Exception("You must book this event before reviewing");

            //  Check user already reviewed
            var reviewExists = await _context.Reviews
                .AnyAsync(r => r.UserId == userId && r.EventId == eventId);

            if (reviewExists)
                throw new Exception("You already reviewed this event");

            //  Create Review
            var review = new Review
            {
                UserId = userId,
                EventId = eventId,
                Rating = request.Rating,
                Comment = request.Comment
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int reviewId, int userId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);

            if (review == null)
                throw new Exception("Review not found");

            if (review.UserId != userId)
                throw new Exception("You can delete only your own review");

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ReviewResponse>> GetEventReviewsAsync(int eventId)
        {
            return await _context.Reviews
                  .Where(r => r.EventId == eventId)
                  .Include(r => r.User)
                  .Select(r => new ReviewResponse
                  {
                      ReviewId = r.ReviewId,
                      Rating = r.Rating,
                      Comment = r.Comment,
                      UserName = r.User.FullName,
                      CreatedAt = r.CreatedAt
                  })
                  .ToListAsync();
        }
    }
}
