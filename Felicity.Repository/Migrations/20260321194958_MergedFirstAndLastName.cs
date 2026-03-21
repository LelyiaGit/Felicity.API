using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Felicity.Repository.Migrations
{
    /// <inheritdoc />
    public partial class MergedFirstAndLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "persons");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "persons",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "persons",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "persons",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
