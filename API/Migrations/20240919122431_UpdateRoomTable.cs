using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b2bb79f2-6fec-4d4c-92aa-db1b1a9ac5ca");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "e6a4bed4-d21c-43ac-8f0d-67950ba8122c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8c03b77d-5250-4b0b-b6cc-eaf3a89760a8");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Rooms",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Rooms",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Rooms",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<List<string>>(
                name: "Tags",
                table: "Rooms",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Rooms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07616f93-6738-4aaa-86ae-af87390fe298", null, "Admin", "ADMIN" },
                    { "aafc45d7-d1f8-4487-b390-fa76b26e2c7f", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0cf29eff-ebb0-4e20-9d14-eff962545aed", 0, "1ef8fa46-a2f5-48d9-964a-176f98c91d8a", "User", "admin@admin.com", false, "Admin", "Admin", false, null, null, null, "AQAAAAIAAYagAAAAEHlcdVOeRVrHWSJ8dOLTmB0fBhl3Uym/p43jyuZ0Afu5f9RWxuYAdCN1+q8w1E71Og==", "123456789", false, "d60e1562-022e-416d-96ab-c72119188d88", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "07616f93-6738-4aaa-86ae-af87390fe298");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "aafc45d7-d1f8-4487-b390-fa76b26e2c7f");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0cf29eff-ebb0-4e20-9d14-eff962545aed");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Rooms");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Rooms",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rooms",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PricePerNight = table.Column<decimal>(type: "numeric", nullable: false),
                    RoomTypeName = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b2bb79f2-6fec-4d4c-92aa-db1b1a9ac5ca", null, "Admin", "ADMIN" },
                    { "e6a4bed4-d21c-43ac-8f0d-67950ba8122c", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8c03b77d-5250-4b0b-b6cc-eaf3a89760a8", 0, "47b93d02-f6f5-436f-a49e-0bdd9980c365", "User", "admin@admin.com", false, "Admin", "Admin", false, null, null, null, "AQAAAAIAAYagAAAAEJq55i7bCo+xKTHCJsZL+ZBLU5a+zlbi9p6lmEG79gfdaBE18NNseTey5o5zJyyoig==", "123456789", false, "633f5c29-ef3f-40cc-8a1c-88f1e9c2f7d9", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
