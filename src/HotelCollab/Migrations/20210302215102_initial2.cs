using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelCollab.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelId",
                table: "Requests",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_HotelId",
                table: "Requests",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Hotels_HotelId",
                table: "Requests",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Hotels_HotelId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_HotelId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Requests");
        }
    }
}
