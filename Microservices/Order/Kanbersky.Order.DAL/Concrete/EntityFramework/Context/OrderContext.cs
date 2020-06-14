using Kanbersky.Order.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Kanbersky.Order.DAL.Concrete.EntityFramework.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Concrete.Order>()
                        .HasMany(e => e.OrderItems)
                        .WithOne(c => c.Order);
        }

        public DbSet<Entities.Concrete.Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
