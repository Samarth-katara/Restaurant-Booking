using Microsoft.EntityFrameworkCore;
using Restaurant_Booking_App.Models;

namespace Restaurant_Booking_App.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions options) : base(options)
        {
        }
            //Dbset

            public DbSet<Card> cards { get; set; }


        
    }
}
