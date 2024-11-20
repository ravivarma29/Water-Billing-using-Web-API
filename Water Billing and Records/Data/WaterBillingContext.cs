using Microsoft.EntityFrameworkCore;
using Water_Billing_and_Records.Models;

namespace Water_Billing_and_Records.Data
{
    public class WaterBillingContext : DbContext
    {
        public WaterBillingContext(DbContextOptions<WaterBillingContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bill> Bills { get; set; }
    }
}