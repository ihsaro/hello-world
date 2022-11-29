using HIT.REST.BL.Interfaces;
using HIT.REST.Infrastructure.Entities;
using HIT.REST.Infrastructure.Network;
using HIT.REST.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HIT.REST.BL;

public class JobPostingApplicationBL : IJobPostingApplicationBL
{
    private readonly ApplicationDbContext context;

    public JobPostingApplicationBL(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<JobPostingApplication> AddComment(int id, string comment, CancellationToken token = default)
    {
        var jobPostingApplication = context.JobPostingApplications.Where(x => x.Id == id).First();

        context.JobPostingApplicationComments.Add(new JobPostingApplicationComment()
        {
            Comment = comment,
            JobPostingApplication = jobPostingApplication
        });

        await context.SaveChangesAsync();

        return jobPostingApplication;
    }

    public async Task<IEnumerable<string>> GetAllComments(int id, CancellationToken token = default)
    {
        return await context.JobPostingApplicationComments.Include(x => x.JobPostingApplication).Where(x => x.JobPostingApplication.Id == id).Select(x => x.Comment).ToListAsync(cancellationToken: token);
    }

    public async Task<JobPostingApplication> UpdateJobApplicationStatus(int id, ApplicationPhase phase, CancellationToken token = default)
    {
        var jobPostingApplication = context.JobPostingApplications.Include(x => x.Candidate).Where(x => x.Id == id).First();
        jobPostingApplication.ApplicationPhase = phase;

        if (phase == ApplicationPhase.REJECTED)
        {
            var candidate = context.Candidates.Where(x => x.id == jobPostingApplication.Candidate.Id).First();
            candidate.CandidateType = CandidateType.FUTURE;
        }

        await context.SaveChangesAsync();

        EmailDispatcher.SendEmail(jobPostingApplication.Candidate.EmailAddress, $"Hello, this is to inform you that your application has been changed to {phase}");

        return jobPostingApplication;
    }
}