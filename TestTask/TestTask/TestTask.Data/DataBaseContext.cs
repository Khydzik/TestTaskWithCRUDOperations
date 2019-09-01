using Microsoft.EntityFrameworkCore;
using TestTask.Data.Models;

namespace TestTask.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(new Order[] { new Order { Id = new System.Guid("2c854d74-d3c5-43f8-aada-29d769c46049"), Number = 13, Amount = 12.9M }});
            modelBuilder.Entity<Product>().HasData(new Product[] { new Product { Id = new System.Guid("f36ca7c8-15fb-49be-b447-e405bc474c90"), Name = "Phone", Price = 1493M }});
            modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[] {  new OrderProduct
            {
                Id = new System.Guid("711fad24-71dc-4763-85a6-0331e01fbb5d"),
                OrderId = new System.Guid("2c854d74-d3c5-43f8-aada-29d769c46049"),
                ProductId = new System.Guid("f36ca7c8-15fb-49be-b447-e405bc474c90")
            } });
        }
    }
}
