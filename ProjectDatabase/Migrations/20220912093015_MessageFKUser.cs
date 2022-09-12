using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDatabase.Migrations
{
    public partial class MessageFKUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messsages_AspNetUsers_ApplicationUserId",
                table: "Messsages");

            migrationBuilder.DropIndex(
                name: "IX_Messsages_ApplicationUserId",
                table: "Messsages");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Messsages");

            migrationBuilder.CreateIndex(
                name: "IX_Messsages_UserId",
                table: "Messsages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messsages_AspNetUsers_UserId",
                table: "Messsages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messsages_AspNetUsers_UserId",
                table: "Messsages");

            migrationBuilder.DropIndex(
                name: "IX_Messsages_UserId",
                table: "Messsages");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Messsages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messsages_ApplicationUserId",
                table: "Messsages",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messsages_AspNetUsers_ApplicationUserId",
                table: "Messsages",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
