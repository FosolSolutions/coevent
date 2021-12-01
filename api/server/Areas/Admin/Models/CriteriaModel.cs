namespace Coevent.Api.Areas.Admin.Models
{
    public class CriteriaModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long AccountId { get; set; }

        public AccountModel? Account { get; set; }

        public ICollection<CriteriaTraitModel> CriteriaTraits { get; set; } = new List<CriteriaTraitModel>();

        public ICollection<OpeningCriteriaModel> OpeningCriterias { get; set; } = new List<OpeningCriteriaModel>();
    }
}
