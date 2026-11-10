using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medias.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarcodeProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Barcode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodeProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionId);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Path = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    LibraryType = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

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
                name: "TelevisionShowDetails",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Studio = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Rating = table.Column<decimal>(type: "TEXT", precision: 3, scale: 1, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    TmdbTvId = table.Column<int>(type: "INTEGER", nullable: true),
                    ImdbId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    SeasonCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelevisionShowDetails", x => x.CollectionId);
                    table.ForeignKey(
                        name: "FK_TelevisionShowDetails_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    MediaType = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LibraryId = table.Column<int>(type: "INTEGER", nullable: true),
                    ThumbnailPath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Barcode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaItems_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelevisionSeasons",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    CollectionId = table.Column<int>(type: "INTEGER", nullable: true),
                    TelevisionShowCollectionId = table.Column<int>(type: "INTEGER", nullable: true),
                    SeasonNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    EpisodeCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelevisionSeasons", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_TelevisionSeasons_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelevisionSeasons_TelevisionShowDetails_TelevisionShowCollectionId",
                        column: x => x.TelevisionShowCollectionId,
                        principalTable: "TelevisionShowDetails",
                        principalColumn: "CollectionId");
                });

            migrationBuilder.CreateTable(
                name: "MediaFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: false),
                    FileType = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Checksum = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaFiles_MediaItems_MediaItemId",
                        column: x => x.MediaItemId,
                        principalTable: "MediaItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaItemCollections",
                columns: table => new
                {
                    MediaItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    CollectionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaItemCollections", x => new { x.MediaItemId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_MediaItemCollections_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaItemCollections_MediaItems_MediaItemId",
                        column: x => x.MediaItemId,
                        principalTable: "MediaItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetails",
                columns: table => new
                {
                    MediaItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Runtime = table.Column<int>(type: "INTEGER", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Director = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Studio = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Rating = table.Column<decimal>(type: "TEXT", nullable: false),
                    TmdbMovieId = table.Column<int>(type: "INTEGER", nullable: true),
                    ImdbId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetails", x => x.MediaItemId);
                    table.ForeignKey(
                        name: "FK_MovieDetails_MediaItems_MediaItemId",
                        column: x => x.MediaItemId,
                        principalTable: "MediaItems",
                        principalColumn: "Id",
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
                    MusicBrainzRecordingId = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "TelevisionEpisodes",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EpisodeNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    TelevisionShowId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeasonId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeasonNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Director = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Runtime = table.Column<int>(type: "INTEGER", nullable: true),
                    MediaItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<decimal>(type: "TEXT", precision: 3, scale: 1, nullable: true),
                    AirDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelevisionEpisodes", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_TelevisionEpisodes_MediaItems_MediaItemId",
                        column: x => x.MediaItemId,
                        principalTable: "MediaItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelevisionEpisodes_TelevisionSeasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "TelevisionSeasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelevisionEpisodes_TelevisionShowDetails_TelevisionShowId",
                        column: x => x.TelevisionShowId,
                        principalTable: "TelevisionShowDetails",
                        principalColumn: "CollectionId");
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
                name: "IX_BarcodeProducts_Title",
                table: "BarcodeProducts",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_Name",
                table: "Collections",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_Path",
                table: "Libraries",
                column: "Path");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_Checksum",
                table: "MediaFiles",
                column: "Checksum");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_FilePath",
                table: "MediaFiles",
                column: "FilePath");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_MediaItemId",
                table: "MediaFiles",
                column: "MediaItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItemCollections_CollectionId",
                table: "MediaItemCollections",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_CreatedDate",
                table: "MediaItems",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_LibraryId",
                table: "MediaItems",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_MediaType",
                table: "MediaItems",
                column: "MediaType");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_Title",
                table: "MediaItems",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_Director",
                table: "MovieDetails",
                column: "Director");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_Genre",
                table: "MovieDetails",
                column: "Genre");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_Studio",
                table: "MovieDetails",
                column: "Studio");

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

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionEpisodes_MediaItemId",
                table: "TelevisionEpisodes",
                column: "MediaItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionEpisodes_SeasonId",
                table: "TelevisionEpisodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionEpisodes_SeasonId_EpisodeNumber",
                table: "TelevisionEpisodes",
                columns: new[] { "SeasonId", "EpisodeNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionEpisodes_TelevisionShowId",
                table: "TelevisionEpisodes",
                column: "TelevisionShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionSeasons_CollectionId",
                table: "TelevisionSeasons",
                column: "CollectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionSeasons_TelevisionShowCollectionId_SeasonNumber",
                table: "TelevisionSeasons",
                columns: new[] { "TelevisionShowCollectionId", "SeasonNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionShowDetails_CreatedBy",
                table: "TelevisionShowDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionShowDetails_Genre",
                table: "TelevisionShowDetails",
                column: "Genre");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionShowDetails_Studio",
                table: "TelevisionShowDetails",
                column: "Studio");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionShowDetails_TmdbTvId",
                table: "TelevisionShowDetails",
                column: "TmdbTvId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumTracks");

            migrationBuilder.DropTable(
                name: "BarcodeProducts");

            migrationBuilder.DropTable(
                name: "MediaFiles");

            migrationBuilder.DropTable(
                name: "MediaItemCollections");

            migrationBuilder.DropTable(
                name: "MovieDetails");

            migrationBuilder.DropTable(
                name: "TelevisionEpisodes");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "MusicDetails");

            migrationBuilder.DropTable(
                name: "TelevisionSeasons");

            migrationBuilder.DropTable(
                name: "MediaItems");

            migrationBuilder.DropTable(
                name: "TelevisionShowDetails");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "Collections");
        }
    }
}
