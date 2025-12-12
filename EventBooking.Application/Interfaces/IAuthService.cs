using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Application.DTOs.Requests;
using EventBooking.Application.DTOs.Responses;
using EventBooking.Domain.Entities;
namespace EventBooking.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request, User currentUser = null);
        Task<AuthResponse> LoginAsync(LoginRequest request); 
         
    }
}
