﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CactusDomain.Migrations
{
    /// <inheritdoc />
    public partial class OffAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Off",
                table: "Products",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Off",
                table: "Products");
        }
    }
}
