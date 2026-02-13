using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PinjamRuang.Migrations
{
    /// <inheritdoc />
    public partial class CreateBorrowingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Borrowings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    NamaPeminjam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keperluan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanggal = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "pending"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrowings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 10, 24, 52, 503, DateTimeKind.Utc).AddTicks(5489), new DateTime(2026, 2, 13, 10, 24, 52, 503, DateTimeKind.Utc).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 10, 24, 52, 503, DateTimeKind.Utc).AddTicks(5505), new DateTime(2026, 2, 13, 10, 24, 52, 503, DateTimeKind.Utc).AddTicks(5505) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 10, 24, 52, 503, DateTimeKind.Utc).AddTicks(5507), new DateTime(2026, 2, 13, 10, 24, 52, 503, DateTimeKind.Utc).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 10, 24, 52, 503, DateTimeKind.Utc).AddTicks(5510), new DateTime(2026, 2, 13, 10, 24, 52, 503, DateTimeKind.Utc).AddTicks(5510) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 10, 24, 52, 503, DateTimeKind.Utc).AddTicks(5512), new DateTime(2026, 2, 13, 10, 24, 52, 503, DateTimeKind.Utc).AddTicks(5512) });

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_RoomId",
                table: "Borrowings",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrowings");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5606), new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5616), new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5616) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5618), new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5619) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5621), new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5621) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5623), new DateTime(2026, 2, 10, 10, 45, 53, 41, DateTimeKind.Utc).AddTicks(5623) });
        }
    }
}
