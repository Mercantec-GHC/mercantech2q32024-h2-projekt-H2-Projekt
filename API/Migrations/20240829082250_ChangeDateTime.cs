using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<DateTime>>(
                name: "booking_dates",
                table: "bookings",
                type: "timestamp with time zone[]",
                nullable: false,
                oldClrType: typeof(List<DateOnly>),
                oldType: "date[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<DateOnly>>(
                name: "booking_dates",
                table: "bookings",
                type: "date[]",
                nullable: false,
                oldClrType: typeof(List<DateTime>),
                oldType: "timestamp with time zone[]");
        }
    }
}
