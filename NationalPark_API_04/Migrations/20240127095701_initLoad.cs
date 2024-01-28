using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalPark_API_04.Migrations
{
    /// <inheritdoc />
    public partial class initLoad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nationalParks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stablished = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationalParks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distane = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elevation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    difficulty = table.Column<int>(type: "int", nullable: false),
                    NationalParkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trails_nationalParks_NationalParkId",
                        column: x => x.NationalParkId,
                        principalTable: "nationalParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trails_NationalParkId",
                table: "trails",
                column: "NationalParkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trails");

            migrationBuilder.DropTable(
                name: "nationalParks");
        }
    }
}
