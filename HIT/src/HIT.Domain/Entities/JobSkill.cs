using HIT.Domain.Attributes;

namespace HIT.Domain.Entities;

public class JobSkill : BaseEntity
{
    private string? name { get; set; }

    [Anonymize]
    public string Name
    {
        get => name ?? throw new InvalidOperationException(nameof(Name));
        set => name = value;
    }

    [Anonymize]
    public string? Description { get; set; }

    public SkillCategory SkillCategory { get; set; }
}

public enum SkillCategory
{
    SOFT_SKILL,
    TECHNICAL,
    MANAGEMENT,
    LEADERSHIP
}
