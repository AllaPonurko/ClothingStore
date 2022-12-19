using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothingStore.Data.Migrations
{
    public partial class Color : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyColorId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_MyColorId",
                table: "Colors",
                column: "MyColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Colors_MyColorId",
                table: "Colors",
                column: "MyColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Colors_MyColorId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_MyColorId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "MyColorId",
                table: "Colors");
        }
    }
}
