using HIT.REST.BL.Interfaces;
using HIT.REST.Infrastructure.Entities;
using HIT.REST.Models;
using HIT.REST.Routes.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace HIT.REST.Routes;

public sealed class JobPostingApplicationRoutes : IRoute
{
    public void ConfigureRoutes(WebApplication app)
    {
        app
            .MapGet("api/v1/job-posting-applications/{id}/{phase}", UpdateJobApplicationStatus)
            .AllowAnonymous();

        app
            .MapPost("api/v1/job-posting-applications/{id}", AddComment)
            .AllowAnonymous();

        app
            .MapGet("api/v1/job-posting-applications/{id}", GetAllComments)
            .AllowAnonymous();
    }

    private async Task<IResult> AddComment([FromRoute] int id, [FromBody] JobPostingApplicationCommentCreateRequest request, [FromServices] IJobPostingApplicationBL jobPostingApplicationBL)
    {
        return Results.Ok(await jobPostingApplicationBL.AddComment(id, request.Comment));
    }

    private async Task<IResult> GetAllComments([FromRoute] int id, [FromServices] IJobPostingApplicationBL jobPostingApplicationBL)
    {
        return Results.Ok(await jobPostingApplicationBL.GetAllComments(id));
    }

    private async Task<IResult> UpdateJobApplicationStatus([FromRoute] int id, [FromRoute] ApplicationPhase phase, [FromServices] IJobPostingApplicationBL jobPostingApplicationBL)
    {
        return Results.Ok(await jobPostingApplicationBL.UpdateJobApplicationStatus(id, phase));
    }
}