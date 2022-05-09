using Hakims_Livs.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hakims_Livs.Data
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ShoppingCart>().HasKey(s => new
            {
                s.ProductId,
                s.UserId
            });



            base.OnModelCreating(modelBuilder);


        }
    }
}