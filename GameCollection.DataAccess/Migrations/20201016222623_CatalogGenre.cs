using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCollection.DataAccess.Migrations
{
    public partial class CatalogGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Game");

            migrationBuilder.CreateTable(
                name: "CatalogGenre",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogGenre", x => new { x.GameId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_CatalogGenre_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogGenre_GameGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "GameGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogGenre_GenreId",
                table: "CatalogGenre",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogGenre");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
