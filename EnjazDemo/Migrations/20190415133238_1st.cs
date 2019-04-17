using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnjazDemo.Migrations
{
    public partial class _1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    fullName = table.Column<string>(nullable: true),
                    nationIdentity = table.Column<string>(nullable: true),
                    carNumber = table.Column<string>(nullable: true),
                    carEnglishChar = table.Column<string>(nullable: true),
                    carArabicChar = table.Column<string>(nullable: true),
                    drivingLicenseNumber = table.Column<string>(nullable: true),
                    attachmentUrl = table.Column<string>(nullable: true),
                    fileUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "UserModels");
        }
    }
}
