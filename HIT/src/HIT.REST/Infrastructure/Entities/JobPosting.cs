namespace HIT.REST.Infrastructure.Entities;

public class JobPosting : BaseEntity
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

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