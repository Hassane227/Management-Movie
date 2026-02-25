using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatetest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "category",
                table: "Movies",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Movies",
                newName: "category");
        }
    }
}
