﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class initMigrationAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Elektronik och tekniska produkter", "Electronics" },
                    { 2, "Produkter för hemmet och köket", "Home & Kitchen" },
                    { 3, "Kläder och accessoarer", "Clothing" },
                    { 4, "Sportutrustning och träningsprodukter", "Sports" },
                    { 5, "Böcker och litteratur", "Books" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Storgatan 1, Stockholm", "anders@example.com", "Anders Svensson", 701112233 },
                    { 2, "Kungsgatan 15, Göteborg", "emma@example.com", "Emma Johansson", 732223344 },
                    { 3, "Drottninggatan 8, Malmö", "lars@example.com", "Lars Nilsson", 763334455 },
                    { 4, "Sveavägen 22, Uppsala", "sofia@example.com", "Sofia Lindgren", 724445566 },
                    { 5, "Järntorget 5, Göteborg", "peter@example.com", "Peter Karlsson", 705556677 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "ContactPerson", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Anna Lindberg", "anna@techvision.se", "TechVision AB", 701234567 },
                    { 2, "Johan Bergman", "johan@homestyle.se", "HomeStyle", 732345678 },
                    { 3, "Maria Ek", "maria@fashionfirst.se", "Fashion First", 763456789 },
                    { 4, "Erik Strand", "erik@sportmax.se", "SportMax", 724567890 },
                    { 5, "Karl Holm", "karl@nordicelec.se", "Nordic Electronics", 705678901 },
                    { 6, "Lisa Björk", "lisa@globalgadgets.se", "Global Gadgets", 736789012 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11999 },
                    { 2, 2, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9798 },
                    { 3, 3, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18999 },
                    { 4, 4, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3499 },
                    { 5, 5, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 16994 },
                    { 6, 1, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 899 },
                    { 7, 3, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2498 },
                    { 8, 2, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1598 },
                    { 9, 4, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5794 },
                    { 10, 5, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1299 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "StockQuantity", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1, "Smartphone med 128GB lagring", "iPhone 13 Pro", 11999, 15, 1 },
                    { 2, 1, "4K Smart TV med HDR", "Samsung TV 55\"", 8999, 8, 5 },
                    { 3, 1, "Trådlösa hörlurar med brusreducering", "Sony WH-1000XM4", 3499, 7, 5 },
                    { 4, 1, "Laptop med M1-chip och 8GB RAM", "MacBook Air", 12499, 12, 1 },
                    { 5, 2, "Automatisk espressomaskin", "Espressomaskin", 4995, 6, 2 },
                    { 6, 2, "Multifunktionell köksmaskin", "Matberedare", 1299, 20, 2 },
                    { 7, 3, "Varm jacka för vinterbruk", "Vinterjacka", 1999, 25, 3 },
                    { 8, 4, "Skor för långdistanslöpning", "Löparskor", 1499, 18, 4 },
                    { 9, 4, "Halkfri yogamatta", "Yogamatta", 349, 30, 4 },
                    { 10, 5, "Populär skönlitterär roman", "Bestsellerroman", 249, 40, 2 },
                    { 11, 1, "Högpresterande dator för gaming", "Gaming PC", 18999, 5, 6 },
                    { 12, 1, "10\" surfplatta med WiFi", "Tablet", 4299, 9, 5 },
                    { 13, 1, "Portabel högtalare med 20h batteritid", "Bluetooth-högtalare", 899, 22, 6 },
                    { 14, 2, "Programmerbar kaffebryggare", "Kaffebryggare", 799, 14, 2 },
                    { 15, 3, "Funktionströja för träning", "Träningströja", 499, 35, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 11999 },
                    { 2, 2, 3, 2, 3499 },
                    { 3, 2, 13, 3, 899 },
                    { 4, 3, 11, 1, 18999 },
                    { 5, 4, 3, 1, 3499 },
                    { 6, 5, 4, 1, 12499 },
                    { 7, 5, 5, 1, 4495 },
                    { 8, 6, 13, 1, 899 },
                    { 9, 7, 8, 1, 1499 },
                    { 10, 7, 9, 3, 349 },
                    { 11, 8, 7, 1, 1999 },
                    { 12, 8, 15, 3, 499 },
                    { 13, 9, 2, 1, 8999 },
                    { 14, 9, 6, 1, 1299 },
                    { 15, 9, 14, 2, 799 },
                    { 16, 10, 6, 1, 1299 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
