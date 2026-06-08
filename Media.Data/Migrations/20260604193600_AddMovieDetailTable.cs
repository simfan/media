using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medias.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieDetailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaItems_Libraries_LibraryId",
                table: "MediaItems");

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
                    Rating = table.Column<decimal>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_CreatedDate",
                table: "MediaItems",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_MediaType",
                table: "MediaItems",
                column: "MediaType");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_Title",
                table: "MediaItems",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_Checksum",
                table: "MediaFiles",
                column: "Checksum");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_FilePath",
                table: "MediaFiles",
                column: "FilePath");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_Path",
                table: "Libraries",
                column: "Path");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItems_Libraries_LibraryId",
                table: "MediaItems",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaItems_Libraries_LibraryId",
                table: "MediaItems");

            migrationBuilder.DropTable(
                name: "MovieDetails");

            migrationBuilder.DropIndex(
                name: "IX_MediaItems_CreatedDate",
                table: "MediaItems");

            migrationBuilder.DropIndex(
                name: "IX_MediaItems_MediaType",
                table: "MediaItems");

            migrationBuilder.DropIndex(
                name: "IX_MediaItems_Title",
                table: "MediaItems");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_Checksum",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_FilePath",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_Libraries_Path",
                table: "Libraries");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItems_Libraries_LibraryId",
                table: "MediaItems",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id");
        }
    }
}
