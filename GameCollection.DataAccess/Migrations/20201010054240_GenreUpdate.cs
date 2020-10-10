using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCollection.DataAccess.Migrations
{
    public partial class GenreUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "GameGenre",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "GameGenre");
        }
    }
}
