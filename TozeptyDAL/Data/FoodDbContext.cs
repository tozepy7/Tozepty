using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TozeptyDAL;
using TozeptyDAL.Models;

namespace TozeptyDAL.Data
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext()
            : base("name=FoodDbContext")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<FoodDbContext>());
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the relationship between Customer and Order
            //modelBuilder.Entity<Category>().Property(c => c.CategoryName).HasMaxLength(255);

            base.OnModelCreating(modelBuilder);
        }
    }
}
