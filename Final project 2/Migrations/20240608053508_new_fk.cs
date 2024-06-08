using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_project_2.Migrations
{
    /// <inheritdoc />
    public partial class new_fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Active_Tours_Tour_TourId",
                table: "Active_Tours");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Person_PersonId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tour_TourId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Tour_TourId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Active_Tours_Active_TourId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Person_PersonId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Reservations",
                newName: "fk_Person");

            migrationBuilder.RenameColumn(
                name: "Active_TourId",
                table: "Reservations",
                newName: "fk_Active_Tour");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PersonId",
                table: "Reservations",
                newName: "IX_Reservations_fk_Person");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_Active_TourId",
                table: "Reservations",
                newName: "IX_Reservations_fk_Active_Tour");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "Images",
                newName: "fk_Tour");

            migrationBuilder.RenameIndex(
                name: "IX_Images_TourId",
                table: "Images",
                newName: "IX_Images_fk_Tour");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "Comments",
                newName: "fk_Tour");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Comments",
                newName: "fk_Person");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TourId",
                table: "Comments",
                newName: "IX_Comments_fk_Tour");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PersonId",
                table: "Comments",
                newName: "IX_Comments_fk_Person");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "Active_Tours",
                newName: "fk_Tour");

            migrationBuilder.RenameIndex(
                name: "IX_Active_Tours_TourId",
                table: "Active_Tours",
                newName: "IX_Active_Tours_fk_Tour");

            migrationBuilder.AddForeignKey(
                name: "FK_Active_Tours_Tour_fk_Tour",
                table: "Active_Tours",
                column: "fk_Tour",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Person_fk_Person",
                table: "Comments",
                column: "fk_Person",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tour_fk_Tour",
                table: "Comments",
                column: "fk_Tour",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Tour_fk_Tour",
                table: "Images",
                column: "fk_Tour",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Active_Tours_fk_Active_Tour",
                table: "Reservations",
                column: "fk_Active_Tour",
                principalTable: "Active_Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Person_fk_Person",
                table: "Reservations",
                column: "fk_Person",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Active_Tours_Tour_fk_Tour",
                table: "Active_Tours");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Person_fk_Person",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tour_fk_Tour",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Tour_fk_Tour",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Active_Tours_fk_Active_Tour",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Person_fk_Person",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "fk_Person",
                table: "Reservations",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "fk_Active_Tour",
                table: "Reservations",
                newName: "Active_TourId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_fk_Person",
                table: "Reservations",
                newName: "IX_Reservations_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_fk_Active_Tour",
                table: "Reservations",
                newName: "IX_Reservations_Active_TourId");

            migrationBuilder.RenameColumn(
                name: "fk_Tour",
                table: "Images",
                newName: "TourId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_fk_Tour",
                table: "Images",
                newName: "IX_Images_TourId");

            migrationBuilder.RenameColumn(
                name: "fk_Tour",
                table: "Comments",
                newName: "TourId");

            migrationBuilder.RenameColumn(
                name: "fk_Person",
                table: "Comments",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_fk_Tour",
                table: "Comments",
                newName: "IX_Comments_TourId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_fk_Person",
                table: "Comments",
                newName: "IX_Comments_PersonId");

            migrationBuilder.RenameColumn(
                name: "fk_Tour",
                table: "Active_Tours",
                newName: "TourId");

            migrationBuilder.RenameIndex(
                name: "IX_Active_Tours_fk_Tour",
                table: "Active_Tours",
                newName: "IX_Active_Tours_TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Active_Tours_Tour_TourId",
                table: "Active_Tours",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Person_PersonId",
                table: "Comments",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tour_TourId",
                table: "Comments",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Tour_TourId",
                table: "Images",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Active_Tours_Active_TourId",
                table: "Reservations",
                column: "Active_TourId",
                principalTable: "Active_Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Person_PersonId",
                table: "Reservations",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
