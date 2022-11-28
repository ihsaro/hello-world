using HIT.REST.BL.Interfaces;
using HIT.REST.Infrastructure.Entities;
using HIT.REST.Infrastructure.Persistence;
using HIT.REST.Models;
using Microsoft.EntityFrameworkCore;

namespace HIT.REST.BL;

public class JobPostingBL : IJobPostingBL
{
    private readonly ApplicationDbContext context;

    public JobPostingBL(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<JobPostingCreateResponse> Create(JobPostingCreateRequest request, CancellationToken token = default)
    {
        var entity = new JobPosting()
        {
            Title = request.Title,
            Description = request.Description,
            YearsOfExperience = request.YearsOfExperience,
            JobLocation = request.JobLocation,
            JobType = request.JobType,
            JobStatus = request.JobStatus
        };

        context.Add(entity);

        if (request.Skills is not null)
        {
            request.Skills.ForEach(id =>
            {
                context.Add(new JobPostingSkill()
                {
                    JobPosting = entity,
                    JobSkill = context.JobSkills.First(x => x.Id == id)
                });
            });
        }

        await context.SaveChangesAsync(cancellationToken: token);

        var jobSkills = context.JobSkills.ToList();

        var response = new JobPostingCreateResponse()
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            YearsOfExperience = entity.YearsOfExperience,
            JobLocation = entity.JobLocation,
            JobType = entity.JobType,
            JobStatus = entity.JobStatus
        };

        response.JobSkills = new List<JobSkill>();

        if (request.Skills is not null)
        {
            request.Skills.ForEach(id =>
            {
                response.JobSkills.Add(jobSkills.First(x => x.Id == id));
            });
        }

        return response;
    }

    public async Task<IEnumerable<JobPostingCreateResponse>> GetAll(CancellationToken token = default)
    {
        var postings = await context.JobPostings.OrderByDescending(x => x.LastUpdatedTimestamp).ToListAsync(cancellationToken: token);

        var jobPostingSkills = context.JobPostingSkills;

        var responses = new List<JobPostingCreateResponse>();

        postings.ToList().ForEach(response =>
        {
            var posting = new JobPostingCreateResponse()
            {
                Id = response.Id,
                Title = response.Title,
                Description = response.Description,
                YearsOfExperience = response.YearsOfExperience,
                JobLocation = response.JobLocation,
                JobType = response.JobType,
                JobStatus = response.JobStatus
            };

            posting.JobSkills = jobPostingSkills.Where(x => x.JobPosting.Id == response.Id).Include(x => x.JobSkill).Select(x => x.JobSkill).ToList();

            responses.Add(posting);
        });

        return responses;
    }

    public async Task<IEnumerable<JobPostingApplication>> GetAllCandidates(int id, ApplicationPhase? phase, CancellationToken token = default)
    {
        var jobSkills = (await context.JobPostingSkills.Include(x => x.JobSkill).Include(x => x.JobPosting).Where(x => x.JobPosting.Id == id).ToListAsync()).Select(x => x.JobSkill.Name);
        var candidates = context.Candidates.ToList();

        var jobPostingApplications = context.JobPostingApplications.Include(x => x.JobPosting).Include(x => x.Candidate).Include(x => x.Candidate.CandidateSkills).Where(x => x.JobPosting.Id == id).ToList();

        if (phase == null)
        {
            return jobPostingApplications;
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

                candidates.ToList().ForEach(c =>
                {
                    if (!ids.Contains(c.Id))
                    {
                        var candidateSkills = context.CandidateSkills.Include(x => x.Candidate).Where(x => x.Candidate.Id == c.Id).Select(x => x.Skill);

                        int count = 0;

                        jobSkills.ToList().ForEach(x =>
                        {
                            if (candidateSkills.Contains(x))
                            {
                                count++;
                            }
                        });

                        double matchRate = ((double) count / (double) jobSkills.Count()) * 100;

                        if (matchRate != 0)
                        {
                            context.Add(new JobPostingApplication()
                            {
                                JobPosting = context.JobPostings.First(x => x.Id == id),
                                Candidate = c,
                                ApplicationPhase = ApplicationPhase.ENTRY,
                                MatchRate = (int) matchRate
                            });
                        }
                    }
                });

                await context.SaveChangesAsync(cancellationToken: token);
            }

            return context.JobPostingApplications.Include(x => x.JobPosting).Include(x => x.Candidate).Include(x => x.Candidate.CandidateSkills).Where(x => x.JobPosting.Id == id && x.ApplicationPhase == phase).ToList();
        }
    }
}