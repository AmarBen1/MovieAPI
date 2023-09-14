using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class initDbBlazor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Budget",
                table: "Movies",
                newName: "GenreId");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrailerPath",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 5, "Dustin", "Hoffman" },
                    { 6, "Clint", "Eastwood" },
                    { 7, "Lee", "Van Cleef" },
                    { 8, "Eli", "Wallach" },
                    { 9, "Sigourney", "Weaver" },
                    { 10, "Tom", "Skerritt" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 3, "Barry", "Levinson" },
                    { 4, "Sergio", "Leone" },
                    { 5, "Ridley", "Scott" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Genre" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Science-Fiction" },
                    { 4, "Drama" },
                    { 5, "Western" },
                    { 6, "Thriller" }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Duration", "GenreId", "TrailerPath" },
                values: new object[] { "2h 10m", 1, "https://www.youtube.com/embed/giXco2jaZ_4?si=bhuGz4-cg-ka5dqa" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Duration", "GenreId", "TrailerPath" },
                values: new object[] { "1h 45m", 1, "https://www.youtube.com/embed/NPO-Z6mEYW4?si=LAxOH9CVyWYpFjMX" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "Duration", "GenreId", "ReleaseYear", "Title", "TrailerPath" },
                values: new object[,]
                {
                    { 3, 3, "2h 13m", 4, 1988, "Rain Man", "https://www.youtube.com/embed/mlNwXuHUA8I?si=Ho7AiWBMwWx2HpO6" },
                    { 4, 4, "2h 58m", 5, 1966, "The Good, the Bad and the Ugly", "https://www.youtube.com/embed/IFNUGzCOQoI?si=a96JJzg1QCRcJrK5" },
                    { 5, 5, "1h 57m", 3, 1979, "Alien", "https://www.youtube.com/embed/jQ5lPt9edzQ?si=caTNcXcqcHE2p1d-" },
                    { 6, 4, "2h 12m", 5, 1965, "For a Few Dollar More", "https://www.youtube.com/embed/bNt9NcLteoU?si=U6ZFghGM58QWbfD9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genre_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genre_GenreId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId",
                table: "Movies");

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TrailerPath",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Movies",
                newName: "Budget");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Budget",
                value: 150000000);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Budget",
                value: 30000000);
        }
    }
}
