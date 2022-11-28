using Microsoft.AspNetCore.Mvc;

using HIT.REST.Routes.Configuration;
using HIT.REST.Infrastructure.Entities;
using HIT.REST.BL.Interfaces;

namespace HIT.REST.Routes;

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

    private async Task<IResult> Create([FromBody] JobSkill entity, [FromServices] IJobSkillBL jobSkillBL, CancellationToken token = default)
    {
        var result = await jobSkillBL.Create(entity, token: token);
        return Results.Ok(result);
    }

    private async Task<IResult> GetAll([FromServices] IJobSkillBL jobSkillBL, CancellationToken token = default)
    {
        var result = await jobSkillBL.GetAll(token: token);
        return Results.Ok(result);
    }
}