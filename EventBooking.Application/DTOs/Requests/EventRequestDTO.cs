using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Domain.Enums;

namespace EventBooking.Application.DTOs.Requests
{
    public class EventRequestDTO
    {

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

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
        public EventStatus Status { get; set; }

        [Required]
        public EventCategory Category { get; set; }

        public string? ImageUrl { get; set; }

    }


    public class UpdateEventRequest : EventRequestDTO
    {
        public EventStatus Status { get; set; }
    }
}
