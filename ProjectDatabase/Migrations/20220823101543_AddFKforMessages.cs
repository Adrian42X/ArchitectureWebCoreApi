using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDatabase.Migrations
{
    public partial class AddFKforMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessagId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Messsages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messsages_UserId",
                table: "Messsages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messsages_Users_UserId",
                table: "Messsages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messsages_Users_UserId",
                table: "Messsages");

            migrationBuilder.DropIndex(
                name: "IX_Messsages_UserId",
                table: "Messsages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messsages");

            migrationBuilder.AddColumn<int>(
                name: "MessagId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
