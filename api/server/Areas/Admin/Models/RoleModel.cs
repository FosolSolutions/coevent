namespace Coevent.Api.Areas.Admin.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        public long AccountId { get; set; }

        public AccountModel? Account { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDisabled { get; set; }

        public ICollection<UserModel> Users { get; set; } = new List<UserModel>();

        public ICollection<ClaimModel> Claims { get; set; } = new List<ClaimModel>();
    }
}
