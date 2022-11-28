using HIT.REST.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HIT.REST.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Candidate> Candidates => Set<Candidate>();
    public DbSet<CandidateSkill> CandidateSkills => Set<CandidateSkill>();
    public DbSet<JobPosting> JobPostings => Set<JobPosting>();
    public DbSet<JobPostingApplication> JobPostingApplications => Set<JobPostingApplication>();
    public DbSet<JobPostingApplicationComment> JobPostingApplicationComments => Set<JobPostingApplicationComment>();
    public DbSet<JobSkill> JobSkills => Set<JobSkill>();
    public DbSet<JobPostingSkill> JobPostingSkills => Set<JobPostingSkill>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
    {
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