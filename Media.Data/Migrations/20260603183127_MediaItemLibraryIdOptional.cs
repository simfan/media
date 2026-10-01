using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medias.Data.Migrations
{
    /// <inheritdoc />
    public partial class MediaItemLibraryIdOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaItems_Libraries_LibraryId",
                table: "MediaItems");

            migrationBuilder.AlterColumn<int>(
                name: "LibraryId",
                table: "MediaItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItems_Libraries_LibraryId",
                table: "MediaItems",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaItems_Libraries_LibraryId",
                table: "MediaItems");

            migrationBuilder.AlterColumn<int>(
                name: "LibraryId",
                table: "MediaItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItems_Libraries_LibraryId",
                table: "MediaItems",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
