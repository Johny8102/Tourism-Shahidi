using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_project_2.Migrations
{
    /// <inheritdoc />
    public partial class CommentFK2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "commentId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_comment",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "fk_comment",
                table: "Comments");
        }
    }
}
