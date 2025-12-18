using EventBooking.Application.DTOs.Requests;
using EventBooking.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        // ===================== EVENTS =====================

        // POST: api/admin/events
        [HttpPost("events")]
        public async Task<IActionResult> CreateEvent([FromBody] EventRequestDTO request)
        {
            var id = await _service.CreateEventAsync(request);
            return Ok(new { EventId = id });
        }

        // PUT: api/admin/events/{id}
        [HttpPut("events/{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] UpdateEventRequest request)
        {
            await _service.UpdateEventAsync(id, request);
            return Ok();
        }

        // DELETE: api/admin/events/{id}
        [HttpDelete("events/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _service.DeleteEventAsync(id);
            return Ok();
        }

        // POST: api/admin/events/{id}/tickets
        [HttpPost("events/{id}/tickets")]
        public async Task<IActionResult> AddTicket(int id, [FromBody] TicketTypeRequest request)
        {
            await _service.AddTicketAsync(id, request);
            return Ok();
        }

        // ===================== TICKETS =====================

        // PUT: api/admin/tickets/{id}
        [HttpPut("tickets/{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketTypeRequest request)
        {
            await _service.UpdateTicketAsync(id, request);
            return Ok();
        }

        // DELETE: api/admin/tickets/{id}
        [HttpDelete("tickets/{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _service.DeleteTicketAsync(id);
            return Ok();
        }

        // ===================== BOOKINGS =====================

        // GET: api/admin/bookings
        [HttpGet("bookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            return Ok(await _service.GetAllBookingsAsync());
        }

        // PUT: api/admin/bookings/{id}/status
        [HttpPut("bookings/{id}/status")]
        public async Task<IActionResult> UpdateBookingStatus(
            int id,
            [FromBody] UpdateBookingStatusRequest request)
        {
            await _service.UpdateBookingStatusAsync(id, request.Status);
            return Ok();
        }
    }
}
