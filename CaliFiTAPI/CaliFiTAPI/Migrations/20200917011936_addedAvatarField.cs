using Microsoft.EntityFrameworkCore.Migrations;

namespace CaliFiTAPI.Migrations
{
    public partial class addedAvatarField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarURL",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarURL",
                table: "User");
        }
    }
}
