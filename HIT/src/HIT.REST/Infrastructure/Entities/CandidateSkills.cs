using System.Text.Json.Serialization;

namespace HIT.REST.Infrastructure.Entities;

public class CandidateSkill : BaseEntity
{
    [JsonIgnore]
    public Candidate Candidate { get; set; } = null!;

    public string Skill { get; set; } = null!;
}