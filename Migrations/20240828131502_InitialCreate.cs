using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    QuantityAvailable = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "integer", nullable: false),
                    ProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Household Essentials" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "OrderDate", "Status", "Total", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2001), false, 749.98m, 1 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 299.99m, 1, 1 },
                    { 2, 1, 200.00m, 2, 1 },
                    { 3, 1, 40.00m, 3, 2 },
                    { 4, 1, 105.00m, 5, 10 },
                    { 5, 1, 50.00m, 6, 5 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "QuantityAvailable", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Ultra HD 4K Smart TV with HDR.", "https://m.media-amazon.com/images/I/91Hk42lTFaL.jpg", "4K Smart TV", 299.99m, 15, 1 },
                    { 2, 1, "Over-ear headphones with noise cancellation.", "https://media.musicarts.com/is/image/MMGS7/M07377000000000-00-720x720.jpg", "Noise-Canceling Headphones", 199.99m, 30, 1 },
                    { 3, 1, "Latest model smartphone with high resolution camera.", "https://image-us.samsung.com/us/smartphones/galaxy-s24/all-gallery/01_E3_TitaniumBlack_Lockup_1600x1200.jpg?$product-details-jpg$", "Smartphone", 499.99m, 20, 2 },
                    { 4, 1, "Next-generation gaming console with 4K support.", "https://m.media-amazon.com/images/I/71HESRbyxDL.jpg", "Gaming Console", 399.99m, 10, 2 },
                    { 5, 2, "Genuine leather jacket with a classic design.", "https://gearmoose.com/wp-content/uploads/2019/05/filson-leather-short-cruiser-jacket.jpg", "Leather Jacket", 200.00m, 5, 3 },
                    { 6, 2, "Comfortable 100% cotton T-shirt.", "https://cdn11.bigcommerce.com/s-lk0gwzb/images/stencil/1280x1280/products/1645/9513/athleticheather-front__83530__24374_8135__17315.1708459759.jpg?c=2", "Cotton T-shirt", 20.00m, 50, 3 },
                    { 7, 2, "Stylish and durable denim jeans.", "https://i.etsystatic.com/11147089/r/il/4bc917/3294441088/il_570xN.3294441088_dx4j.jpg", "Denim Jeans", 40.00m, 25, 4 },
                    { 8, 2, "Lightweight running shoes with excellent grip.", "https://cdn.thewirecutter.com/wp-content/media/2023/09/running-shoes-2048px-5946.jpg?auto=webp&quality=75&width=1024", "Running Shoes", 79.99m, 40, 4 },
                    { 9, 3, "Effective dish soap for grease removal.", "https://images.thdstatic.com/productImages/c08b33d2-32a5-449a-b0a8-25425d3729b5/svn/dawn-dish-soap-003077209398-fa_600.jpg", "Dish Soap", 10.50m, 100, 1 },
                    { 10, 3, "Highly absorbent paper towels.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkW2hEVTJ5yu4V7h1Toy3MA2lZNovOFnz3Sw&s", "Paper Towels", 5.00m, 80, 1 },
                    { 11, 3, "High-efficiency laundry detergent.", "https://images.thdstatic.com/productImages/d31d06e3-b0d3-4edb-a4c0-b599ec2e4de2/svn/gain-laundry-detergents-003700077196-64_600.jpg", "Laundry Detergent", 12.00m, 60, 2 },
                    { 12, 3, "Multi-surface cleaning spray.", "https://images.thdstatic.com/productImages/e5c920e1-3d7c-431f-ad73-048e3070d5da/svn/simple-green-all-purpose-cleaners-2710001213033-64_1000.jpg", "Cleaning Spray", 7.50m, 70, 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Role" },
                values: new object[,]
                {
                    { 1, "alice.smith@example.com", "Alice", "Smith", true },
                    { 2, "bob.johnson@example.com", "Bob", "Johnson", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
