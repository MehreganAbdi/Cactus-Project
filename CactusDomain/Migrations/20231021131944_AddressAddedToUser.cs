using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CactusDomain.Migrations
{
    /// <inheritdoc />
    public partial class AddressAddedToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId1",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId1",
                table: "AspNetUsers",
                column: "AddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId1",
                table: "AspNetUsers",
                column: "AddressId1",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressId1",
                table: "AspNetUsers");
        }
    }
}
