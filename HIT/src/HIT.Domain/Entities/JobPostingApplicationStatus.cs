namespace HIT.Domain.Entities;

public sealed class JobPostingApplicationStatus : BaseEntity
{
    private JobPostingApplication? jobPostingApplication { get; set; }

    public JobPostingApplication JobPostingApplication
    {
        get => jobPostingApplication ?? throw new InvalidOperationException(nameof(JobPostingApplication));
        set => jobPostingApplication = value;
    }

    public string? Comment { get; set; }

    public ApplicationPhase ApplicationPhase { get; set; }
}

public enum ApplicationPhase
{
    READY_FOR_INTERVIEW,
    REJECTED
}