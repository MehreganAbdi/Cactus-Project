using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CactusDomain.Migrations
{
    /// <inheritdoc />
    public partial class MethodForSizeCount3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeCountId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SizeAndCounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SizeAndCounts");

            migrationBuilder.AddColumn<string>(
                name: "SizeCountId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
