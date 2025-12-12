using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Application.DTOs.Requests;

namespace EventBooking.Application.DTOs.Responses
{
    public class AuthResponse
    {
            public string Token { get; set; }   // JWT Token
           public UserDto User { get; set; }   
        
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
