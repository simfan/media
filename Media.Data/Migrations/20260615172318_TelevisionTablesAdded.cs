using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medias.Data.Migrations
{
    /// <inheritdoc />
    public partial class TelevisionTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelevisionShowDetails",
                columns: table => new
                {
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
                    table.PrimaryKey("PK_TelevisionShowDetails", x => x.MediaItemId);
                    table.ForeignKey(
                        name: "FK_TelevisionShowDetails_MediaItems_MediaItemId",
                        column: x => x.MediaItemId,
                        principalTable: "MediaItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelevisionSeasons",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeasonNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    EpisodeCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelevisionSeasons", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_TelevisionSeasons_TelevisionShowDetails_MediaItemId",
                        column: x => x.MediaItemId,
                        principalTable: "TelevisionShowDetails",
                        principalColumn: "MediaItemId",
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
                    Director = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Runtime = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<decimal>(type: "TEXT", precision: 3, scale: 1, nullable: true),
                    AirDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelevisionEpisodes", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_TelevisionEpisodes_TelevisionSeasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "TelevisionSeasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_TelevisionSeasons_MediaItemId",
                table: "TelevisionSeasons",
                column: "MediaItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionSeasons_MediaItemId_SeasonNumber",
                table: "TelevisionSeasons",
                columns: new[] { "MediaItemId", "SeasonNumber" },
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
                name: "TelevisionEpisodes");

            migrationBuilder.DropTable(
                name: "TelevisionSeasons");

            migrationBuilder.DropTable(
                name: "TelevisionShowDetails");
        }
    }
}
