using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientMangement.Migrations
{
    public partial class Client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    LicenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceKeyGUID = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LicenceStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenceEndtDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.LicenceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
