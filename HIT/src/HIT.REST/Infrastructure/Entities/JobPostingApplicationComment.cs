using System.Text.Json.Serialization;

namespace HIT.REST.Infrastructure.Entities;

public class JobPostingApplicationComment : BaseEntity
{
    [JsonIgnore]
    public JobPostingApplication JobPostingApplication { get; set; }

    public string Comment { get; set; }
}