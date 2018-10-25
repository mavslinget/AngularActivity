using Microsoft.EntityFrameworkCore;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace OnlineStore.EFCore.Infra
{
    public class OnlineStoreDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Name> Names { get; set; }

        public DbSet<Show> Shows { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }


        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options)
        {

        }

        public OnlineStoreDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=OnlineStoreDB;Integrated Security=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().ToTable("Category");
        //    modelBuilder.Entity<Customer>().ToTable("Customer");
        //    modelBuilder.Entity<Department>().ToTable("Department");
        //    modelBuilder.Entity<Employee>().ToTable("Employee");
        //    modelBuilder.Entity<Order>().ToTable("Order");
        //    modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
        //    modelBuilder.Entity<Product>().ToTable("Product");
        //    modelBuilder.Entity<Shipper>().ToTable("Shipper");
        //    modelBuilder.Entity<Supplier>().ToTable("Supplier");
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
