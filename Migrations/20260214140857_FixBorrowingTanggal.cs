using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PinjamRuang.Migrations
{
    /// <inheritdoc />
    public partial class FixBorrowingTanggal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Tanggal",
                table: "Borrowings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 14, 8, 54, 638, DateTimeKind.Utc).AddTicks(2616), new DateTime(2026, 2, 14, 14, 8, 54, 638, DateTimeKind.Utc).AddTicks(2617) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 14, 8, 54, 638, DateTimeKind.Utc).AddTicks(2623), new DateTime(2026, 2, 14, 14, 8, 54, 638, DateTimeKind.Utc).AddTicks(2624) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 14, 8, 54, 638, DateTimeKind.Utc).AddTicks(2627), new DateTime(2026, 2, 14, 14, 8, 54, 638, DateTimeKind.Utc).AddTicks(2628) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 14, 8, 54, 638, DateTimeKind.Utc).AddTicks(2630), new DateTime(2026, 2, 14, 14, 8, 54, 638, DateTimeKind.Utc).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 14, 8, 54, 638, DateTimeKind.Utc).AddTicks(2632), new DateTime(2026, 2, 14, 14, 8, 54, 638, DateTimeKind.Utc).AddTicks(2632) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Tanggal",
                table: "Borrowings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
        }
    }
}
