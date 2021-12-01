using Coevent.Entities;

namespace Coevent.Api.Areas.Admin.Models
{
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

        public ICollection<AccountModel> Accounts { get; set; } = new List<AccountModel>();

        public ICollection<AccountModel> OwnerAccounts { get; set; } = new List<AccountModel>();

        public ICollection<ApplicationModel> Applications { get; set; } = new List<ApplicationModel>();

        public ICollection<ParticipantModel> Participants { get; set; } = new List<ParticipantModel>();

        public ICollection<RoleModel> Roles { get; set; } = new List<RoleModel>();

        public ICollection<UserClaimModel> Claims { get; set; } = new List<UserClaimModel>();
    }
}
