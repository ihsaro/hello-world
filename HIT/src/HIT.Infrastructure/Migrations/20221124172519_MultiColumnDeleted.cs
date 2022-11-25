using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MultiColumnDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingSkills_JobPostings_JobPostingId",
                table: "JobPostingSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingSkills_JobSkills_JobSkillId",
                table: "JobPostingSkills");

            migrationBuilder.DropTable(
                name: "JobPostingApplicationStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "JobSkillId",
                table: "JobPostingSkills",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "JobPostingId",
                table: "JobPostingSkills",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationPhase",
                table: "JobPostingApplications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "JobPostingApplications",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingSkills_JobPostings_JobPostingId",
                table: "JobPostingSkills",
                column: "JobPostingId",
                principalTable: "JobPostings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingSkills_JobSkills_JobSkillId",
                table: "JobPostingSkills",
                column: "JobSkillId",
                principalTable: "JobSkills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingSkills_JobPostings_JobPostingId",
                table: "JobPostingSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingSkills_JobSkills_JobSkillId",
                table: "JobPostingSkills");

            migrationBuilder.DropColumn(
                name: "ApplicationPhase",
                table: "JobPostingApplications");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "JobPostingApplications");

            migrationBuilder.AlterColumn<int>(
                name: "JobSkillId",
                table: "JobPostingSkills",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobPostingId",
                table: "JobPostingSkills",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "JobPostingApplicationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobPostingApplicationId = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicationPhase = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostingApplicationStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPostingApplicationStatuses_JobPostingApplications_JobPostingApplicationId",
                        column: x => x.JobPostingApplicationId,
                        principalTable: "JobPostingApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingApplicationStatuses_JobPostingApplicationId",
                table: "JobPostingApplicationStatuses",
                column: "JobPostingApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingSkills_JobPostings_JobPostingId",
                table: "JobPostingSkills",
                column: "JobPostingId",
                principalTable: "JobPostings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingSkills_JobSkills_JobSkillId",
                table: "JobPostingSkills",
                column: "JobSkillId",
                principalTable: "JobSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
