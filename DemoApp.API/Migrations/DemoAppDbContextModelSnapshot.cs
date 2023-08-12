﻿// <auto-generated />
using System;
using DemoApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoApp.API.Migrations
{
    [DbContext(typeof(DemoAppDbContext))]
    partial class DemoAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DemoApp.API.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "ELECT",
                            CreatedOn = new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1782),
                            Description = "Electronic products",
                            Name = "Electronics",
                            UpdatedOn = new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1798)
                        },
                        new
                        {
                            Id = 2,
                            Code = "BEAUT",
                            CreatedOn = new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1800),
                            Description = "Beauty cosmetics",
                            Name = "Beauty",
                            UpdatedOn = new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1800)
                        },
                        new
                        {
                            Id = 3,
                            Code = "FASHN",
                            CreatedOn = new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1801),
                            Description = "Fashion apperal",
                            Name = "Fashion",
                            UpdatedOn = new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1802)
                        });
                });

            modelBuilder.Entity("DemoApp.API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DemoApp.API.Models.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("DemoApp.API.Models.Product", b =>
                {
                    b.HasOne("DemoApp.API.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DemoApp.API.Models.ProductDetail", b =>
                {
                    b.HasOne("DemoApp.API.Models.Product", "Product")
                        .WithOne("ProductDetail")
                        .HasForeignKey("DemoApp.API.Models.ProductDetail", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DemoApp.API.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DemoApp.API.Models.Product", b =>
                {
                    b.Navigation("ProductDetail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
