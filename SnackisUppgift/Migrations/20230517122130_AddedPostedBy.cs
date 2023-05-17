using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackisUppgift.Migrations
{
    /// <inheritdoc />
    public partial class AddedPostedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Post");
        }
    }
}
