using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medias.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlbumAndAlbumTrackTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Artist = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Studio = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CoverArtPath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    MusicBrainzReleaseId = table.Column<string>(type: "TEXT", maxLength: 36, nullable: true),
                    MusicBrainzReleaseGroupId = table.Column<string>(type: "TEXT", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.CollectionId);
                    table.ForeignKey(
                        name: "FK_Albums_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicDetails",
                columns: table => new
                {
                    MediaItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Artist = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Writer = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Studio = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Runtime = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstReleased = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rating = table.Column<decimal>(type: "TEXT", nullable: false),
                    CoverArtPath = table.Column<string>(type: "TEXT", nullable: true),
                    MusicBrainzRecordingId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicDetails", x => x.MediaItemId);
                    table.ForeignKey(
                        name: "FK_MusicDetails_MediaItems_MediaItemId",
                        column: x => x.MediaItemId,
                        principalTable: "MediaItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumTracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CollectionId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscNumber = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumTracks", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_AlbumTracks_Albums_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Albums",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumTracks_MusicDetails_MediaItemId",
                        column: x => x.MediaItemId,
                        principalTable: "MusicDetails",
                        principalColumn: "MediaItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_Artist",
                table: "Albums",
                column: "Artist");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_MusicBrainzReleaseId",
                table: "Albums",
                column: "MusicBrainzReleaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_Studio",
                table: "Albums",
                column: "Studio");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumTracks_CollectionId_DiscNumber_TrackNumber",
                table: "AlbumTracks",
                columns: new[] { "CollectionId", "DiscNumber", "TrackNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumTracks_CollectionId_MediaItemId",
                table: "AlbumTracks",
                columns: new[] { "CollectionId", "MediaItemId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumTracks_MediaItemId",
                table: "AlbumTracks",
                column: "MediaItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicDetails_Artist",
                table: "MusicDetails",
                column: "Artist");

            migrationBuilder.CreateIndex(
                name: "IX_MusicDetails_Genre",
                table: "MusicDetails",
                column: "Genre");

            migrationBuilder.CreateIndex(
                name: "IX_MusicDetails_Studio",
                table: "MusicDetails",
                column: "Studio");

            migrationBuilder.CreateIndex(
                name: "IX_MusicDetails_Writer",
                table: "MusicDetails",
                column: "Writer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumTracks");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "MusicDetails");
        }
    }
}
