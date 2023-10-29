using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class RevertChangesInGenresTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_genres",
                table: "tbl_genres");

            migrationBuilder.RenameTable(
                name: "tbl_genres",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "col_name",
                table: "Genres",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "tbl_genres");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tbl_genres",
                newName: "col_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_genres",
                table: "tbl_genres",
                column: "Id");
        }
    }
}
