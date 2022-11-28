namespace HIT.REST.Infrastructure.Entities;

public class JobPostingApplicationComment : BaseEntity
{
    public JobPostingApplication JobPostingApplication { get; set; }

    public string Comment { get; set; }
}