using Project.ENTITES.Models;
using Project.MAP.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new ProfileMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new PAttributeMap());
            modelBuilder.Configurations.Add(new ProductAttributeMap());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Order>  Orders { get; set; }
        public DbSet<OrderDetail>  OrderDetails { get; set; }
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<AppUser>  AppUsers { get; set; }
        public DbSet<AppUserProfile> AppUserProfiles { get; set; }
        public DbSet<PAttirubute>  PAttirubutes { get; set; }
        public DbSet<ProductAttribute>  ProductAttributes { get; set; }
    }
}
