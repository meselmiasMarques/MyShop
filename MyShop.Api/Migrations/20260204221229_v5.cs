using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AM7_Product",
                table: "AM7_Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AM7_Category",
                table: "AM7_Category");

            migrationBuilder.RenameTable(
                name: "AM7_Product",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "AM7_Category",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_AM7_Product_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "AM7_Product");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "AM7_Category");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "AM7_Product",
                newName: "IX_AM7_Product_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AM7_Product",
                table: "AM7_Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AM7_Category",
                table: "AM7_Category",
                column: "Id");
        }
    }
}
