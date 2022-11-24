using FastEndpoints;
using HIT.Domain.Entities;
using HIT.Domain.Repositories;

namespace HIT.API.Endpoints;

public class CreateJobSkillEndpoint : Endpoint<JobSkill, JobSkill>
{
    private IGenericRepository<JobSkill> repository { get; set; }

    public CreateJobSkillEndpoint(IGenericRepository<JobSkill> repository)
    {
        this.repository = repository;
    }

    public override void Configure()
    {
        Post("/api/v1/job-skills");
        AllowAnonymous();
    }

    public override async Task HandleAsync(JobSkill request, CancellationToken ct)
    {
        await SendAsync(await repository.Create(request, ct), cancellation: ct);
    }
}
