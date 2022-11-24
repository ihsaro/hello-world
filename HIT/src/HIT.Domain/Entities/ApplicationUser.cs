using HIT.Domain.Attributes;

namespace HIT.Domain.Entities;

public class ApplicationUser : BaseEntity
{
    private string? firstName { get; set; }

    public string FirstName
    {
        get => firstName ?? throw new InvalidOperationException(nameof(FirstName));
        set => firstName = value;
    }

    private string? lastName { get; set; }

    public string LastName
    {
        get => lastName ?? throw new InvalidOperationException(nameof(LastName));
        set => lastName = value;
    }

    private string? emailAddress { get; set; }

    public string EmailAddress
    {
        get => emailAddress ?? throw new InvalidOperationException(nameof(EmailAddress));
        set => emailAddress = value;
    }

    private string? username { get; set; }

    public string Username
    {
        get => username ?? throw new InvalidOperationException(nameof(Username));
        set => username = value;
    }

    private string? password { get; set; }

    public string Password
    {
        get => password ?? throw new InvalidOperationException(nameof(Password));
        set => password = value;
    }
}