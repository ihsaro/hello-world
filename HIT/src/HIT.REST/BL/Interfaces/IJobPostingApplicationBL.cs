using HIT.REST.Infrastructure.Entities;

namespace HIT.REST.BL.Interfaces;

public interface IJobPostingApplicationBL
{
    Task<JobPostingApplication> AddComment(int id, string comment, CancellationToken token = default);
    Task<IEnumerable<string>> GetAllComments(int id, CancellationToken token = default);
    Task<JobPostingApplication> UpdateJobApplicationStatus(int id, ApplicationPhase phase, CancellationToken token = default);
}