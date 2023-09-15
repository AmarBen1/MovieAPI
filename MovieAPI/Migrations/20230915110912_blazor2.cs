using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class blazor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "Duration", "GenreId", "ReleaseYear", "Title", "TrailerPath" },
                values: new object[] { 7, 2, "2h 04m", 1, 1986, "Top Gun", "https://www.youtube.com/embed/bNt9NcLteoU?si=U6ZFghGM58QWbfD9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
