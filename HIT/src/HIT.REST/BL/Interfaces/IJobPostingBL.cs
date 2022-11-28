using HIT.REST.Infrastructure.Entities;
using HIT.REST.Models;

namespace HIT.REST.BL.Interfaces;

public interface IJobPostingBL
{
    Task<JobPostingCreateResponse> Create(JobPostingCreateRequest request, CancellationToken token = default);
    Task<IEnumerable<JobPostingCreateResponse>> GetAll(CancellationToken token = default);
    Task<IEnumerable<JobPostingApplication>> GetAllCandidates(int id, ApplicationPhase? phase, CancellationToken token = default);
}