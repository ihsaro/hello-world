namespace HIT.Domain.Entities;

public class CandidateCertification : BaseEntity
{
    private Candidate? candidate { get; set; }

    public Candidate Candidate
    {
        get => candidate ?? throw new InvalidOperationException(nameof(Candidate));
        set => candidate = value;
    }

    private string? certification { get; set; }

    public string Certification
    {
        get => certification ?? throw new InvalidOperationException(nameof(Certification));
        set => certification = value;
    }
}