using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackisUppgift.Migrations
{
    /// <inheritdoc />
    public partial class version2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Användarnamn",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Birthyear",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Användarnamn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Birthyear",
                table: "AspNetUsers");
        }
    }
}
