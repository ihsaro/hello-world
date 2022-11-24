using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HIT.Domain.Entities;

namespace HIT.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<Candidate> Candidates => Set<Candidate>();
    public DbSet<CandidateCertification> CandidateCertifications => Set<CandidateCertification>();
    public DbSet<CandidateSkill> CandidateSkills => Set<CandidateSkill>();
    public DbSet<JobPosting> JobPostings => Set<JobPosting>();
    public DbSet<JobPostingApplication> JobPostingApplications => Set<JobPostingApplication>();
    public DbSet<JobPostingApplicationStatus> JobPostingApplicationStatuses => Set<JobPostingApplicationStatus>();
    public DbSet<JobSkill> JobSkills => Set<JobSkill>();
    public DbSet<JobPostingSkill> JobPostingSkills => Set<JobPostingSkill>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<ApplicationUser>()
            .HasIndex(a => a.Username)
            .IsUnique();
        
        builder
            .Entity<ApplicationUser>()
            .HasIndex(a => a.EmailAddress)
            .IsUnique();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            ((BaseEntity)entry.Entity).LastUpdatedTimestamp = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                ((BaseEntity)entry.Entity).CreatedTimestamp = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}