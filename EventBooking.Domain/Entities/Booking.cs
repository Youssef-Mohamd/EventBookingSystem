using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Domain.Enums;

namespace EventBooking.Domain.Entities
{
    public class Booking
    {
            [Key]
            public int BookingId { get; set; }

            [Required]
            public int UserId { get; set; }

            [Required]
            public int EventId { get; set; }

            [Required]
            public BookingStatus Status { get; set; } = BookingStatus.Pending;

            [Required, Range(1, int.MaxValue)]
            public int Quantity { get; set; }

            [Required, Range(0, double.MaxValue)]
            public decimal TotalPrice { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            // Navigation Properties
            public User User { get; set; } 
            public Event Event { get; set; }
        //public ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }

    }

}

