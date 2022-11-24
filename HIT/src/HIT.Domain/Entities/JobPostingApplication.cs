namespace HIT.Domain.Entities;

public sealed class JobPostingApplication : BaseEntity
{
    private JobPosting? jobPosting { get; set; }

    public JobPosting JobPosting
    {
        get => jobPosting ?? throw new InvalidOperationException(nameof(JobPosting));
        set => jobPosting = value;
    }

    private Candidate? candidate { get; set; }

    public Candidate Candidate
    {
        get => candidate ?? throw new InvalidOperationException(nameof(Candidate));
        set => candidate = value;
    }
}