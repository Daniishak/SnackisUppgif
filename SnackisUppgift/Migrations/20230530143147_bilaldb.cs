using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackisUppgift.Migrations
{
    /// <inheritdoc />
    public partial class bilaldb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Post_SubjectId",
                table: "Post",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Subjects_SubjectId",
                table: "Post",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Subjects_SubjectId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_SubjectId",
                table: "Post");
        }
    }
}
