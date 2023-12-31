﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Service.Shop.Coupons.Database;

#nullable disable

namespace Service.Shop.Coupons.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230913142709_AddDbContext")]
    partial class AddDbContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Service.Shop.Coupons.Model.CouponModel", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CouponCode")
                        .HasColumnType("double");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("double");

                    b.Property<double>("MinDiscount")
                        .HasColumnType("double");

                    b.HasKey("CouponId");

                    b.ToTable("Coupons");
                });
#pragma warning restore 612, 618
        }
    }
}
