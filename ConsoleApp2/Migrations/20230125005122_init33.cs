using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    public partial class init33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Seats_SeatId",
                table: "Inscriptions");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Seats_SeatId",
                table: "Inscriptions",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Seats_SeatId",
                table: "Inscriptions");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Seats_SeatId",
                table: "Inscriptions",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
