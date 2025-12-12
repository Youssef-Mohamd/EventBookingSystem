using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Domain.Enums;

namespace EventBooking.Domain.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required, MaxLength(200)]
        public string Location { get; set; }

        [Required]
        public EventStatus Status { get; set; } = EventStatus.Upcoming;

        [Required]
        public EventCategory Category { get; set; }

        // Navigation Properties
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
        public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();

    }
}
