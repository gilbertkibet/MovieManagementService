using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieManagement.Infrastructure.Migrations
{
    public partial class CreatingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblActors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblActors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblBiographies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBiographies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblBiographies_tblActors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "tblActors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblMovies_tblActors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "tblActors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenreId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_tblGenres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "tblGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_tblMovies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "tblMovies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblActors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Gilbert", "Kibet" },
                    { 2, "Jack", "Norris" },
                    { 3, "Jadniwik", "The bossman" },
                    { 4, "Brian", "Guniess" }
                });

            migrationBuilder.InsertData(
                table: "tblMovies",
                columns: new[] { "Id", "ActorId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "This is description", "Game  of trones" },
                    { 2, 2, "This is deiii", "Game  of tr" },
                    { 3, 1, "This is desc", "Game  of " },
                    { 4, 3, "This is desc", "Game " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBiographies_ActorId",
                table: "tblBiographies",
                column: "ActorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblMovies_ActorId",
                table: "tblMovies",
                column: "ActorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "tblBiographies");

            migrationBuilder.DropTable(
                name: "tblGenres");

            migrationBuilder.DropTable(
                name: "tblMovies");

            migrationBuilder.DropTable(
                name: "tblActors");
        }
    }
}
