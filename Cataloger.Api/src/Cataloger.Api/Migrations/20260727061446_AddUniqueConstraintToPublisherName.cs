using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cataloger.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToPublisherName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Publishers_Name",
                table: "Publishers",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Publishers_Name",
                table: "Publishers");
        }
    }
}
