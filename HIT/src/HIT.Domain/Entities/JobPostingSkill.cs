namespace HIT.Domain.Entities;

public class JobPostingSkill : BaseEntity
{
    public JobPosting? JobPosting { get; set; }

    public JobSkill? JobSkill { get; set; }
}
