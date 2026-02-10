using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PinjamRuang.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "CreatedAt", "DeletedAt", "Description", "Location", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 40, new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5606), null, "Ruang kelas lantai 1", "Gedung A", "Ruang A101", "available", new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5610) },
                    { 2, 30, new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5616), null, "Ruang rapat", "Gedung B", "Ruang B202", "available", new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5616) },
                    { 3, 200, new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5618), null, "Untuk acara besar", "Gedung Serbaguna", "Aula Utama", "unavailable", new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5619) },
                    { 4, 25, new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5621), null, null, "Gedung C", "Lab Komputer 1", "available", new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5621) },
                    { 5, 35, new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5623), null, null, "Gedung D", "Ruang D303", "available", new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5623) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
