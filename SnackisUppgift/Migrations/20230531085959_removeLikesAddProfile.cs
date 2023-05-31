using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackisUppgift.Migrations
{
    /// <inheritdoc />
    public partial class removeLikesAddProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "PostedBy",
                table: "Post",
                newName: "ProfilePicture");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "Post",
                newName: "PostedBy");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Post",
                type: "int",
                nullable: true);
        }
    }
}
