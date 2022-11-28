using HIT.REST.Infrastructure.Entities;

namespace HIT.REST.Models;

public class JobPostingCreateResponse : JobPosting
{
    public List<JobSkill> JobSkills { get; set; }
}