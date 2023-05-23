using Microsoft.EntityFrameworkCore;
using PaymentService.Models;
using System.Reflection.Emit;

namespace PaymentService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid id = Guid.NewGuid();


            //modelBuilder.Entity<Pricing>().HasData(new Pricing { CarTypeId = id, Name = "Benzine", Description = "Benzine auto", PricePerKilometer = 0.11 });
        }

        public DbSet<PricingModel> Pricing { get; set; }

        //public DbSet<test2> Tests2 { get; set; }
    }
}
