using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DBInitFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DocumetType");

            migrationBuilder.DropColumn(
                name: "NextShowMin",
                table: "Card");

            migrationBuilder.AlterColumn<string>(
                name: "OriginalAuthorId",
                table: "Question",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Group",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "DocumetType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Comment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Card",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_OriginalAuthorId",
                table: "Question",
                column: "OriginalAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_OriginalAuthorId",
                table: "Question",
                column: "OriginalAuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_OriginalAuthorId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_OriginalAuthorId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DocumetType");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Card");

            migrationBuilder.AlterColumn<string>(
                name: "OriginalAuthorId",
                table: "Question",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DocumetType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextShowMin",
                table: "Card",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
