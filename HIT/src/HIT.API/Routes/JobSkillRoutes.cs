using Microsoft.AspNetCore.Mvc;

using HIT.API.Routes.Configuration;
using HIT.Domain.Repositories;
using HIT.Domain.Entities;

namespace HIT.API.Routes;

public sealed class JobSkillRoutes : IRoute
{
    public void ConfigureRoutes(WebApplication app)
    {
        app
            .MapPost("api/v1/job-skills", Create)
            .AllowAnonymous();

        app
            .MapGet("api/v1/job-skills", GetAll)
            .AllowAnonymous();
    }

    private async Task<IResult> Create([FromBody] JobSkill entity, [FromServices] IGenericRepository<JobSkill> repository, CancellationToken token = default)
    {
        var result = await repository.Create(entity, token: token);
        return Results.Ok(result);
    }

    private async Task<IResult> GetAll([FromServices] IGenericRepository<JobSkill> repository, CancellationToken token = default)
    {
        var result = await repository.GetAll(token: token);
        return Results.Ok(result);
    }
}
