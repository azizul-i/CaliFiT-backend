using Microsoft.EntityFrameworkCore.Migrations;

namespace CaliFiTAPI.Migrations
{
    public partial class AddedFacebookField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacebookID",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookID",
                table: "User");
        }
    }
}
