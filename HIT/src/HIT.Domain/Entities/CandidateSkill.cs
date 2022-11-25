namespace HIT.Domain.Entities;

public class CandidateSkill : BaseEntity
{
    public Candidate Candidate
    {
        get;
        set;
    }

    public string Skill
    {
        get;
        set;
    }
}