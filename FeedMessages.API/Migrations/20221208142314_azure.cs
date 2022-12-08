using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeedMessages.API.Migrations
{
    /// <inheritdoc />
    public partial class azure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "feed",
                keyColumn: "Id",
                keyValue: new Guid("8126b8b8-996b-4da5-9ae6-3239b2c9fa23"));

            migrationBuilder.DeleteData(
                table: "feed",
                keyColumn: "Id",
                keyValue: new Guid("c74d8d05-7969-4148-8e16-4ecdf20675d7"));

            migrationBuilder.DeleteData(
                table: "feed",
                keyColumn: "Id",
                keyValue: new Guid("d26bdfea-b767-4b6c-9f9d-711cae5f9f0b"));

            migrationBuilder.InsertData(
                table: "feed",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "LastEdited", "TopicName" },
                values: new object[,]
                {
                    { new Guid("6a2a747f-713b-4da6-acf8-3d972521fd83"), "thorped077", "The below list are particular vigilante moves i absolutely love.Death Wish, Unbreakable,Death Sentence,Leon (the professional),Gran Torino,Drive,Kill Bill films(especially unbreakable, kill bill 2 , the professional)Can anyone give me any recommendations based on these vibes?Thanks, fellow movie aficionados.edited: Totally forgot about (Unforgiven 1992, which could top my entire list), Man on Fire , and Commando(1985- Pure nostalgia love and soundtrack as a kid in the 80s)r", new DateTime(2022, 12, 8, 15, 23, 13, 987, DateTimeKind.Local).AddTicks(5242), new DateTime(2022, 12, 8, 15, 23, 13, 987, DateTimeKind.Local).AddTicks(5243), "Vigilante Movie Suggestions?" },
                    { new Guid("6b6c7dc5-b62c-4eed-a6d7-fe07945b9f31"), "BobbyCrispyGuitar", "The James Bond films are known for their original opening themes written by popular artists and are often played on the radio and tv. 'Live and Let Die' by Paul McCartney, 'For Your Eyes Only' by Sheena Easton, 'A View to a Kill' by Duran Duran, and 'Goldfinger' by Shirley Bassey are just a few. My personal favorite is 'Nobody Does It Better' by Carly Simon. What James Bond theme do you consider to be the best?", new DateTime(2022, 12, 8, 15, 23, 13, 987, DateTimeKind.Local).AddTicks(5237), new DateTime(2022, 12, 8, 15, 23, 13, 987, DateTimeKind.Local).AddTicks(5239), "What is the greatest James Bond 007 theme song of all time?" },
                    { new Guid("feb3cae4-3879-40f7-baed-eb06a4708ae7"), "boringwhitecollar", "Let’s discuss one of my favorite movies of all time: CLUE. It is such a fun film. Based on a board game, six guests arrive at an isolated mansion for dinner, drinks, and MURDER. Starring: Tim Curry, Eileen Brennan, Madeline Kahn, Christopher Lloyd, Michael McKean, Martin Mull, Lesley Ann Warren, Lee Ving, Colleen Camp, and Howard Hesseman.", new DateTime(2022, 12, 8, 15, 23, 13, 987, DateTimeKind.Local).AddTicks(5193), new DateTime(2022, 12, 8, 15, 23, 13, 987, DateTimeKind.Local).AddTicks(5229), "Clue (1985)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "feed",
                keyColumn: "Id",
                keyValue: new Guid("6a2a747f-713b-4da6-acf8-3d972521fd83"));

            migrationBuilder.DeleteData(
                table: "feed",
                keyColumn: "Id",
                keyValue: new Guid("6b6c7dc5-b62c-4eed-a6d7-fe07945b9f31"));

            migrationBuilder.DeleteData(
                table: "feed",
                keyColumn: "Id",
                keyValue: new Guid("feb3cae4-3879-40f7-baed-eb06a4708ae7"));

            migrationBuilder.InsertData(
                table: "feed",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "LastEdited", "TopicName" },
                values: new object[,]
                {
                    { new Guid("8126b8b8-996b-4da5-9ae6-3239b2c9fa23"), "boringwhitecollar", "Let’s discuss one of my favorite movies of all time: CLUE. It is such a fun film. Based on a board game, six guests arrive at an isolated mansion for dinner, drinks, and MURDER. Starring: Tim Curry, Eileen Brennan, Madeline Kahn, Christopher Lloyd, Michael McKean, Martin Mull, Lesley Ann Warren, Lee Ving, Colleen Camp, and Howard Hesseman.", new DateTime(2022, 11, 28, 17, 34, 58, 380, DateTimeKind.Local).AddTicks(5451), new DateTime(2022, 11, 28, 17, 34, 58, 380, DateTimeKind.Local).AddTicks(5486), "Clue (1985)" },
                    { new Guid("c74d8d05-7969-4148-8e16-4ecdf20675d7"), "BobbyCrispyGuitar", "The James Bond films are known for their original opening themes written by popular artists and are often played on the radio and tv. 'Live and Let Die' by Paul McCartney, 'For Your Eyes Only' by Sheena Easton, 'A View to a Kill' by Duran Duran, and 'Goldfinger' by Shirley Bassey are just a few. My personal favorite is 'Nobody Does It Better' by Carly Simon. What James Bond theme do you consider to be the best?", new DateTime(2022, 11, 28, 17, 34, 58, 380, DateTimeKind.Local).AddTicks(5495), new DateTime(2022, 11, 28, 17, 34, 58, 380, DateTimeKind.Local).AddTicks(5497), "What is the greatest James Bond 007 theme song of all time?" },
                    { new Guid("d26bdfea-b767-4b6c-9f9d-711cae5f9f0b"), "thorped077", "The below list are particular vigilante moves i absolutely love.Death Wish, Unbreakable,Death Sentence,Leon (the professional),Gran Torino,Drive,Kill Bill films(especially unbreakable, kill bill 2 , the professional)Can anyone give me any recommendations based on these vibes?Thanks, fellow movie aficionados.edited: Totally forgot about (Unforgiven 1992, which could top my entire list), Man on Fire , and Commando(1985- Pure nostalgia love and soundtrack as a kid in the 80s)r", new DateTime(2022, 11, 28, 17, 34, 58, 380, DateTimeKind.Local).AddTicks(5500), new DateTime(2022, 11, 28, 17, 34, 58, 380, DateTimeKind.Local).AddTicks(5503), "Vigilante Movie Suggestions?" }
                });
        }
    }
}
