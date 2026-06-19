using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medias.Data.Migrations
{
    /// <inheritdoc />
    public partial class CollectionTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Collections_Name",
                table: "Collections",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaItemCollections_CollectionId",
                table: "MediaItemCollections",
                column: "CollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaItemCollections");

            migrationBuilder.DropTable(
                name: "Collections");
        }
    }
}
