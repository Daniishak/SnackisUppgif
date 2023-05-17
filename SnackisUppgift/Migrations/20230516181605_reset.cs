using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackisUppgift.Migrations
{
    /// <inheritdoc />
    public partial class reset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFirstName",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UserLastName",
                table: "Post");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserFirstName",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserLastName",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
