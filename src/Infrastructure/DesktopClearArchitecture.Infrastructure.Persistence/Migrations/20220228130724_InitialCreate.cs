namespace DesktopClearArchitecture.Infrastructure.Persistence.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc/>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Product",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Product", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Product",
            columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
            values: new object[,]
            {
                { 1L, new DateTime(2022, 2, 28, 17, 7, 23, 872, DateTimeKind.Local).AddTicks(3763), null, null, null, "Generic Granite Soap" },
                { 30L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(388), null, null, null, "Generic Rubber Bike" },
                { 31L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(404), null, null, null, "Fantastic Wooden Table" },
                { 32L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(421), null, null, null, "Intelligent Metal Fish" },
                { 33L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(438), null, null, null, "Unbranded Granite Chair" },
                { 34L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(455), null, null, null, "Ergonomic Rubber Car" },
                { 35L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(471), null, null, null, "Ergonomic Frozen Shoes" },
                { 36L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(488), null, null, null, "Unbranded Frozen Fish" },
                { 37L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(505), null, null, null, "Gorgeous Wooden Ball" },
                { 38L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(522), null, null, null, "Small Soft Table" },
                { 39L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(540), null, null, null, "Ergonomic Steel Chair" },
                { 40L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(627), null, null, null, "Generic Wooden Bike" },
                { 29L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(370), null, null, null, "Intelligent Fresh Chicken" },
                { 41L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(645), null, null, null, "Licensed Cotton Table" },
                { 43L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(678), null, null, null, "Sleek Rubber Bike" },
                { 44L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(695), null, null, null, "Handcrafted Granite Bacon" },
                { 45L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(712), null, null, null, "Rustic Granite Car" },
                { 46L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(729), null, null, null, "Intelligent Granite Cheese" },
                { 47L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(745), null, null, null, "Practical Plastic Pizza" },
                { 48L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(761), null, null, null, "Tasty Plastic Shoes" },
                { 49L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(777), null, null, null, "Unbranded Plastic Pants" },
                { 50L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(794), null, null, null, "Small Wooden Chicken" },
                { 51L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(838), null, null, null, "Handmade Plastic Pants" },
                { 52L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(857), null, null, null, "Licensed Plastic Mouse" },
                { 53L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(873), null, null, null, "Generic Fresh Hat" },
                { 42L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(662), null, null, null, "Intelligent Cotton Pizza" },
                { 54L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(889), null, null, null, "Generic Cotton Pants" },
                { 28L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(353), null, null, null, "Awesome Metal Sausages" },
                { 26L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(287), null, null, null, "Practical Plastic Mouse" },
                { 2L, new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9703), null, null, null, "Fantastic Metal Tuna" },
                { 3L, new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9795), null, null, null, "Rustic Steel Pants" },
                { 4L, new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9818), null, null, null, "Handmade Frozen Gloves" },
                { 5L, new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9903), null, null, null, "Gorgeous Wooden Shirt" },
                { 6L, new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9921), null, null, null, "Generic Granite Gloves" },
                { 7L, new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9938), null, null, null, "Gorgeous Fresh Salad" },
                { 8L, new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9956), null, null, null, "Ergonomic Plastic Bike" },
                { 9L, new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9973), null, null, null, "Incredible Plastic Car" },
                { 10L, new DateTime(2022, 2, 28, 17, 7, 23, 874, DateTimeKind.Local).AddTicks(9991), null, null, null, "Practical Granite Car" },
                { 11L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(7), null, null, null, "Handcrafted Cotton Ball" },
                { 12L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(24), null, null, null, "Intelligent Soft Soap" },
                { 27L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(304), null, null, null, "Awesome Metal Bike" },
                { 13L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(40), null, null, null, "Awesome Granite Hat" }
            });

        migrationBuilder.InsertData(
            table: "Product",
            columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
            values: new object[,]
            {
                { 15L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(74), null, null, null, "Licensed Wooden Tuna" },
                { 16L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(124), null, null, null, "Handcrafted Wooden Shoes" },
                { 17L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(141), null, null, null, "Handmade Granite Pizza" },
                { 18L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(157), null, null, null, "Licensed Metal Tuna" },
                { 19L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(173), null, null, null, "Generic Rubber Bike" },
                { 20L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(190), null, null, null, "Fantastic Steel Gloves" },
                { 21L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(207), null, null, null, "Generic Metal Towels" },
                { 22L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(222), null, null, null, "Incredible Wooden Hat" },
                { 23L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(238), null, null, null, "Small Steel Shirt" },
                { 24L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(254), null, null, null, "Licensed Steel Sausages" },
                { 25L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(270), null, null, null, "Refined Frozen Shirt" },
                { 14L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(57), null, null, null, "Incredible Cotton Shoes" },
                { 55L, new DateTime(2022, 2, 28, 17, 7, 23, 875, DateTimeKind.Local).AddTicks(905), null, null, null, "Sleek Rubber Tuna" }
            });
    }

    /// <inheritdoc/>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Product");
    }
}