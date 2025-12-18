using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Domain.Enums;

namespace EventBooking.Application.DTOs.Requests
{
    public class CreateBookingRequest
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        public int TicketTypeId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }

    public class UpdateBookingStatusRequest
    {
        [Required]
        public BookingStatus Status { get; set; }
    }

}
