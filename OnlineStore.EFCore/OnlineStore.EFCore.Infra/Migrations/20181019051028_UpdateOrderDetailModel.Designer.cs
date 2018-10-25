﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore.EFCore.Infra;

namespace OnlineStore.EFCore.Infra.Migrations
{
    [DbContext(typeof(OnlineStoreDbContext))]
    [Migration("20181019051028_UpdateOrderDetailModel")]
    partial class UpdateOrderDetailModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Actor", b =>
                {
                    b.Property<Guid>("ActorID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Age");

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nationality")
                        .IsRequired();

                    b.Property<decimal>("NumberOfFilm");

                    b.Property<string>("SocialMediaAccount");

                    b.Property<bool>("isActive");

                    b.HasKey("ActorID");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<byte[]>("Picture");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Fax")
                        .HasMaxLength(15);

                    b.Property<string>("Phone")
                        .HasMaxLength(15);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(15);

                    b.Property<string>("Region")
                        .HasMaxLength(100);

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Department", b =>
                {
                    b.Property<Guid>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("Country")
                        .HasMaxLength(100);

                    b.Property<string>("Extension")
                        .HasMaxLength(6);

                    b.Property<string>("FirstName")
                        .HasMaxLength(60);

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("HomePhone")
                        .HasMaxLength(15);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Notes")
                        .HasMaxLength(1000);

                    b.Property<byte[]>("Photo");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(15);

                    b.Property<string>("Region")
                        .HasMaxLength(100);

                    b.Property<Guid>("ReportTo");

                    b.Property<string>("Title")
                        .HasMaxLength(60);

                    b.Property<string>("TitleOfCourtesy")
                        .HasMaxLength(60);

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerID");

                    b.Property<Guid>("EmployeeID");

                    b.Property<decimal>("Freight");

                    b.Property<DateTime>("OrderDate");

                    b.Property<DateTime>("RequiredDate");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ShipCity")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ShipCountry")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("ShipPostalCode")
                        .HasMaxLength(15);

                    b.Property<string>("ShipRegion")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ShippedDate");

                    b.Property<Guid>("ShipperID");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ShipperID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderDetailID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Discount");

                    b.Property<int>("OrderDetailLineID");

                    b.Property<Guid>("OrderID");

                    b.Property<Guid>("ProductID");

                    b.Property<decimal>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryID");

                    b.Property<bool>("Discontinued");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<decimal>("QuantityPerUnit");

                    b.Property<decimal>("ReorderLevel");

                    b.Property<Guid>("SupplierID");

                    b.Property<decimal>("UnitPrice");

                    b.Property<decimal>("UnitsInOrder");

                    b.Property<decimal>("UnitsInStock");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Shipper", b =>
                {
                    b.Property<Guid>("ShipperID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("ShipperID");

                    b.ToTable("Shipper");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Show", b =>
                {
                    b.Property<Guid>("ShowID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlternativeTitle")
                        .HasMaxLength(60);

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.Property<bool>("IsComplete");

                    b.Property<decimal>("NumberOfEpisode");

                    b.Property<decimal>("Season");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<decimal>("YearStarted");

                    b.HasKey("ShowID");

                    b.ToTable("Show");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Supplier", b =>
                {
                    b.Property<Guid>("SupplierID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Country")
                        .HasMaxLength(100);

                    b.Property<string>("Fax")
                        .HasMaxLength(15);

                    b.Property<string>("HomePage")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasMaxLength(15);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(15);

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("SupplierID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Order", b =>
                {
                    b.HasOne("OnlineStore.EFCore.Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineStore.EFCore.Domain.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineStore.EFCore.Domain.Models.Shipper", "ShipVia")
                        .WithMany()
                        .HasForeignKey("ShipperID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.OrderDetail", b =>
                {
                    b.HasOne("OnlineStore.EFCore.Domain.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineStore.EFCore.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineStore.EFCore.Domain.Models.Product", b =>
                {
                    b.HasOne("OnlineStore.EFCore.Domain.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineStore.EFCore.Domain.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
