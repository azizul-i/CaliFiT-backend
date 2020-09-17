using Microsoft.EntityFrameworkCore.Migrations;

namespace CaliFiTAPI.Migrations
{
    public partial class AddedDecripto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Workout",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Excercise",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Excercise",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Excercise");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Excercise");
        }
    }
}
