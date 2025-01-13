using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CartItems>()
                .HasKey(items => new {items.ProductId,items.CartId});

            builder.Entity<CartItems>()
                .HasOne(items => items.Cart)
                .WithMany(items => items.CartItems)
                .HasForeignKey(items => items.CartId);    
        }
        public DbSet<AppUser> AppUsers{get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Cart> Carts {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<Order>Orders {get;set;}
        public DbSet<CartItems> CartItems {get;set;}
    }
}