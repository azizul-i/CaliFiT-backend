using Microsoft.EntityFrameworkCore.Migrations;

namespace CaliFiTAPI.Migrations
{
    public partial class typeToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExcerciseType",
                table: "Excercise");

            migrationBuilder.AddColumn<string>(
                name: "ExcerciseName",
                table: "Excercise",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExcerciseName",
                table: "Excercise");

            migrationBuilder.AddColumn<string>(
                name: "ExcerciseType",
                table: "Excercise",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
