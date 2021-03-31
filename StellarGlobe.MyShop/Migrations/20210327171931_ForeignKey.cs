using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StellarGlobe.MyShop.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "shopId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "shopId",
                table: "Products");
        }
    }
}
