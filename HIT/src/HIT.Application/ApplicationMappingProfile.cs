using AutoMapper;
using HIT.Application.Models;
using HIT.Domain.Entities;

namespace HIT.Application;

internal class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<CreateCandidateRequest, Candidate>();
        CreateMap<Candidate, CreateCandidateResponse>();
    }
}