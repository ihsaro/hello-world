using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HIT.REST.Migrations
{
    /// <inheritdoc />
    public partial class FirstNameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingApplicationComment_JobPostingApplications_JobPostingApplicationId",
                table: "JobPostingApplicationComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPostingApplicationComment",
                table: "JobPostingApplicationComment");

            migrationBuilder.RenameTable(
                name: "JobPostingApplicationComment",
                newName: "JobPostingApplicationComments");

            migrationBuilder.RenameIndex(
                name: "IX_JobPostingApplicationComment_JobPostingApplicationId",
                table: "JobPostingApplicationComments",
                newName: "IX_JobPostingApplicationComments_JobPostingApplicationId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPostingApplicationComments",
                table: "JobPostingApplicationComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingApplicationComments_JobPostingApplications_JobPostingApplicationId",
                table: "JobPostingApplicationComments",
                column: "JobPostingApplicationId",
                principalTable: "JobPostingApplications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingApplicationComments_JobPostingApplications_JobPostingApplicationId",
                table: "JobPostingApplicationComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPostingApplicationComments",
                table: "JobPostingApplicationComments");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Candidates");

            migrationBuilder.RenameTable(
                name: "JobPostingApplicationComments",
                newName: "JobPostingApplicationComment");

            migrationBuilder.RenameIndex(
                name: "IX_JobPostingApplicationComments_JobPostingApplicationId",
                table: "JobPostingApplicationComment",
                newName: "IX_JobPostingApplicationComment_JobPostingApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPostingApplicationComment",
                table: "JobPostingApplicationComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingApplicationComment_JobPostingApplications_JobPostingApplicationId",
                table: "JobPostingApplicationComment",
                column: "JobPostingApplicationId",
                principalTable: "JobPostingApplications",
                principalColumn: "Id");
        }
    }
}
