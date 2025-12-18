using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Application.DTOs.Requests;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Enums;

namespace EventBooking.Application.Interfaces
{
    public interface IAdminService
    {

        Task<int> CreateEventAsync(EventRequestDTO request);
        Task UpdateEventAsync(int eventId, UpdateEventRequest request);
        Task DeleteEventAsync(int eventId);


        Task AddTicketAsync(int eventId, TicketTypeRequest request);
        Task UpdateTicketAsync(int ticketId, TicketTypeRequest request);
        Task DeleteTicketAsync(int ticketId);


        Task<List<Booking>> GetAllBookingsAsync();
        Task UpdateBookingStatusAsync(int bookingId, BookingStatus status);

    }
}
