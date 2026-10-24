using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medias.Data.Migrations
{
    /// <inheritdoc />
    public partial class TelevisionShowCollectionPart1AddCollectionIdToShowAndSeason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "TelevisionShowDetails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "TelevisionSeasons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaItemId",
                table: "TelevisionEpisodes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionShowDetails_CollectionId",
                table: "TelevisionShowDetails",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionEpisodes_MediaItemId",
                table: "TelevisionEpisodes",
                column: "MediaItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TelevisionEpisodes_MediaItems_MediaItemId",
                table: "TelevisionEpisodes",
                column: "MediaItemId",
                principalTable: "MediaItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TelevisionShowDetails_Collections_CollectionId",
                table: "TelevisionShowDetails",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelevisionEpisodes_MediaItems_MediaItemId",
                table: "TelevisionEpisodes");

            migrationBuilder.DropForeignKey(
                name: "FK_TelevisionShowDetails_Collections_CollectionId",
                table: "TelevisionShowDetails");

            migrationBuilder.DropIndex(
                name: "IX_TelevisionShowDetails_CollectionId",
                table: "TelevisionShowDetails");

            migrationBuilder.DropIndex(
                name: "IX_TelevisionEpisodes_MediaItemId",
                table: "TelevisionEpisodes");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "TelevisionShowDetails");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "TelevisionSeasons");

            migrationBuilder.DropColumn(
                name: "MediaItemId",
                table: "TelevisionEpisodes");
        }
    }
}
