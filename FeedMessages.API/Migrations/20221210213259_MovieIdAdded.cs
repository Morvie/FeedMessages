using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeedMessages.API.Migrations
{
    /// <inheritdoc />
    public partial class MovieIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "feed",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feed", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "feed",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "LastEdited", "MovieId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("19f55001-18d4-4a8a-a402-4cf3b0867ecb"), "thorped077", "The below list are particular vigilante moves i absolutely love.Death Wish, Unbreakable,Death Sentence,Leon (the professional),Gran Torino,Drive,Kill Bill films(especially unbreakable, kill bill 2 , the professional)Can anyone give me any recommendations based on these vibes?Thanks, fellow movie aficionados.edited: Totally forgot about (Unforgiven 1992, which could top my entire list), Man on Fire , and Commando(1985- Pure nostalgia love and soundtrack as a kid in the 80s)r", new DateTime(2022, 12, 10, 22, 32, 59, 773, DateTimeKind.Local).AddTicks(6302), new DateTime(2022, 12, 10, 22, 32, 59, 773, DateTimeKind.Local).AddTicks(6304), 436270, "Vigilante Movie Suggestions?" },
                    { new Guid("3af84778-21e2-4c1c-8459-9be3040b3929"), "boringwhitecollar", "Let’s discuss one of my favorite movies of all time: CLUE. It is such a fun film. Based on a board game, six guests arrive at an isolated mansion for dinner, drinks, and MURDER. Starring: Tim Curry, Eileen Brennan, Madeline Kahn, Christopher Lloyd, Michael McKean, Martin Mull, Lesley Ann Warren, Lee Ving, Colleen Camp, and Howard Hesseman.", new DateTime(2022, 12, 10, 22, 32, 59, 773, DateTimeKind.Local).AddTicks(6259), new DateTime(2022, 12, 10, 22, 32, 59, 773, DateTimeKind.Local).AddTicks(6289), 436270, "Clue (1985)" },
                    { new Guid("f0010174-4c05-46b5-a2d7-a4cc96ad2e27"), "BobbyCrispyGuitar", "The James Bond films are known for their original opening themes written by popular artists and are often played on the radio and tv. 'Live and Let Die' by Paul McCartney, 'For Your Eyes Only' by Sheena Easton, 'A View to a Kill' by Duran Duran, and 'Goldfinger' by Shirley Bassey are just a few. My personal favorite is 'Nobody Does It Better' by Carly Simon. What James Bond theme do you consider to be the best?", new DateTime(2022, 12, 10, 22, 32, 59, 773, DateTimeKind.Local).AddTicks(6298), new DateTime(2022, 12, 10, 22, 32, 59, 773, DateTimeKind.Local).AddTicks(6299), 436270, "What is the greatest James Bond 007 theme song of all time?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feed");
        }
    }
}
