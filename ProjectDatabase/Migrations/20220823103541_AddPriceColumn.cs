using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDatabase.Migrations
{
    public partial class AddPriceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Messsages",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Messsages");
        }
    }
}
