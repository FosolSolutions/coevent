namespace Coevent.Api.Areas.Admin.Models
{
    public class UserClaimModel
    {
        public long UserId { get; set; }

        public UserModel? User { get; set; }

        public long AccountId { get; set; }

        public AccountModel? Account { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
