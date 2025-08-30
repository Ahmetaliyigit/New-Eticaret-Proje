using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Delet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_ColorId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ColorId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ColorId1",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_ColorId",
                table: "Products",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_ColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ColorId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ColorId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ColorId1",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId1",
                table: "Products",
                column: "ColorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_ColorId1",
                table: "Products",
                column: "ColorId1",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
