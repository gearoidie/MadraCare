using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MadraCare.Services.Kennel.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kennels",
                columns: table => new
                {
                    KennelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kennels", x => x.KennelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kennels");
        }
    }
}
