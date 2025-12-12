using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Entities
{
    public class TicketType
    {
        [Key]
        public int TicketTypeId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } // VIP, Regular, EarlyBird

        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int QuantityAvailable { get; set; }

        // Navigation Properties
        public Event Event { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
