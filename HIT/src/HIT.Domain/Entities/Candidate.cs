using HIT.Domain.Attributes;

namespace HIT.Domain.Entities;

public class Candidate : BaseEntity
{
    private string? firstName { get; set; }

    public string FirstName
    {
        get => firstName ?? throw new InvalidOperationException(nameof(FirstName));
        set => firstName = value;
    }

    private string? lastName { get; set; }

    public string LastName
    {
        get => lastName ?? throw new InvalidOperationException(nameof(LastName));
        set => lastName = value;
    }

    private string? emailAddress { get; set; }

    public string EmailAddress
    {
        get => emailAddress ?? throw new InvalidOperationException(nameof(EmailAddress));
        set => emailAddress = value;
    }

    private string? linkedInURL { get; set; }

    public string LinkedInURL
    {
        get => linkedInURL ?? throw new InvalidOperationException(nameof(LinkedInURL));
        set => linkedInURL = value;
    }

    public CandidateType CandidateType { get; set; }

    private string? candidateLocation { get; set; }

    public string CandidateLocation
    {
        get => candidateLocation ?? throw new InvalidOperationException(nameof(CandidateLocation));
        set => candidateLocation = value;
    }

    public int YearsOfExperience { get; set; }
}

public enum CandidateType
{
    APPLIED,
    FUTURE,
    SEARCHED
}