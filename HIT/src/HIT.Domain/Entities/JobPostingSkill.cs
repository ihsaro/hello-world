namespace HIT.Domain.Entities;

public sealed class JobPostingSkill : BaseEntity
{
    private JobPosting? jobPosting { get; set; }

    public JobPosting JobPosting
    {
        get => jobPosting ?? throw new InvalidOperationException(nameof(JobPosting));
        set => jobPosting = value;
    }

    private JobSkill? jobSkill { get; set; }

    public JobSkill JobSkill
    {
        get => jobSkill ?? throw new InvalidOperationException(nameof(JobSkill));
        set => jobSkill = value;
    }

    public ProficiencyLevel ProficiencyLevel { get; set; }
}

public enum ProficiencyLevel
{
    BEGINNER = 1,
    INTERMEDIATE = 2,
    ADVANCED = 3
}