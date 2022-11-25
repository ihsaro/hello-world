using System.Text.Json.Serialization;

namespace HIT.Domain.Entities;

public class CandidateSkill : BaseEntity
{
    [JsonIgnore]
    public Candidate Candidate
    {
        get;
        set;
    }

    public string Skill
    {
        get;
        set;
    }
}