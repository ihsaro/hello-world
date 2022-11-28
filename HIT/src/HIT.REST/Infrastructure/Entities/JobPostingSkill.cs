namespace HIT.REST.Infrastructure.Entities;

public class JobPostingSkill : BaseEntity
{
    public JobPosting JobPosting { get; set; } = null!;

    public JobSkill JobSkill { get; set; } = null!;
}