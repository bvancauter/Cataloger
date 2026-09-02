using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cataloger.Api.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSeriesBookRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookContributors");

            migrationBuilder.CreateTable(
                name: "SeriesContributors",
                columns: table => new
                {
                    SeriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesContributors", x => new { x.SeriesId, x.PersonId, x.Role });
                    table.ForeignKey(
                        name: "FK_SeriesContributors_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesContributors_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeriesContributors_PersonId",
                table: "SeriesContributors",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeriesContributors");

            migrationBuilder.CreateTable(
                name: "BookContributors",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookContributors", x => new { x.BookId, x.PersonId, x.Role });
                    table.ForeignKey(
                        name: "FK_BookContributors_CollectionItemEntity_BookId",
                        column: x => x.BookId,
                        principalTable: "CollectionItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookContributors_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookContributors_PersonId",
                table: "BookContributors",
                column: "PersonId");
        }
    }
}
