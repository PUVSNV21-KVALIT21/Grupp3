using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hakims_Livs.Data.Migrations
{
    public partial class abc123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quantity_OrderId",
                table: "Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_Quantity_OrderId",
                table: "Quantity",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quantity_OrderId",
                table: "Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_Quantity_OrderId",
                table: "Quantity",
                column: "OrderId",
                unique: true);
        }
    }
}
