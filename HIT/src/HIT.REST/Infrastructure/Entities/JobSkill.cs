namespace HIT.REST.Infrastructure.Entities;

public class JobSkill : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public SkillCategory SkillCategory { get; set; }
}

public enum SkillCategory
{
    SOFT_SKILL,
    TECHNICAL,
    MANAGEMENT,
    LEADERSHIP
}