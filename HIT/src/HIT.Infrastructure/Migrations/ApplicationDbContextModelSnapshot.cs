﻿// <auto-generated />
using System;
using HIT.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HIT.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("HIT.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("HIT.Domain.Entities.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CandidateLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CandidateType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("LinkedInURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("HIT.Domain.Entities.CandidateCertification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CandidateId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Certification")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("CandidateCertifications");
                });

            modelBuilder.Entity("HIT.Domain.Entities.CandidateSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CandidateId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("CandidateSkills");
                });

            modelBuilder.Entity("HIT.Domain.Entities.JobPosting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("JobPostings");
                });

            modelBuilder.Entity("HIT.Domain.Entities.JobPostingApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApplicationPhase")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CandidateId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("JobPostingId")
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

            modelBuilder.Entity("HIT.Domain.Entities.JobPostingSkill", b =>
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

            modelBuilder.Entity("HIT.Domain.Entities.JobSkill", b =>
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
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SkillCategory")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("JobSkills");
                });

            modelBuilder.Entity("HIT.Domain.Entities.CandidateCertification", b =>
                {
                    b.HasOne("HIT.Domain.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("HIT.Domain.Entities.CandidateSkill", b =>
                {
                    b.HasOne("HIT.Domain.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("HIT.Domain.Entities.JobPostingApplication", b =>
                {
                    b.HasOne("HIT.Domain.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HIT.Domain.Entities.JobPosting", "JobPosting")
                        .WithMany()
                        .HasForeignKey("JobPostingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("JobPosting");
                });

            modelBuilder.Entity("HIT.Domain.Entities.JobPostingSkill", b =>
                {
                    b.HasOne("HIT.Domain.Entities.JobPosting", "JobPosting")
                        .WithMany()
                        .HasForeignKey("JobPostingId");

                    b.HasOne("HIT.Domain.Entities.JobSkill", "JobSkill")
                        .WithMany()
                        .HasForeignKey("JobSkillId");

                    b.Navigation("JobPosting");

                    b.Navigation("JobSkill");
                });
#pragma warning restore 612, 618
        }
    }
}
