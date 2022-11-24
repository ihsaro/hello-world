using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    LinkedInURL = table.Column<string>(type: "TEXT", nullable: false),
                    CandidateType = table.Column<int>(type: "INTEGER", nullable: false),
                    CandidateLocation = table.Column<string>(type: "TEXT", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPostings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    JobLocation = table.Column<int>(type: "INTEGER", nullable: false),
                    JobType = table.Column<int>(type: "INTEGER", nullable: false),
                    JobStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    SkillCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateCertifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CandidateId = table.Column<int>(type: "INTEGER", nullable: false),
                    Certification = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCertifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateCertifications_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CandidateId = table.Column<int>(type: "INTEGER", nullable: false),
                    Skill = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPostingApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobPostingId = table.Column<int>(type: "INTEGER", nullable: false),
                    CandidateId = table.Column<int>(type: "INTEGER", nullable: false),
                    MatchRate = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostingApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPostingApplications_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPostingApplications_JobPostings_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPostings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPostingSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobPostingId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobSkillId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostingSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPostingSkills_JobPostings_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPostings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPostingSkills_JobSkills_JobSkillId",
                        column: x => x.JobSkillId,
                        principalTable: "JobSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPostingApplicationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobPostingApplicationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    ApplicationPhase = table.Column<int>(type: "INTEGER", nullable: false),
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
                name: "IX_ApplicationUsers_EmailAddress",
                table: "ApplicationUsers",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Username",
                table: "ApplicationUsers",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertifications_CandidateId",
                table: "CandidateCertifications",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_CandidateId",
                table: "CandidateSkills",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingApplications_CandidateId",
                table: "JobPostingApplications",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingApplications_JobPostingId",
                table: "JobPostingApplications",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingApplicationStatuses_JobPostingApplicationId",
                table: "JobPostingApplicationStatuses",
                column: "JobPostingApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingSkills_JobPostingId",
                table: "JobPostingSkills",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingSkills_JobSkillId",
                table: "JobPostingSkills",
                column: "JobSkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "CandidateCertifications");

            migrationBuilder.DropTable(
                name: "CandidateSkills");

            migrationBuilder.DropTable(
                name: "JobPostingApplicationStatuses");

            migrationBuilder.DropTable(
                name: "JobPostingSkills");

            migrationBuilder.DropTable(
                name: "JobPostingApplications");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "JobPostings");
        }
    }
}
