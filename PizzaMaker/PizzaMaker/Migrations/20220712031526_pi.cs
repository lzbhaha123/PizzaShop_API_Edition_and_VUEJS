﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaker.Migrations
{
    public partial class pi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Pizza",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Pizza");
        }
    }
}
