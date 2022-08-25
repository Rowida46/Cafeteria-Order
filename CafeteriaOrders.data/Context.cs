using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.data
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> Cartitems { get; set; }


        public DbSet<Meals> meals { get; set; } 
        public DbSet<Review> reviews { get; set; }
        // public DbSet<Categories> categories { get; set; }
        public DbSet<Recipe> recipes { get; set; }






    }
}
