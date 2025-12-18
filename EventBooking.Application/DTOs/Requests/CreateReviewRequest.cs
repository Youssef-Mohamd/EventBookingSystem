using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.DTOs.Requests
{
    public class CreateReviewRequest
    {
        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
