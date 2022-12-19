using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothingStore.Data.Migrations
{
    public partial class AddTextile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TextileId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Textile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Textile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TextileId",
                table: "Products",
                column: "TextileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Textile_TextileId",
                table: "Products",
                column: "TextileId",
                principalTable: "Textile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Textile_TextileId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Textile");

            migrationBuilder.DropIndex(
                name: "IX_Products_TextileId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TextileId",
                table: "Products");
        }
    }
}
