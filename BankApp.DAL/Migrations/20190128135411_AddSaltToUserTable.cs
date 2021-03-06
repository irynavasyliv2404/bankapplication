﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.DAL.Migrations
{
    public partial class AddSaltToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SaltBytes",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaltBytes",
                table: "Users");
        }
    }
}
