using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hakims_Livs.Data.Migrations
{
    public partial class quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Quantity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quantity_OrderId",
                table: "Quantity",
                column: "OrderId",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Quantity_Orders_OrderId",
                table: "Quantity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quantity_Orders_OrderId",
                table: "Quantity");

            migrationBuilder.DropIndex(
                name: "IX_Quantity_OrderId",
                table: "Quantity");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Quantity");
        }
    }
}
