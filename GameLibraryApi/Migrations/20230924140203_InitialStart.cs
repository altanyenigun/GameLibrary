using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameLibraryApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameMode = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metascore = table.Column<int>(type: "int", nullable: false),
                    Userscore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => new { x.UserId, x.GameId });
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Developer", "GameMode", "Genre", "Metascore", "Name", "Platform", "ReleaseDate", "Userscore" },
                values: new object[,]
                {
                    { 1, "Larian Studios Games", 1, 4, 96, "Baldur's Gate 3", 1, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.7999999999999998 },
                    { 2, "From Software", 1, 4, 96, "Elden Ring", 1, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.7999999999999998 },
                    { 3, "SCE Santa Monica", 1, 6, 94, "God of War:Ragnarok", 2, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.9000000000000004 },
                    { 4, "Valve Software", 1, 1, 96, "Half-Life 2", 1, new DateTime(2004, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.1999999999999993 },
                    { 5, "Rockstar North", 2, 6, 96, "GTA 5", 1, new DateTime(2015, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.9000000000000004 },
                    { 6, "Rockstar North", 1, 1, 96, "Bioshock", 1, new DateTime(2007, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.5999999999999996 },
                    { 7, "LucasArts", 1, 2, 94, "Grim Fandango", 1, new DateTime(1998, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0 },
                    { 8, "Rockstar Games", 1, 6, 97, "Red Dead Redemption 2", 1, new DateTime(2018, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.3000000000000007 },
                    { 9, "CD Projekt Red Studio", 1, 4, 91, "The Wither 3: Wild Hunt", 1, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0999999999999996 },
                    { 10, "Sickhead Games", 1, 4, 89, "Stardew Valley", 1, new DateTime(2016, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.7999999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "$2a$11$fUnQUFbf4M60oemaV26EUOFkigpSqCMg2JowjStVWVVkntQmXMorm", "Admin", "admin" },
                    { 2, "$2a$11$WJH5AOwlL.H7IkHhA6IvSOuovdUbrJYcI4.jAaFoqj6DMTB.hyYbO", "User", "altan" },
                    { 3, "$2a$11$sLKC.xd0xpjzgfioUEjgf.3orBL7Gvdl7wIFq9.DLaQVR0SgOcZGi", "User", "patika" }
                });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "GameId", "UserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 9, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_GameId",
                table: "UserGames",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
