using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Domain.Entities;

namespace EventBooking.Infrastructure.Data
{
    public static class DatabaseSeeder
    {
        public static void SeedAdmin(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.Role == "Admin"))
            {
                using var hmac = new HMACSHA256();
                var admin = new User
                {
                    FullName = "System Admin",
                    Email = "admin@email.com",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Admin@123")),
                    PasswordSalt = hmac.Key,
                    Role = "Admin",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                context.Users.Add(admin);
                context.SaveChanges();
            }
        }
    }
}
