using System;
using InventoryAppEFCore.DataLayer.EfClasses.Views;
using InventoryAppEFCore.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class Seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Name" },
                values: new object[,]
                {
                    { 1, "Client A" },
                    { 2, "Client B" },
                    { 3, "Client C" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name" },
                values: new object[,]
                {
                    { 1, "Product A" },
                    { 2, "Product B" },
                    { 3, "Product C" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description of Supplier A", "Supplier A" },
                    { 2, "Description of Supplier B", "Supplier B" },
                    { 3, "Description of Supplier C", "Supplier C" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                column: "TagId",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ClientId", "DateOrderedUtc", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 26, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2111), "Pending" },
                    { 2, 2, new DateTime(2023, 7, 27, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2128), "InProgress" },
                    { 3, 3, new DateTime(2023, 7, 28, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2129), "Complete" }
                });

            migrationBuilder.InsertData(
                table: "PriceOffers",
                columns: new[] { "PriceOfferId", "CreatedDate", "NewPrice", "ProductId", "PromotinalText" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 31, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2141), 100m, 1, "Promotional Text 1" },
                    { 2, new DateTime(2023, 7, 31, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2144), 200m, 2, "Promotional Text 2" },
                    { 3, new DateTime(2023, 7, 31, 3, 26, 0, 361, DateTimeKind.Local).AddTicks(2144), 300m, 3, "Promotional Text 3" }
                });

            migrationBuilder.InsertData(
                table: "ProductSupplier",
                columns: new[] { "ProductId", "SupplierId", "Order" },
                values: new object[,]
                {
                    { 1, 1, (byte)1 },
                    { 2, 2, (byte)2 },
                    { 3, 3, (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Comment", "ProductId", "VoterName" },
                values: new object[,]
                {
                    { 1, "This is a Comment 1", 1, "Voter A" },
                    { 2, "This is a Comment 2", 2, "Voter B" },
                    { 3, "This is a Comment 3", 3, "Voter C" }
                });

            // Manually added to Seed data to ProductTag table
            migrationBuilder.InsertData(
                table: "ProductTag",
                columns: new[] { "ProductsProductId", "TagsTagId" },
                values: new object[] { 1, 1 });
            migrationBuilder.InsertData(
                table: "ProductTag",
                columns: new[] { "ProductsProductId", "TagsTagId" },
                values: new object[] { 2, 2 });
            migrationBuilder.InsertData(
                table: "ProductTag",
                columns: new[] { "ProductsProductId", "TagsTagId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "LineItemId", "NumOfProducts", "OrderId", "ProductId", "ProductPrice" },
                values: new object[] { 1, (short)3, 1, 1, 100m });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "LineItemId", "NumOfProducts", "OrderId", "ProductId", "ProductPrice" },
                values: new object[] { 2, (short)2, 2, 2, 200m });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "LineItemId", "NumOfProducts", "OrderId", "ProductId", "ProductPrice" },
                values: new object[] { 3, (short)1, 3, 3, 300m });


            // For Views
            var priceOfferViewQuery = @"SELECT NewPrice, PromotinalText, Name as ProductName
                                        FROM dbo.PriceOffers po
                                        LEFT JOIN dbo.Products p on p.ProductId = po.ProductId";

            migrationBuilder.AddViewViaSql<PriceOfferView>("PriceOfferView", priceOfferViewQuery);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LineItems",
                keyColumn: "LineItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LineItems",
                keyColumn: "LineItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LineItems",
                keyColumn: "LineItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PriceOffers",
                keyColumn: "PriceOfferId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PriceOffers",
                keyColumn: "PriceOfferId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PriceOffers",
                keyColumn: "PriceOfferId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 3);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Clients",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
