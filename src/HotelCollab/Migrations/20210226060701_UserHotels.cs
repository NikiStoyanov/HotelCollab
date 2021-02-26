using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelCollab.Migrations
{
    public partial class UserHotels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Hotels_HotelId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_HotelId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.CreateTable(
                name: "UserHotels",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    HotelId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHotels", x => new { x.UserId, x.HotelId });
                    table.ForeignKey(
                        name: "FK_UserHotels_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserHotels_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserHotels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserHotels_HotelId",
                table: "UserHotels",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHotels_RoleId",
                table: "UserHotels",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHotels");

            migrationBuilder.AddColumn<string>(
                name: "HotelId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_HotelId",
                table: "AspNetUserRoles",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Hotels_HotelId",
                table: "AspNetUserRoles",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
