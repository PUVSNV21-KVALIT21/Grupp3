using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hakims_Livs.Data.Migrations
{
    public partial class AddedCategoryDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Products",
                newName: "CategoryNameID");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryNameID",
                table: "Products",
                column: "CategoryNameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryNameID",
                table: "Products",
                column: "CategoryNameID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryNameID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryNameID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryNameID",
                table: "Products",
                newName: "Category");
        }
    }
}
