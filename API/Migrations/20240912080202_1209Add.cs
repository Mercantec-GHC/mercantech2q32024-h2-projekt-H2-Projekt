using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class _1209Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77dc6f7d-31db-4db5-8887-87bf7f065cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2727a82-4d5a-4fd5-b420-c9b1250d0b72");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Rooms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerNight",
                table: "RoomType",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "Reservations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "Reservations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d423a02-1f6f-4c2e-a778-905667d37890", null, "User", "USER" },
                    { "f28f4b77-0a69-494d-9348-0e8340b18907", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d423a02-1f6f-4c2e-a778-905667d37890");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f28f4b77-0a69-494d-9348-0e8340b18907");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PricePerNight",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Reservations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77dc6f7d-31db-4db5-8887-87bf7f065cee", null, "User", "USER" },
                    { "a2727a82-4d5a-4fd5-b420-c9b1250d0b72", null, "Admin", "ADMIN" }
                });
        }
    }
}
