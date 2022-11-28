namespace HIT.REST.Infrastructure.Entities;

public class JobPostingApplication : BaseEntity
{
    public JobPosting JobPosting { get; set; }

    public Candidate Candidate { get; set; }

    public int MatchRate { get; set; }

    public ApplicationPhase ApplicationPhase { get; set; }
    
    public List<JobPostingApplicationComment> JobPostingApplicationComments { get; set; }
}

public enum ApplicationPhase
{
    REJECTED = -1,
    ENTRY = 0,
    READY_FOR_TECHNICAL_INTERVIEW = 1,
    READY_FOR_HR_INTERVIEW = 2,
    READY_FOR_CONTRACT = 3,
}