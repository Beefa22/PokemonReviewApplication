using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReviewApplication.Migrations
{
    public partial class deleteTestColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Reviewers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Reviewers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
