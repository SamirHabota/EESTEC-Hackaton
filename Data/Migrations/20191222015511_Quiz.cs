using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Quiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdinalNumber",
                table: "TestQuestion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isCorrect",
                table: "TestQuestion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "currentOrdinalNumber",
                table: "Test",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isFinished",
                table: "Test",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrdinalNumber",
                table: "TestQuestion");

            migrationBuilder.DropColumn(
                name: "isCorrect",
                table: "TestQuestion");

            migrationBuilder.DropColumn(
                name: "currentOrdinalNumber",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "isFinished",
                table: "Test");
        }
    }
}
