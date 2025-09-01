using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Carts_CartsId",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Products_ProductsId",
                table: "CartProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct");

            migrationBuilder.RenameTable(
                name: "CartProduct",
                newName: "CartProducts");

            migrationBuilder.RenameIndex(
                name: "IX_CartProduct_ProductsId",
                table: "CartProducts",
                newName: "IX_CartProducts_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProducts",
                table: "CartProducts",
                columns: new[] { "CartsId", "ProductsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Carts_CartsId",
                table: "CartProducts",
                column: "CartsId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Products_ProductsId",
                table: "CartProducts",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Carts_CartsId",
                table: "CartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Products_ProductsId",
                table: "CartProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProducts",
                table: "CartProducts");

            migrationBuilder.RenameTable(
                name: "CartProducts",
                newName: "CartProduct");

            migrationBuilder.RenameIndex(
                name: "IX_CartProducts_ProductsId",
                table: "CartProduct",
                newName: "IX_CartProduct_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct",
                columns: new[] { "CartsId", "ProductsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Carts_CartsId",
                table: "CartProduct",
                column: "CartsId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Products_ProductsId",
                table: "CartProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
