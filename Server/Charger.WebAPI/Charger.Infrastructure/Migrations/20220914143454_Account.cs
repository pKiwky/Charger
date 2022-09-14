using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charger.Infrastructure.Migrations
{
    public partial class Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Stations",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Stations",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Stations",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Stations",
                newName: "city");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "Stations",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Stations",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Stations",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Stations",
                newName: "City");
        }
    }
}
