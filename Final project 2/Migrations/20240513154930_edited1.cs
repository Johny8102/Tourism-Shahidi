using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_project_2.Migrations
{
    /// <inheritdoc />
    public partial class edited1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Context",
                table: "Comments",
                newName: "Text");

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image5",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image_bg",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Is_Acive",
                table: "Tour",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Quality_level",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status_limit",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Touring_area",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Reserved_Count",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City_And_Country",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Favorit_food",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Favorit_sport",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Is_Admin",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Joined_at",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telegram",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Active_Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_Tour = table.Column<int>(type: "int", nullable: false),
                    Start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Active_Tours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_Tour = table.Column<int>(type: "int", nullable: false),
                    Image_Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Active_Tours");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Image5",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Image_bg",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Is_Acive",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Quality_level",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Status_limit",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Touring_area",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Reserved_Count",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "City_And_Country",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Favorit_food",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Favorit_sport",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Is_Admin",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Joined_at",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Telegram",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Comments",
                newName: "Context");
        }
    }
}
