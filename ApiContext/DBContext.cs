using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ApiContext
{
     public class DBContext : IdentityDbContext<User, Role, int>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        modelBuilder.Entity<Category>()
       .HasMany<Product>(g => g.Products)
       
       .WithOne(s => s.category).HasForeignKey(p=>p.CategoryId)
       .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Order>()
     .HasMany<OrderItem>(g => g.OrderItems)
     .WithOne(s => s.Order)
     .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
  .HasOne<OrderItem>()
  .WithOne(s => s.Product)
  .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> orderItems { get; set; }

        public DbSet<WishList> WishList { get; set; }




    }
}
