using Domain.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.ShoppingCartDbContext
{
    public class CartDbContext: DbContext
    {
        public CartDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(u => u.User)
                .WithMany(o => o.OrderList)
                .HasForeignKey(o => o.UserId);
        }

    }
    public class BloggingContextFactory : IDesignTimeDbContextFactory<CartDbContext>
    {

        public CartDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CartDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-663BMID;Database=CartDbContext;Trusted_Connection=True;TrustServerCertificate=True");

            return new CartDbContext(optionsBuilder.Options);
        }
    }
}

