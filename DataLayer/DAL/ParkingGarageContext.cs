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

        public DbSet<Location>? Location { get; set; }
        public DbSet<LocationSection>? LocationSection { get; set; }
        public DbSet<ParkingSpace>? ParkingSpace { get; set; }
        public DbSet<Vehicle>? vehicle { get; set; }

    }
}
