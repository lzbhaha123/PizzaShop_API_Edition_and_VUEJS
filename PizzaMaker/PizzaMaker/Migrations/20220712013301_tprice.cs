using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaker.Migrations
{
    public partial class tprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Topping",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Topping");
        }
    }
}
