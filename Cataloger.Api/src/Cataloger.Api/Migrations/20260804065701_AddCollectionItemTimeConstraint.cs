using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cataloger.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionItemTimeConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_CollectionItem_UpdatedAt_After_CreatedAt",
                table: "CollectionItemEntity",
                sql: "\"UpdatedAt\" IS NULL OR \"UpdatedAt\" >= \"CreatedAt\"");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CollectionItem_UpdatedAt_After_CreatedAt",
                table: "CollectionItemEntity");
        }
    }
}
