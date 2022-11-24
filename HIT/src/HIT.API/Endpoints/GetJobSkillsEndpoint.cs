using FastEndpoints;
using HIT.Domain.Entities;
using HIT.Domain.Repositories;

namespace HIT.API.Endpoints;

public class GetJobSkillsEndpoint : EndpointWithoutRequest<IEnumerable<JobSkill>>
{
    private IGenericRepository<JobSkill> repository { get; set; }

    public GetJobSkillsEndpoint(IGenericRepository<JobSkill> repository)
    {
        this.repository = repository;
    }

    public override void Configure()
    {
        Get("/api/v1/job-skills");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(await repository.GetAll(token: ct), cancellation: ct);
    }
}
