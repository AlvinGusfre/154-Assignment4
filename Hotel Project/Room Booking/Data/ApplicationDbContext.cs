using Microsoft.EntityFrameworkCore;
using Room_Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Room_Booking.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Room_Booking.Models.Movie> Movie { get; set; }


    }
}
