using HIT.REST.BL.Interfaces;
using HIT.REST.Infrastructure.Entities;
using HIT.REST.Models;
using HIT.REST.Routes.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace HIT.REST.Routes;

public sealed class JobPostingRoutes : IRoute
{
    public void ConfigureRoutes(WebApplication app)
    {
        app
            .MapPost("api/v1/job-postings", Create)
            .AllowAnonymous();

        app
            .MapGet("api/v1/job-postings", GetAll)
            .AllowAnonymous();

        app
            .MapGet("api/v1/job-postings/{id}/candidates", GetAllCandidates)
            .AllowAnonymous();
    }

    private async Task<IResult> Create([FromBody] JobPostingCreateRequest request, [FromServices] IJobPostingBL jobPostingBL, CancellationToken token = default)
    {
        return Results.Ok(await jobPostingBL.Create(request, token));
    }

    private async Task<IResult> GetAll([FromServices] IJobPostingBL jobPostingBL, CancellationToken token = default)
    {
        return Results.Ok(await jobPostingBL.GetAll(token));
    }

    private async Task<IResult> GetAllCandidates([FromRoute] int id, [FromQuery] ApplicationPhase? phase, [FromServices] IJobPostingBL jobPostingBL, CancellationToken token = default)
    {
        return Results.Ok(await jobPostingBL.GetAllCandidates(id, phase, token));
    }
}