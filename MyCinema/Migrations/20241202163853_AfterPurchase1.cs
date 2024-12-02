using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCinema.Migrations
{
    /// <inheritdoc />
    public partial class AfterPurchase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FirstMidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.LastName);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieGenre = table.Column<int>(type: "int", nullable: true),
                    MovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgeRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoviePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieName);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SerieName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SerieID = table.Column<int>(type: "int", nullable: false),
                    SeasonNum = table.Column<int>(type: "int", nullable: false),
                    SerieGenre = table.Column<int>(type: "int", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerieDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeriePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SerieName);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseID = table.Column<int>(type: "int", nullable: false),
                    SerieID = table.Column<int>(type: "int", nullable: false),
                    CostumerID = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoviesMovieName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SeriesSerieName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CostumersLastName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_Purchases_Costumers_CostumersLastName",
                        column: x => x.CostumersLastName,
                        principalTable: "Costumers",
                        principalColumn: "LastName");
                    table.ForeignKey(
                        name: "FK_Purchases_Movies_MoviesMovieName",
                        column: x => x.MoviesMovieName,
                        principalTable: "Movies",
                        principalColumn: "MovieName");
                    table.ForeignKey(
                        name: "FK_Purchases_Series_SeriesSerieName",
                        column: x => x.SeriesSerieName,
                        principalTable: "Series",
                        principalColumn: "SerieName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CostumersLastName",
                table: "Purchases",
                column: "CostumersLastName");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_MoviesMovieName",
                table: "Purchases",
                column: "MoviesMovieName");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SeriesSerieName",
                table: "Purchases",
                column: "SeriesSerieName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Costumers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
