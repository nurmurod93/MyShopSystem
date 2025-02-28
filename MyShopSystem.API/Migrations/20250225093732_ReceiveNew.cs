using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShopSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class ReceiveNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "Receives",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Receives",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Receives");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Receives");
        }
    }
}
