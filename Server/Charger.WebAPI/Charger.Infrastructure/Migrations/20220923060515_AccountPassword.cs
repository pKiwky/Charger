using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charger.Infrastructure.Migrations
{
    public partial class AccountPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "password",
                table: "Accounts",
                type: "longblob",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte[]>(
                name: "password_key",
                table: "Accounts",
                type: "longblob",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_key",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Accounts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
