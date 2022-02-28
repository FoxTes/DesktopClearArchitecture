﻿// <auto-generated />
using System;
using DesktopClearArchitecture.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesktopClearArchitecture.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220228130724_InitialCreate")]
    partial class InitialCreate
    {
        /// <summary>
        /// Build.
        /// </summary>
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesktopClearArchitecture.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 872, DateTimeKind.Local).AddTicks(3763),
                            Name = "Generic Granite Soap"
                        },
                        new
                        {
                            Id = 2L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9703),
                            Name = "Fantastic Metal Tuna"
                        },
                        new
                        {
                            Id = 3L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9795),
                            Name = "Rustic Steel Pants"
                        },
                        new
                        {
                            Id = 4L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9818),
                            Name = "Handmade Frozen Gloves"
                        },
                        new
                        {
                            Id = 5L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9903),
                            Name = "Gorgeous Wooden Shirt"
                        },
                        new
                        {
                            Id = 6L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9921),
                            Name = "Generic Granite Gloves"
                        },
                        new
                        {
                            Id = 7L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9938),
                            Name = "Gorgeous Fresh Salad"
                        },
                        new
                        {
                            Id = 8L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9956),
                            Name = "Ergonomic Plastic Bike"
                        },
                        new
                        {
                            Id = 9L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9973),
                            Name = "Incredible Plastic Car"
                        },
                        new
                        {
                            Id = 10L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9991),
                            Name = "Practical Granite Car"
                        },
                        new
                        {
                            Id = 11L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(7),
                            Name = "Handcrafted Cotton Ball"
                        },
                        new
                        {
                            Id = 12L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(24),
                            Name = "Intelligent Soft Soap"
                        },
                        new
                        {
                            Id = 13L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(40),
                            Name = "Awesome Granite Hat"
                        },
                        new
                        {
                            Id = 14L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(57),
                            Name = "Incredible Cotton Shoes"
                        },
                        new
                        {
                            Id = 15L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(74),
                            Name = "Licensed Wooden Tuna"
                        },
                        new
                        {
                            Id = 16L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(124),
                            Name = "Handcrafted Wooden Shoes"
                        },
                        new
                        {
                            Id = 17L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(141),
                            Name = "Handmade Granite Pizza"
                        },
                        new
                        {
                            Id = 18L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(157),
                            Name = "Licensed Metal Tuna"
                        },
                        new
                        {
                            Id = 19L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(173),
                            Name = "Generic Rubber Bike"
                        },
                        new
                        {
                            Id = 20L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(190),
                            Name = "Fantastic Steel Gloves"
                        },
                        new
                        {
                            Id = 21L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(207),
                            Name = "Generic Metal Towels"
                        },
                        new
                        {
                            Id = 22L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(222),
                            Name = "Incredible Wooden Hat"
                        },
                        new
                        {
                            Id = 23L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(238),
                            Name = "Small Steel Shirt"
                        },
                        new
                        {
                            Id = 24L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(254),
                            Name = "Licensed Steel Sausages"
                        },
                        new
                        {
                            Id = 25L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(270),
                            Name = "Refined Frozen Shirt"
                        },
                        new
                        {
                            Id = 26L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(287),
                            Name = "Practical Plastic Mouse"
                        },
                        new
                        {
                            Id = 27L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(304),
                            Name = "Awesome Metal Bike"
                        },
                        new
                        {
                            Id = 28L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(353),
                            Name = "Awesome Metal Sausages"
                        },
                        new
                        {
                            Id = 29L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(370),
                            Name = "Intelligent Fresh Chicken"
                        },
                        new
                        {
                            Id = 30L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(388),
                            Name = "Generic Rubber Bike"
                        },
                        new
                        {
                            Id = 31L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(404),
                            Name = "Fantastic Wooden Table"
                        },
                        new
                        {
                            Id = 32L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(421),
                            Name = "Intelligent Metal Fish"
                        },
                        new
                        {
                            Id = 33L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(438),
                            Name = "Unbranded Granite Chair"
                        },
                        new
                        {
                            Id = 34L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(455),
                            Name = "Ergonomic Rubber Car"
                        },
                        new
                        {
                            Id = 35L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(471),
                            Name = "Ergonomic Frozen Shoes"
                        },
                        new
                        {
                            Id = 36L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(488),
                            Name = "Unbranded Frozen Fish"
                        },
                        new
                        {
                            Id = 37L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(505),
                            Name = "Gorgeous Wooden Ball"
                        },
                        new
                        {
                            Id = 38L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(522),
                            Name = "Small Soft Table"
                        },
                        new
                        {
                            Id = 39L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(540),
                            Name = "Ergonomic Steel Chair"
                        },
                        new
                        {
                            Id = 40L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(627),
                            Name = "Generic Wooden Bike"
                        },
                        new
                        {
                            Id = 41L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(645),
                            Name = "Licensed Cotton Table"
                        },
                        new
                        {
                            Id = 42L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(662),
                            Name = "Intelligent Cotton Pizza"
                        },
                        new
                        {
                            Id = 43L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(678),
                            Name = "Sleek Rubber Bike"
                        },
                        new
                        {
                            Id = 44L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(695),
                            Name = "Handcrafted Granite Bacon"
                        },
                        new
                        {
                            Id = 45L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(712),
                            Name = "Rustic Granite Car"
                        },
                        new
                        {
                            Id = 46L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(729),
                            Name = "Intelligent Granite Cheese"
                        },
                        new
                        {
                            Id = 47L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(745),
                            Name = "Practical Plastic Pizza"
                        },
                        new
                        {
                            Id = 48L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(761),
                            Name = "Tasty Plastic Shoes"
                        },
                        new
                        {
                            Id = 49L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(777),
                            Name = "Unbranded Plastic Pants"
                        },
                        new
                        {
                            Id = 50L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(794),
                            Name = "Small Wooden Chicken"
                        },
                        new
                        {
                            Id = 51L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(838),
                            Name = "Handmade Plastic Pants"
                        },
                        new
                        {
                            Id = 52L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(857),
                            Name = "Licensed Plastic Mouse"
                        },
                        new
                        {
                            Id = 53L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(873),
                            Name = "Generic Fresh Hat"
                        },
                        new
                        {
                            Id = 54L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(889),
                            Name = "Generic Cotton Pants"
                        },
                        new
                        {
                            Id = 55L,
                            Created = new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(905),
                            Name = "Sleek Rubber Tuna"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
