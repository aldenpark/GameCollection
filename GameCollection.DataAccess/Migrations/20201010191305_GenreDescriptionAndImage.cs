using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCollection.DataAccess.Migrations
{
    public partial class GenreDescriptionAndImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GameGenre",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "GameGenre",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "GameGenre");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "GameGenre");
        }
    }
}
