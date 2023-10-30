using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShreyaGramBackend.Migrations
{
    /// <inheritdoc />
    public partial class updatecarrtid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailsCart_CartTest_CartId",
                table: "ProductDetailsCart");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetailsCart_CartId",
                table: "ProductDetailsCart");

            migrationBuilder.AlterColumn<string>(
                name: "CartId",
                table: "ProductDetailsCart",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CartId1",
                table: "ProductDetailsCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailsCart_CartId1",
                table: "ProductDetailsCart",
                column: "CartId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailsCart_CartTest_CartId1",
                table: "ProductDetailsCart",
                column: "CartId1",
                principalTable: "CartTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailsCart_CartTest_CartId1",
                table: "ProductDetailsCart");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetailsCart_CartId1",
                table: "ProductDetailsCart");

            migrationBuilder.DropColumn(
                name: "CartId1",
                table: "ProductDetailsCart");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "ProductDetailsCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailsCart_CartId",
                table: "ProductDetailsCart",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailsCart_CartTest_CartId",
                table: "ProductDetailsCart",
                column: "CartId",
                principalTable: "CartTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
