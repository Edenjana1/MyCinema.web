using Microsoft.EntityFrameworkCore;
using MyCinema.Models;

namespace MyCinema.Data
{
    public class MyCinemaContext : DbContext
    {
        public MyCinemaContext(DbContextOptions<MyCinemaContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
    }

}

