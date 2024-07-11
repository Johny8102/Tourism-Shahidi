using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project_2.Models
{
    public class TourismDbcontext : DbContext
    {
        public TourismDbcontext(DbContextOptions<TourismDbcontext> options)
            : base(options)
        { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Active_Tours> Active_Tours { get; set; }

    }

    

}
