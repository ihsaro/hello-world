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

        app
            .MapGet("api/v1/job-postings/{id}/candidates", GetAllCandidates)
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

        var jobSkills = await jobSkillRepository.GetAll(token: token);

        var p = new Response()
        {
            Id = result.Id,
            Title = result.Title,
            Description = result.Description,
            YearsOfExperience = result.YearsOfExperience,
            JobLocation = result.JobLocation,
            JobType = result.JobType,
            JobStatus = result.JobStatus
        };

        p.JobSkills = new List<JobSkill>();

        if (request.Skills is not null)
        {
            request.Skills.ForEach(skill =>
            {
                p.JobSkills.Add(jobSkills.First(x => x.Id == skill));
            });
        }

        return Results.Ok(p);
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
                Id = r.Id,
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

    public async Task<IResult> GetAllCandidates(
        [FromRoute] int id,
        [FromQuery] ApplicationPhase? phase,
        [FromServices] IGenericRepository<JobPostingApplication> repository,
        [FromServices] IGenericRepository<Candidate> candidateRepository,
        [FromServices] IGenericRepository<CandidateSkill> candidateSkillRepository,
        [FromServices] IGenericRepository<JobPosting> jobPostingrepository,
        [FromServices] IGenericRepository<JobPostingSkill> jobPostingSkillrepository,
        [FromServices] IGenericRepository<JobSkill> jobSkillrepository,
        CancellationToken token = default
    )
    {
        await jobSkillrepository.GetAll();
        var jobSkills = (await jobPostingSkillrepository.GetAll()).Select(x => x.JobSkill.Name);
        var candidates = await candidateRepository.GetAll();
        await jobPostingrepository.GetAll();

        var jobPostingApplications = await repository.GetAll();
        jobPostingApplications = jobPostingApplications.Where(x => x.JobPosting.Id == id);

        if (phase == null)
        {
            return Results.Ok(jobPostingApplications);
        }
        else
        {
            if (phase == ApplicationPhase.ENTRY)
            {
                List<int> ids = new List<int>();

                jobPostingApplications.ToList().ForEach(p =>
                {
                    ids.Add(p.Candidate.Id);
                });

                candidates.ToList().ForEach(async c =>
                {
                    if (!ids.Contains(c.Id))
                    {
                        var candidateSkills = (await candidateSkillRepository.GetAll()).Where(x => x.Candidate.Id == c.Id).Select(x => x.Skill);

                        int count = 0;

                        jobSkills.ToList().ForEach(x =>
                        {
                            if (candidateSkills.Contains(x))
                            {
                                count++;
                            }
                        });

                        int matchRate = (count / candidateSkills.Count()) * 100;

                        await repository.Create(new JobPostingApplication()
                        {
                            JobPosting = await jobPostingrepository.GetById(id),
                            Candidate = c,
                            ApplicationPhase = ApplicationPhase.ENTRY,
                            MatchRate = matchRate
                        });
                    }
                });
            }

            jobPostingApplications = (await repository.GetAll()).ToList().Where(x => x.ApplicationPhase == phase);
            return Results.Ok(jobPostingApplications);
        }
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
