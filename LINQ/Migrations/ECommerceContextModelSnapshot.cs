﻿// <auto-generated />
using System;
using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerceApp.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    partial class ECommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerceApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Elektronik och tekniska produkter",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Produkter för hemmet och köket",
                            Name = "Home & Kitchen"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Kläder och accessoarer",
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Sportutrustning och träningsprodukter",
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Böcker och litteratur",
                            Name = "Books"
                        });
                });

            modelBuilder.Entity("ECommerceApp.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Storgatan 1, Stockholm",
                            Email = "anders@example.com",
                            Name = "Anders Svensson",
                            Phone = 701112233
                        },
                        new
                        {
                            Id = 2,
                            Address = "Kungsgatan 15, Göteborg",
                            Email = "emma@example.com",
                            Name = "Emma Johansson",
                            Phone = 732223344
                        },
                        new
                        {
                            Id = 3,
                            Address = "Drottninggatan 8, Malmö",
                            Email = "lars@example.com",
                            Name = "Lars Nilsson",
                            Phone = 763334455
                        },
                        new
                        {
                            Id = 4,
                            Address = "Sveavägen 22, Uppsala",
                            Email = "sofia@example.com",
                            Name = "Sofia Lindgren",
                            Phone = 724445566
                        },
                        new
                        {
                            Id = 5,
                            Address = "Järntorget 5, Göteborg",
                            Email = "peter@example.com",
                            Name = "Peter Karlsson",
                            Phone = 705556677
                        });
                });

            modelBuilder.Entity("ECommerceApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            OrderDate = new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            TotalAmount = 11999
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            OrderDate = new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            TotalAmount = 9798
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            OrderDate = new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = false,
                            TotalAmount = 18999
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 4,
                            OrderDate = new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            TotalAmount = 3499
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 5,
                            OrderDate = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = false,
                            TotalAmount = 16994
                        },
                        new
                        {
                            Id = 6,
                            CustomerId = 1,
                            OrderDate = new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            TotalAmount = 899
                        },
                        new
                        {
                            Id = 7,
                            CustomerId = 3,
                            OrderDate = new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            TotalAmount = 2498
                        },
                        new
                        {
                            Id = 8,
                            CustomerId = 2,
                            OrderDate = new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = false,
                            TotalAmount = 1598
                        },
                        new
                        {
                            Id = 9,
                            CustomerId = 4,
                            OrderDate = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = false,
                            TotalAmount = 5794
                        },
                        new
                        {
                            Id = 10,
                            CustomerId = 5,
                            OrderDate = new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = false,
                            TotalAmount = 1299
                        });
                });

            modelBuilder.Entity("ECommerceApp.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1,
                            UnitPrice = 11999
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 2,
                            ProductId = 3,
                            Quantity = 2,
                            UnitPrice = 3499
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            ProductId = 13,
                            Quantity = 3,
                            UnitPrice = 899
                        },
                        new
                        {
                            Id = 4,
                            OrderId = 3,
                            ProductId = 11,
                            Quantity = 1,
                            UnitPrice = 18999
                        },
                        new
                        {
                            Id = 5,
                            OrderId = 4,
                            ProductId = 3,
                            Quantity = 1,
                            UnitPrice = 3499
                        },
                        new
                        {
                            Id = 6,
                            OrderId = 5,
                            ProductId = 4,
                            Quantity = 1,
                            UnitPrice = 12499
                        },
                        new
                        {
                            Id = 7,
                            OrderId = 5,
                            ProductId = 5,
                            Quantity = 1,
                            UnitPrice = 4495
                        },
                        new
                        {
                            Id = 8,
                            OrderId = 6,
                            ProductId = 13,
                            Quantity = 1,
                            UnitPrice = 899
                        },
                        new
                        {
                            Id = 9,
                            OrderId = 7,
                            ProductId = 8,
                            Quantity = 1,
                            UnitPrice = 1499
                        },
                        new
                        {
                            Id = 10,
                            OrderId = 7,
                            ProductId = 9,
                            Quantity = 3,
                            UnitPrice = 349
                        },
                        new
                        {
                            Id = 11,
                            OrderId = 8,
                            ProductId = 7,
                            Quantity = 1,
                            UnitPrice = 1999
                        },
                        new
                        {
                            Id = 12,
                            OrderId = 8,
                            ProductId = 15,
                            Quantity = 3,
                            UnitPrice = 499
                        },
                        new
                        {
                            Id = 13,
                            OrderId = 9,
                            ProductId = 2,
                            Quantity = 1,
                            UnitPrice = 8999
                        },
                        new
                        {
                            Id = 14,
                            OrderId = 9,
                            ProductId = 6,
                            Quantity = 1,
                            UnitPrice = 1299
                        },
                        new
                        {
                            Id = 15,
                            OrderId = 9,
                            ProductId = 14,
                            Quantity = 2,
                            UnitPrice = 799
                        },
                        new
                        {
                            Id = 16,
                            OrderId = 10,
                            ProductId = 6,
                            Quantity = 1,
                            UnitPrice = 1299
                        });
                });

            modelBuilder.Entity("ECommerceApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Smartphone med 128GB lagring",
                            Name = "iPhone 13 Pro",
                            Price = 11999,
                            StockQuantity = 15,
                            SupplierId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "4K Smart TV med HDR",
                            Name = "Samsung TV 55\"",
                            Price = 8999,
                            StockQuantity = 8,
                            SupplierId = 5
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Trådlösa hörlurar med brusreducering",
                            Name = "Sony WH-1000XM4",
                            Price = 3499,
                            StockQuantity = 7,
                            SupplierId = 5
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "Laptop med M1-chip och 8GB RAM",
                            Name = "MacBook Air",
                            Price = 12499,
                            StockQuantity = 12,
                            SupplierId = 1
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Automatisk espressomaskin",
                            Name = "Espressomaskin",
                            Price = 4995,
                            StockQuantity = 6,
                            SupplierId = 2
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Multifunktionell köksmaskin",
                            Name = "Matberedare",
                            Price = 1299,
                            StockQuantity = 20,
                            SupplierId = 2
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "Varm jacka för vinterbruk",
                            Name = "Vinterjacka",
                            Price = 1999,
                            StockQuantity = 25,
                            SupplierId = 3
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 4,
                            Description = "Skor för långdistanslöpning",
                            Name = "Löparskor",
                            Price = 1499,
                            StockQuantity = 18,
                            SupplierId = 4
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 4,
                            Description = "Halkfri yogamatta",
                            Name = "Yogamatta",
                            Price = 349,
                            StockQuantity = 30,
                            SupplierId = 4
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 5,
                            Description = "Populär skönlitterär roman",
                            Name = "Bestsellerroman",
                            Price = 249,
                            StockQuantity = 40,
                            SupplierId = 2
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 1,
                            Description = "Högpresterande dator för gaming",
                            Name = "Gaming PC",
                            Price = 18999,
                            StockQuantity = 5,
                            SupplierId = 6
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            Description = "10\" surfplatta med WiFi",
                            Name = "Tablet",
                            Price = 4299,
                            StockQuantity = 9,
                            SupplierId = 5
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 1,
                            Description = "Portabel högtalare med 20h batteritid",
                            Name = "Bluetooth-högtalare",
                            Price = 899,
                            StockQuantity = 22,
                            SupplierId = 6
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            Description = "Programmerbar kaffebryggare",
                            Name = "Kaffebryggare",
                            Price = 799,
                            StockQuantity = 14,
                            SupplierId = 2
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            Description = "Funktionströja för träning",
                            Name = "Träningströja",
                            Price = 499,
                            StockQuantity = 35,
                            SupplierId = 3
                        });
                });

            modelBuilder.Entity("ECommerceApp.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactPerson = "Anna Lindberg",
                            Email = "anna@techvision.se",
                            Name = "TechVision AB",
                            Phone = 701234567
                        },
                        new
                        {
                            Id = 2,
                            ContactPerson = "Johan Bergman",
                            Email = "johan@homestyle.se",
                            Name = "HomeStyle",
                            Phone = 732345678
                        },
                        new
                        {
                            Id = 3,
                            ContactPerson = "Maria Ek",
                            Email = "maria@fashionfirst.se",
                            Name = "Fashion First",
                            Phone = 763456789
                        },
                        new
                        {
                            Id = 4,
                            ContactPerson = "Erik Strand",
                            Email = "erik@sportmax.se",
                            Name = "SportMax",
                            Phone = 724567890
                        },
                        new
                        {
                            Id = 5,
                            ContactPerson = "Karl Holm",
                            Email = "karl@nordicelec.se",
                            Name = "Nordic Electronics",
                            Phone = 705678901
                        },
                        new
                        {
                            Id = 6,
                            ContactPerson = "Lisa Björk",
                            Email = "lisa@globalgadgets.se",
                            Name = "Global Gadgets",
                            Phone = 736789012
                        });
                });

            modelBuilder.Entity("ECommerceApp.Models.Order", b =>
                {
                    b.HasOne("ECommerceApp.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ECommerceApp.Models.OrderDetail", b =>
                {
                    b.HasOne("ECommerceApp.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceApp.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerceApp.Models.Product", b =>
                {
                    b.HasOne("ECommerceApp.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceApp.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ECommerceApp.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerceApp.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ECommerceApp.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ECommerceApp.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ECommerceApp.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
