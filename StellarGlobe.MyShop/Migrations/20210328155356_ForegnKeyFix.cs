using Microsoft.EntityFrameworkCore.Migrations;

namespace StellarGlobe.MyShop.Migrations
{
    public partial class ForegnKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Shops",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "shopId",
                table: "Products",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopId",
                table: "Products",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShopId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shops",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Products",
                newName: "shopId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ProductId",
                table: "Products",
                column: "ProductId",
                principalTable: "Shops",
                principalColumn: "ShopId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
