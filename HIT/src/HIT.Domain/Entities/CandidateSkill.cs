namespace HIT.Domain.Entities;

public sealed class CandidateSkill : BaseEntity
{
    private Candidate? candidate { get; set; }

    public Candidate Candidate
    {
        get => candidate ?? throw new InvalidOperationException(nameof(Candidate));
        set => candidate = value;
    }

    private string? skill { get; set; }

    public string Skill
    {
        get => skill ?? throw new InvalidOperationException(nameof(Skill));
        set => skill = value;
    }
}