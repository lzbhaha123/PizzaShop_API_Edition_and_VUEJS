using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaker.Migrations
{
    public partial class tp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "ToppingPizza",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PizzaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ToppingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ToppingSize = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToppingPizza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToppingPizza_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToppingPizza_Topping_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Topping",
                        principalColumn: "ToppingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToppingPizza_PizzaId",
                table: "ToppingPizza",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_ToppingPizza_ToppingId",
                table: "ToppingPizza",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToppingPizza");

            migrationBuilder.DropTable(
                name: "Pizza");
        }
    }
}
