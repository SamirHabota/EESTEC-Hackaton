using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class QuestionPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "QuestionPoints",
                table: "Test",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionPoints",
                table: "Test");
        }
    }
}
