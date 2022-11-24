namespace HIT.Application.Models;

public class CreateCandidateResponse : CreateCandidateRequest
{
    public int Id { get; set; }
    public DateTime CreatedTimestamp { get; set; }
    public DateTime LastUpdatedTimestamp { get; set; }
}