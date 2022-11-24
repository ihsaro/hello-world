using HIT.Domain.Entities;

namespace HIT.Application.Services.Interfaces;

public interface ICandidateService
{
    Task<Candidate> CreateCandidate(Candidate request);
}