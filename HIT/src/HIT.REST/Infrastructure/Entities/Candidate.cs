namespace HIT.REST.Infrastructure.Entities;

public class Candidate : BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string EmailAddress { get; set; }

    public string LinkedInURL { get; set; }

    public CandidateType CandidateType { get; set; }

    public string CandidateLocation { get; set; }

    public int YearsOfExperience { get; set; }

    public IEnumerable<CandidateSkill> CandidateSkills { get; set; }
}

public enum CandidateType
{
    APPLIED,
    FUTURE,
    SEARCHED
}