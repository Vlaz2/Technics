using Microsoft.EntityFrameworkCore.Migrations;

namespace Technics.com.Migrations
{
    public partial class ChangeOptionOnProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewComment",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewComment",
                table: "Products",
                maxLength: 300,
                nullable: true);
        }
    }
}
