using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Authors(FirstName, LastName) VALUES('Mark', 'Twain')");
            migrationBuilder.Sql("INSERT INTO Authors(FirstName, LastName) VALUES('James', 'Joice')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
