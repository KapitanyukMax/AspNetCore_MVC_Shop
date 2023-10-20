using DataAccess.Entities;
using DataAccess.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ShopDbContext : IdentityDbContext<User>
    {
        public ShopDbContext() { }

        public ShopDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                          Initial Catalog=ShopDb;
                                          Integrated Security=True;
                                          Connect Timeout=30;
                                          Encrypt=False;
                                          Trust Server Certificate=False;
                                          Application Intent=ReadWrite;
                                          Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Item>().HasKey(i => i.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);

            modelBuilder.Entity<Category>().HasMany(c => c.Items).WithOne(i => i.Category).HasForeignKey(i => i.CategoryId);
            modelBuilder.Entity<Item>().HasMany(i => i.Orders).WithMany(o => o.Items);
            modelBuilder.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);

            modelBuilder.SeedCategories();
            modelBuilder.SeedItems();
        }
    }
}
