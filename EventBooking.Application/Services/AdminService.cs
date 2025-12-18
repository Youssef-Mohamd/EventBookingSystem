using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Application.DTOs.Requests;
using EventBooking.Application.Interfaces;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Enums;
using EventBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTicketAsync(int eventId, TicketTypeRequest request)
        {
            var ticket = new TicketType
            {
                EventId = eventId,
                Name = request.Name,
                Price = request.Price,
                QuantityAvailable = request.QuantityAvailable
            };

            _context.TicketTypes.Add(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateEventAsync(EventRequestDTO request)
        {
            var ev = new Event
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Price = request.Price,
                Location = request.Location,
                Category = request.Category
            };

            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return ev.EventId;
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var ev = await _context.Events.FindAsync(eventId)
                ?? throw new Exception("Event not found");

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            var ticket = await _context.TicketTypes.FindAsync(ticketId)
                ?? throw new Exception("Ticket not found");

            _context.TicketTypes.Remove(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Event)
                .ToListAsync();
        }

        public async Task UpdateBookingStatusAsync(int bookingId, BookingStatus status)
        {
            var booking = await _context.Bookings.FindAsync(bookingId)
                ?? throw new Exception("Booking not found");

            booking.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(int eventId, UpdateEventRequest request)
        {
            var ev = await _context.Events.FindAsync(eventId)
                ?? throw new Exception("Event not found");

            ev.Title = request.Title;
            ev.Description = request.Description;
            ev.StartDate = request.StartDate;
            ev.EndDate = request.EndDate;
            ev.Price = request.Price;
            ev.Location = request.Location;
            ev.Category = request.Category;
            ev.Status = request.Status;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(int ticketId, TicketTypeRequest request)
        {
            var ticket = await _context.TicketTypes.FindAsync(ticketId)
                ?? throw new Exception("Ticket not found");

            ticket.Name = request.Name;
            ticket.Price = request.Price;
            ticket.QuantityAvailable = request.QuantityAvailable;

            await _context.SaveChangesAsync();
        }
    }
}
