namespace HIT.Domain.Entities;

public sealed class JobPosting : BaseEntity
{
    private string? title { get; set; }

    public string Title
    {
        get => title ?? throw new InvalidOperationException(nameof(Title));
        set => title = value;
    }

    private string? description { get; set; }

    public string Description
    {
        get => description ?? throw new InvalidOperationException(nameof(Description));
        set => description = value;
    }

    public int YearsOfExperience { get; set; }
    public JobLocation JobLocation { get; set; }

    public JobType JobType { get; set; }

    public JobStatus JobStatus { get; set; }
}

public enum JobLocation
{
    MAURITIUS,
    POLAND,
    ENGLAND,
    GERMANY,
    REMOTE
}

public enum JobType
{
    DEV,
    HR,
    PM
}

public enum JobStatus
{
    OPEN,
    CLOSED
}