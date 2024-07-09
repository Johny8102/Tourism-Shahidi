using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_project_2.Migrations
{
    /// <inheritdoc />
    public partial class newFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Admin = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Joined_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City_And_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Favorit_food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Favorit_sport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Actived = table.Column<bool>(type: "bit", nullable: false),
                    Telegram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tour_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price_per_person = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Acive = table.Column<bool>(type: "bit", nullable: false),
                    Quality_level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_limit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image_bg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Touring_area = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Active_Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_Tour = table.Column<int>(type: "int", nullable: false),
                    Start_time = table.Column<DateOnly>(type: "date", nullable: false),
                    End_time = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Active_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Active_Tours_Tour_fk_Tour",
                        column: x => x.fk_Tour,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Actived = table.Column<bool>(type: "bit", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fk_comment = table.Column<int>(type: "int", nullable: true),
                    fk_Tour = table.Column<int>(type: "int", nullable: false),
                    fk_Person = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Person_fk_Person",
                        column: x => x.fk_Person,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Tour_fk_Tour",
                        column: x => x.fk_Tour,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Images_Tour_fk_Tour",
                        column: x => x.fk_Tour,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Actived = table.Column<bool>(type: "bit", nullable: false),
                    Reserved_Count = table.Column<int>(type: "int", nullable: false),
                    fk_Active_Tour = table.Column<int>(type: "int", nullable: false),
                    fk_Person = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Active_Tours_fk_Active_Tour",
                        column: x => x.fk_Active_Tour,
                        principalTable: "Active_Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Person_fk_Person",
                        column: x => x.fk_Person,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Active_Tours_fk_Tour",
                table: "Active_Tours",
                column: "fk_Tour");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_Person",
                table: "Comments",
                column: "fk_Person");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_Tour",
                table: "Comments",
                column: "fk_Tour");

            migrationBuilder.CreateIndex(
                name: "IX_Images_fk_Tour",
                table: "Images",
                column: "fk_Tour");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_fk_Active_Tour",
                table: "Reservations",
                column: "fk_Active_Tour");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_fk_Person",
                table: "Reservations",
                column: "fk_Person");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Active_Tours");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Tour");
        }
    }
}
