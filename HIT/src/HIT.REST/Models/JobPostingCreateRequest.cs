using HIT.REST.Infrastructure.Entities;

namespace HIT.REST.Models;

public class JobPostingCreateRequest : JobPosting
{
    public List<int> Skills { get; set; }
}