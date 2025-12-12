using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Enums
{
    public enum UserRole
    {
        User,
        Admin
    }

    public enum EventStatus
    {
        Upcoming,
        Ongoing,
        Completed,
        Cancelled
    }

    public enum EventCategory
    {
        Music,
        Sports,
        Tech,
        Art,
        Education
    }

    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
}
