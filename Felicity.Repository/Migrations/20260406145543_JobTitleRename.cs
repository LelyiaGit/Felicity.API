using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Felicity.Repository.Migrations
{
    /// <inheritdoc />
    public partial class JobTitleRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobDescription",
                table: "employments",
                newName: "JobTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "employments",
                newName: "JobDescription");
        }
    }
}
