namespace HIT.REST.Infrastructure.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedTimestamp { get; set; }
    public DateTime LastUpdatedTimestamp { get; set; }
}