using MetalMogul.Models;
using Microsoft.EntityFrameworkCore;

namespace MetalMogul.Data
{
    public class MetalDbContext : DbContext
    {
        public MetalDbContext(DbContextOptions<MetalDbContext> options) : base(options)
        {
        }
        public DbSet<Band> Bands => Set<Band>();
        public DbSet<BandConcert> Bands_Concerts => Set<BandConcert>();
        public DbSet<Venue> Venues => Set<Venue>();
        public DbSet<Concert> Concerts => Set<Concert>();
        public DbSet<ConcertOrder> Concerts_Orders => Set<ConcertOrder>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();
    }
}
