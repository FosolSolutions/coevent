namespace Coevent.Api.Areas.Admin.Models
{
    public class ClaimModel
    {
        public long Id { get; set; }

        public long AccountId { get; set; }

        public AccountModel? Account { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }

        public ICollection<RoleModel> Roles { get; } = new List<RoleModel>();
    }
}
