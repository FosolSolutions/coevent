namespace Coevent.Api.Models.Tokens;

using Coevent.Entities;

public class UserModel
{
    public long Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public Guid Key { get; set; }

    public string DisplayName { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public bool IsDisabled { get; set; }

    public int FailedLogins { get; set; }

    public UserType UserType { get; set; }

    public bool IsVerified { get; set; }

    public DateTime? VerifiedOn { get; set; }

    public ICollection<string> Roles { get; set; } = new List<string>();

    public ICollection<KeyValuePair<string, string>> Claims { get; set; } = new List<KeyValuePair<string, string>>();
}
