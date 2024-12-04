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
                    IdentityCard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstMidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.IdentityCard);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieGenre = table.Column<int>(type: "int", nullable: true),
                    MovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgeRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoviePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SerieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeasonNum = table.Column<int>(type: "int", nullable: false),
                    SerieGenre = table.Column<int>(type: "int", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerieDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeriePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SerieID);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    SerieID = table.Column<int>(type: "int", nullable: false),
                    CostumerID = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseID);
                    table.ForeignKey(
                        name: "FK_Purchases_Costumers_CostumerID",
                        column: x => x.CostumerID,
                        principalTable: "Costumers",
                        principalColumn: "IdentityCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Movies_MoviesMovieID",
                        column: x => x.MoviesMovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID");
                    table.ForeignKey(
                        name: "FK_Purchases_Series_SerieID",
                        column: x => x.SerieID,
                        principalTable: "Series",
                        principalColumn: "SerieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CostumerID",
                table: "Purchases",
                column: "CostumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_MoviesMovieID",
                table: "Purchases",
                column: "MoviesMovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SerieID",
                table: "Purchases",
                column: "SerieID");
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
