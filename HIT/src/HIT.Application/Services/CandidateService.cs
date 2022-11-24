using AutoMapper;
using HIT.Application.Services.Interfaces;
using HIT.Domain.Entities;
using HIT.Domain.Repositories;

namespace HIT.Application.Services;

public class CandidateService : ICandidateService
{
    private readonly IGenericRepository<Candidate> repository;

    public CandidateService(IGenericRepository<Candidate> repository)
    {
        this.repository = repository;
    }

    public async Task<Candidate> CreateCandidate(Candidate request)
    {
        return await repository.Create(request);
    }
}