﻿// <auto-generated />
using Discount.Grpc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Discount.Grpc.Migrations
{
    [DbContext(typeof(DiscountContext))]
    partial class DiscountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Discount.Grpc.Models.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 150,
                            Description = "The MacBook Air is ultra-thin and lightweight, equipped with the M1 chip for powerful performance and incredible battery life of up to 18 hours.",
                            ProductName = "Apple MacBook Air"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 150,
                            Description = "The Samsung Galaxy S21 features a stunning 6.2-inch display, triple-camera system, and a powerful Exynos 2100 processor for seamless multitasking.",
                            ProductName = "Samsung Galaxy S21"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 150,
                            Description = "The LG UltraGear 27GN950-B is a 27-inch 4K UHD gaming monitor with a 144Hz refresh rate and NVIDIA G-SYNC compatibility, delivering stunning visuals for an immersive gaming experience.",
                            ProductName = "LG UltraGear 27GN950-B"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 150,
                            Description = "Industry-leading noise cancellation, exceptional sound quality, and up to 30 hours of battery life make the Sony WH-1000XM4 the perfect travel companion.",
                            ProductName = "Sony WH-1000XM4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
