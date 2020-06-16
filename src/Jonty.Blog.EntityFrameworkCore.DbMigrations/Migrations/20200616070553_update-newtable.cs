using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jonty.Blog.Migrations
{
    public partial class updatenewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jonty_HotNews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Url = table.Column<string>(maxLength: 250, nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jonty_HotNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jonty_Wallpapers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jonty_Wallpapers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jonty_HotNews");

            migrationBuilder.DropTable(
                name: "jonty_Wallpapers");
        }
    }
}
