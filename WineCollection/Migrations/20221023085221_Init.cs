using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCollection.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrapeVarieties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrapeVarietyName = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "unknown"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrapeVarieties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vineyards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vineyards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vineyards_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WineCellars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineCellars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineCellars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TasteDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ServingTemp_C = table.Column<decimal>(name: "ServingTemp_(C)", type: "decimal(3,1)", maxLength: 20, nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    GrapeVarietyId = table.Column<int>(type: "int", nullable: false),
                    VineyardId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WineCellarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wines_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wines_GrapeVarieties_GrapeVarietyId",
                        column: x => x.GrapeVarietyId,
                        principalTable: "GrapeVarieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wines_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wines_Vineyards_VineyardId",
                        column: x => x.VineyardId,
                        principalTable: "Vineyards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wines_WineCellars_WineCellarId",
                        column: x => x.WineCellarId,
                        principalTable: "WineCellars",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Color" },
                values: new object[] { 1, "Red" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Color" },
                values: new object[] { 2, "White" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Color" },
                values: new object[] { 3, "Rose" });

            migrationBuilder.CreateIndex(
                name: "IX_Vineyards_CountryId",
                table: "Vineyards",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_WineCellars_UserId",
                table: "WineCellars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_ColorId",
                table: "Wines",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_GrapeVarietyId",
                table: "Wines",
                column: "GrapeVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_UserId",
                table: "Wines",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_VineyardId",
                table: "Wines",
                column: "VineyardId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_WineCellarId",
                table: "Wines",
                column: "WineCellarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wines");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "GrapeVarieties");

            migrationBuilder.DropTable(
                name: "Vineyards");

            migrationBuilder.DropTable(
                name: "WineCellars");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
