using HIT.API.Routes.Configuration;
using HIT.Domain.Entities;
using HIT.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HIT.API.Routes;

public sealed class JobPostingApplicationRoutes : IRoute
{
    public void ConfigureRoutes(WebApplication app)
    {
        app
            .MapPut("api/v1/job-posting-applications/{id}/{phase}", UpdateJobApplicationStatus)
            .AllowAnonymous();
    }

    public async Task<IResult> UpdateJobApplicationStatus(
        int id,
        ApplicationPhase phase,
        [FromServices] IGenericRepository<JobPostingApplication> jobPostingApplicationRepository
    )
    {
        var jobPostingApplication = await jobPostingApplicationRepository.GetById(id);
        jobPostingApplication.ApplicationPhase = phase;

        await jobPostingApplicationRepository.Update(jobPostingApplication);

        return Results.Ok(jobPostingApplication);
    }
}
