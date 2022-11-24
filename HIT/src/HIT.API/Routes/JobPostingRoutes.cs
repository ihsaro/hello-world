using HIT.API.Routes.Configuration;
using HIT.Domain.Entities;
using HIT.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HIT.API.Routes;

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
    }

    private async Task<IResult> Create(
        [FromBody] Request request,
        [FromServices] IGenericRepository<JobSkill> jobSkillRepository,
        [FromServices] IGenericRepository<JobPosting> jobPostingRepository,
        [FromServices] IGenericRepository<JobPostingSkill> jobPostingSkillRepository,
        CancellationToken token = default
    )
    {
        var result = await jobPostingRepository.Create(new JobPosting()
        {
            Title = request.Title,
            Description = request.Description,
            YearsOfExperience = request.YearsOfExperience,
            JobLocation = request.JobLocation,
            JobType = request.JobType,
            JobStatus = request.JobStatus
        }, token: token);

        if (request.Skills is not null)
        {
            request.Skills.ForEach(async skill =>
            {
                await jobPostingSkillRepository.Create(new JobPostingSkill()
                {
                    JobPosting = result,
                    JobSkill = await jobSkillRepository.GetById(skill)
                });
            });
        }

        return Results.Ok();
    }

    private async Task<IResult> GetAll(
        [FromServices] IGenericRepository<JobSkill> jobSkillRepository,
        [FromServices] IGenericRepository<JobPosting> jobPostingRepository,
        [FromServices] IGenericRepository<JobPostingSkill> jobPostingSkillRepository,
        CancellationToken token = default
    )
    {
        var result = await jobPostingRepository.GetAll(token: token);
        await jobSkillRepository.GetAll(token: token);

        var jobPostingSkills = await jobPostingSkillRepository.GetAll();

        var postings = new List<Response>();

        result.ToList().ForEach(r =>
        {
            var p = new Response()
            {
                Title = r.Title,
                Description = r.Description,
                YearsOfExperience = r.YearsOfExperience,
                JobLocation = r.JobLocation,
                JobType = r.JobType,
                JobStatus = r.JobStatus
            };

            p.JobSkills = jobPostingSkills.Where(x => x.JobPosting.Id == r.Id).Select(x => x.JobSkill).ToList();

            postings.Add(p);
        });

        return Results.Ok(postings);
    }

    private class Request : JobPosting
    {
        public List<int>? Skills { get; set; }
    }

    private class Response : JobPosting
    {
        public List<JobSkill>? JobSkills { get; set; }
    }
}
