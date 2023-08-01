using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class Assignment8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetUTCDate()");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "LineItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedTotalPrice",
                table: "LineItems",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                computedColumnSql: "CAST([NumOfProducts] * [ProductPrice] * (1 - [DiscountPercentage] / 100) AS DECIMAL(18, 2))",
                stored: true);

            migrationBuilder.UpdateData(
                table: "LineItems",
                keyColumn: "LineItemId",
                keyValue: 1,
                column: "DiscountPercentage",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "LineItems",
                keyColumn: "LineItemId",
                keyValue: 2,
                column: "DiscountPercentage",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "LineItems",
                keyColumn: "LineItemId",
                keyValue: 3,
                column: "DiscountPercentage",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DateOrderedUtc",
                value: new DateTime(2023, 7, 28, 4, 48, 47, 971, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "DateOrderedUtc",
                value: new DateTime(2023, 7, 29, 4, 48, 47, 971, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "DateOrderedUtc",
                value: new DateTime(2023, 7, 30, 4, 48, 47, 971, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "PriceOffers",
                keyColumn: "PriceOfferId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 4, 48, 47, 971, DateTimeKind.Local).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "PriceOffers",
                keyColumn: "PriceOfferId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 4, 48, 47, 971, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "PriceOffers",
                keyColumn: "PriceOfferId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 4, 48, 47, 971, DateTimeKind.Local).AddTicks(9058));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItemTableFunction");

            migrationBuilder.DropColumn(
                name: "DiscountedTotalPrice",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "LineItems");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DateOrderedUtc",
                value: new DateTime(2023, 7, 26, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "DateOrderedUtc",
                value: new DateTime(2023, 7, 27, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "DateOrderedUtc",
                value: new DateTime(2023, 7, 28, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "PriceOffers",
                keyColumn: "PriceOfferId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "PriceOffers",
                keyColumn: "PriceOfferId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "PriceOffers",
                keyColumn: "PriceOfferId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2144));
        }
    }
}
