using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Application.DTOs.Requests;
using EventBooking.Application.DTOs.Responses;

namespace EventBooking.Application.Interfaces
{
    public interface IReviewService
    {
        Task AddReviewAsync(int userId, int eventId, CreateReviewRequest request);
        Task<List<ReviewResponse>> GetEventReviewsAsync(int eventId);
        Task DeleteReviewAsync(int reviewId, int userId);
    }
}
