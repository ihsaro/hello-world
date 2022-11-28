﻿// <auto-generated />
using System;
using HIT.REST.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HIT.REST.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221127170233_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CandidateLocation")
                        .HasColumnType("TEXT");

                    b.Property<int>("CandidateType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("LinkedInURL")
                        .HasColumnType("TEXT");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.CandidateSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CandidateId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Skill")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("CandidateSkills");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.JobPosting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("JobLocation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("JobPostings");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.JobPostingApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApplicationPhase")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CandidateId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<int?>("JobPostingId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("MatchRate")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobPostingId");

                    b.ToTable("JobPostingApplications");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.JobPostingApplicationComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<int?>("JobPostingApplicationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("JobPostingApplicationId");

                    b.ToTable("JobPostingApplicationComment");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.JobPostingSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<int?>("JobPostingId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JobSkillId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("JobPostingId");

                    b.HasIndex("JobSkillId");

                    b.ToTable("JobPostingSkills");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.JobSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("SkillCategory")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("JobSkills");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.CandidateSkill", b =>
                {
                    b.HasOne("HIT.REST.Infrastructure.Entities.Candidate", "Candidate")
                        .WithMany("CandidateSkills")
                        .HasForeignKey("CandidateId");

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.JobPostingApplication", b =>
                {
                    b.HasOne("HIT.REST.Infrastructure.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId");

                    b.HasOne("HIT.REST.Infrastructure.Entities.JobPosting", "JobPosting")
                        .WithMany()
                        .HasForeignKey("JobPostingId");

                    b.Navigation("Candidate");

                    b.Navigation("JobPosting");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.JobPostingApplicationComment", b =>
                {
                    b.HasOne("HIT.REST.Infrastructure.Entities.JobPostingApplication", "JobPostingApplication")
                        .WithMany("JobPostingApplicationComments")
                        .HasForeignKey("JobPostingApplicationId");

                    b.Navigation("JobPostingApplication");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.JobPostingSkill", b =>
                {
                    b.HasOne("HIT.REST.Infrastructure.Entities.JobPosting", "JobPosting")
                        .WithMany()
                        .HasForeignKey("JobPostingId");

                    b.HasOne("HIT.REST.Infrastructure.Entities.JobSkill", "JobSkill")
                        .WithMany()
                        .HasForeignKey("JobSkillId");

                    b.Navigation("JobPosting");

                    b.Navigation("JobSkill");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.Candidate", b =>
                {
                    b.Navigation("CandidateSkills");
                });

            modelBuilder.Entity("HIT.REST.Infrastructure.Entities.JobPostingApplication", b =>
                {
                    b.Navigation("JobPostingApplicationComments");
                });
#pragma warning restore 612, 618
        }
    }
}
