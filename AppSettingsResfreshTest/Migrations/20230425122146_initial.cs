using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSettingsResfreshTest.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "VARCHAR(200)", maxLength: 500, nullable: true),
                    SK1 = table.Column<string>(type: "NVARCHAR(1000)", nullable: true),
                    SK2 = table.Column<string>(type: "NVARCHAR(1000)", nullable: true),
                    SK3 = table.Column<string>(type: "NVARCHAR(1000)", nullable: true),
                    SK4 = table.Column<string>(type: "NVARCHAR(1000)", nullable: true),
                    SK5 = table.Column<string>(type: "NVARCHAR(1000)", nullable: true),
                    SK20 = table.Column<DateTime>(nullable: false),
                    SK21 = table.Column<DateTime>(nullable: false),
                    SK22 = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_PK",
                table: "Items",
                column: "PK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
