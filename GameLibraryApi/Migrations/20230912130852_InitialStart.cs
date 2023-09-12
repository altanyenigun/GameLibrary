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
                    GameMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metascore = table.Column<int>(type: "int", nullable: false),
                    Userscore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Developer", "GameMode", "Genre", "Metascore", "Name", "Platform", "ReleaseDate", "Userscore" },
                values: new object[,]
                {
                    { 1, "Larian Studios Games", "[1,2]", "[6,10]", 96, "Baldur's Gate 3", "[1]", new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.7999999999999998 },
                    { 2, "From Software", "[1,2]", "[6,1]", 96, "Elden Ring", "[1,2,4,5]", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.7999999999999998 },
                    { 3, "SCE Santa Monica", "[1]", "[11,13]", 94, "God of War:Ragnarok", "[2]", new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.9000000000000004 },
                    { 4, "Valve Software", "[1]", "[1,12]", 96, "Half-Life 2", "[1]", new DateTime(2004, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.1999999999999993 },
                    { 5, "Rockstar North", "[1,2]", "[11,13]", 96, "GTA 5", "[1,3,2,4,5]", new DateTime(2015, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.9000000000000004 },
                    { 6, "Rockstar North", "[1]", "[1,12]", 96, "Bioshock", "[1]", new DateTime(2007, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.5999999999999996 },
                    { 7, "LucasArts", "[1]", "[2,4]", 94, "Grim Fandango", "[1]", new DateTime(1998, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0 },
                    { 8, "Rockstar Games", "[1,2]", "[11,13]", 97, "Red Dead Redemption 2", "[1,2]", new DateTime(2018, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.3000000000000007 },
                    { 9, "CD Projekt Red Studio", "[1]", "[1,6]", 91, "The Wither 3: Wild Hunt", "[1,2,6]", new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0999999999999996 },
                    { 10, "Sickhead Games", "[1]", "[6]", 89, "Stardew Valley", "[1,2,6]", new DateTime(2016, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.7999999999999998 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
