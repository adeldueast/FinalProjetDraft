using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanUser");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Tournaments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Lans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Lans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Lans_LanId",
                        column: x => x.LanId,
                        principalTable: "Lans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User_Lan",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LanId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Lan", x => new { x.UserId, x.LanId });
                    table.ForeignKey(
                        name: "FK_User_Lan_Lans_LanId",
                        column: x => x.LanId,
                        principalTable: "Lans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Lan_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_LanId",
                table: "Seat",
                column: "LanId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Lan_LanId",
                table: "User_Lan",
                column: "LanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "User_Lan");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Lans");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Lans");

            migrationBuilder.CreateTable(
                name: "LanUser",
                columns: table => new
                {
                    LansId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanUser", x => new { x.LansId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_LanUser_Lans_LansId",
                        column: x => x.LansId,
                        principalTable: "Lans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanUser_UsersId",
                table: "LanUser",
                column: "UsersId");
        }
    }
}
