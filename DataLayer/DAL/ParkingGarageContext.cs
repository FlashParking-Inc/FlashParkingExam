using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class ParkingGarageContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=postgres;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<LocationSection>()
            //    .HasOne(x => x.location);
            //modelBuilder.Entity<LocationSection>().Navigation(x => x.location).AutoInclude();
        }

        public DbSet<Location>? location { get; set; }
        public DbSet<LocationSection>? locationsection { get; set; }
        public DbSet<ParkingSpace>? parking_space { get; set; }
        public DbSet<Vehicle>? vehicle { get; set; }

    }
}
