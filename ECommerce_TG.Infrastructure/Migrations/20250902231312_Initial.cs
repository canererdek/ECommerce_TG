using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TG_Ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
            
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "CreatedAt", "UpdatedAt", "DeletedAt" },
                values: new object[,]
                {
                    { 1, "Electronics", DateTime.UtcNow, null, null },
                    { 2, "Books", DateTime.UtcNow, null, null },
                    { 3, "Clothing", DateTime.UtcNow, null, null }
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Stock", "CategoryId", "CreatedAt", "UpdatedAt", "DeletedAt" },
                values: new object[,]
                {
                    { 1, "Laptop", 7500.00m, 10, 1, DateTime.UtcNow, null, null },
                    { 2, "Smartphone", 3500.00m, 20, 1, DateTime.UtcNow, null, null },
                    { 3, "Novel Book", 120.50m, 50, 2, DateTime.UtcNow, null, null },
                    { 4, "T-Shirt", 75.00m, 100, 3, DateTime.UtcNow, null, null },
                    { 5, "Jeans", 150.00m, 60, 3, DateTime.UtcNow, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
