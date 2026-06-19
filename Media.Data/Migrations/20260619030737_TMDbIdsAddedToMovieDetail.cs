using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medias.Data.Migrations
{
    /// <inheritdoc />
    public partial class TMDbIdsAddedToMovieDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImdbId",
                table: "MovieDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TmdbMovieId",
                table: "MovieDetails",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImdbId",
                table: "MovieDetails");

            migrationBuilder.DropColumn(
                name: "TmdbMovieId",
                table: "MovieDetails");
        }
    }
}
