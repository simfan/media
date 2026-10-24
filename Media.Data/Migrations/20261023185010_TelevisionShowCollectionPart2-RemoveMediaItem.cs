using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medias.Data.Migrations
{
    /// <inheritdoc />
    public partial class TelevisionShowCollectionPart2RemoveMediaItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TelevisionSeasons_MediaItemId_SeasonNumber",
                table: "TelevisionSeasons");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionSeasons_CollectionId",
                table: "TelevisionSeasons",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionSeasons_CollectionId_SeasonNumber",
                table: "TelevisionSeasons",
                columns: new[] { "CollectionId", "SeasonNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TelevisionSeasons_CollectionId",
                table: "TelevisionSeasons");

            migrationBuilder.DropIndex(
                name: "IX_TelevisionSeasons_CollectionId_SeasonNumber",
                table: "TelevisionSeasons");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionSeasons_MediaItemId_SeasonNumber",
                table: "TelevisionSeasons",
                columns: new[] { "MediaItemId", "SeasonNumber" },
                unique: true);
        }
    }
}
