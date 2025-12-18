using EventBooking.Application.DTOs.Requests;
using System.Security.Claims;
using EventBooking.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // POST: /api/reviews/{eventId}
        [Authorize]
        [HttpPost("reviews/{eventId}")]
        public async Task<IActionResult> AddReview(int eventId, [FromBody] CreateReviewRequest request)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _reviewService.AddReviewAsync(userId, eventId, request);
            return Ok(new { message = "Review added successfully" });
        }

        // GET: /api/events/{eventId}/reviews
        [HttpGet("events/{eventId}/reviews")]
        public async Task<IActionResult> GetEventReviews(int eventId)
        {
            var reviews = await _reviewService.GetEventReviewsAsync(eventId);
            return Ok(reviews);
        }

        // DELETE: /api/reviews/{id}
        [Authorize]
        [HttpDelete("reviews/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _reviewService.DeleteReviewAsync(id, userId);
            return Ok(new { message = "Review deleted successfully" });
        }
    }
}
