using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace EventBooking.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // DbSets for  entities 
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // conversion for enums to string

            modelBuilder.Entity<Event>()
                .Property(equals=>equals.Category)
                .HasConversion<string>();


            modelBuilder.Entity<Booking>()
                .Property(b => b.Status)
                .HasConversion<string>();


            modelBuilder.Entity<Event>()
               .Property(b => b.Status)
               .HasConversion<string>();

            modelBuilder
               .Entity<User>()
               .Property(u => u.Role)
               .HasConversion<string>();


            // Relationship configurations


            // User 1-M Bookings
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Event 1-M Bookings
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // User 1-M Reviews
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Event 1-M Reviews
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Reviews)
                .HasForeignKey(r => r.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // Event 1-M TicketTypes
            modelBuilder.Entity<TicketType>()
                .HasOne(t => t.Event)
                .WithMany(e => e.TicketTypes)
                .HasForeignKey(t => t.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // Wishlist: User 1-M Wishlists
            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Wishlist: Event 1-M Wishlists
            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.Event)
                .WithMany(e => e.Wishlists)
                .HasForeignKey(w => w.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // Booking - TicketType relationship
            modelBuilder.Entity<Booking>()
    .HasOne(b => b.TicketType)
    .WithMany(t => t.Bookings)
    .HasForeignKey(b => b.TicketTypeId)
    .OnDelete(DeleteBehavior.Restrict);



            // Decimal precision configuration
            modelBuilder.Entity<Event>()
    .Property(e => e.Price)
    .HasPrecision(18, 2);

            modelBuilder.Entity<TicketType>()
                .Property(t => t.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalPrice)
                .HasPrecision(18, 2);

        }
    }
}
