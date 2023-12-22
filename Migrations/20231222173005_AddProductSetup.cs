using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AfroBeachApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProductSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMediaType");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image1 = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Image2 = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Image3 = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Image4 = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Image5 = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Image6 = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialGalleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductCategoryID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShortDescription = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Image1 = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Image2 = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Image3 = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Image4 = table.Column<byte[]>(type: "BLOB", nullable: true),
                    CurrencyOneID = table.Column<int>(type: "INTEGER", nullable: true),
                    CurrencyOneAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CurrencyTwoID = table.Column<int>(type: "INTEGER", nullable: true),
                    CurrencyTwoAmount = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Currencies_CurrencyOneID",
                        column: x => x.CurrencyOneID,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Currencies_CurrencyTwoID",
                        column: x => x.CurrencyTwoID,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrencyOneID",
                table: "Products",
                column: "CurrencyOneID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrencyTwoID",
                table: "Products",
                column: "CurrencyTwoID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryID",
                table: "Products",
                column: "ProductCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SocialGalleries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "SocialMediaType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IconName = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SocialMediaType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IconName", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "system", new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5132), null, null, "bi bi-facebook", false, "system", new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5151), "Facebook" },
                    { 2, "system", new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5154), null, null, "bi bi-twitter", false, "system", new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5156), "Twitter" },
                    { 3, "system", new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5158), null, null, "bi bi-instagram", false, "system", new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5159), "Instagram" },
                    { 4, "system", new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5162), null, null, "bi bi-linkedin", false, "system", new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5164), "LinkedIn" }
                });
        }
    }
}
