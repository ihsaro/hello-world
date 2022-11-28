namespace HIT.REST.Infrastructure.Entities;

public class CandidateSkill : BaseEntity
{
    public Candidate Candidate { get; set; } = null!;

    public string Skill { get; set; } = null!;
}