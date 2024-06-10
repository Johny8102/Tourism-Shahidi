using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_project_2.Migrations
{
    /// <inheritdoc />
    public partial class Commenttime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_commentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_commentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "commentId",
                table: "Comments");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "commentId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_commentId",
                table: "Comments",
                column: "commentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_commentId",
                table: "Comments",
                column: "commentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
