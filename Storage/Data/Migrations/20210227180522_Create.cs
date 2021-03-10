using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Storage.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Energy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coffees");
        }
    }
}
