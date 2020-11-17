using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStoreApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckedOutMovie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckedOutMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckedOutMovie_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Genre = table.Column<string>(maxLength: 50, nullable: true),
                    Runtime = table.Column<double>(nullable: false),
                    CheckedOutModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_CheckedOutMovie_CheckedOutModelId",
                        column: x => x.CheckedOutModelId,
                        principalTable: "CheckedOutMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CheckedOutModelId", "Genre", "Runtime", "Title" },
                values: new object[,]
                {
                    { 1, null, "Comedy", 90.0, "Shrek" },
                    { 2, null, "Comedy", 93.0, "Shrek 2: The Next Level" },
                    { 3, null, "Comedy", 93.0, "Shrek the Third" },
                    { 4, null, "Comedy", 93.0, "Shrek Forever After" },
                    { 5, null, "Horror", 26.0, "Scared Shrekless" },
                    { 6, null, "Musical", 130.0, "Shrek the Musical" },
                    { 7, null, "Action", 181.0, "Avengers: Endgame" },
                    { 8, null, "Fantasy", 141.0, "Star Wars: Episode IX - The Rise of Skywalker" },
                    { 9, null, "Horror", 103.0, "Insidious" },
                    { 10, null, "Action", 94.0, "Safe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckedOutMovie_UserId",
                table: "CheckedOutMovie",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CheckedOutModelId",
                table: "Movie",
                column: "CheckedOutModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "CheckedOutMovie");
        }
    }
}
