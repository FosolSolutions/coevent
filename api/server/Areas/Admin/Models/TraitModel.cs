namespace Coevent.Api.Areas.Admin.Models
{
    public class TraitModel
    {
        public long Id { get; set; }

        public long AccountId { get; set; }

        public AccountModel? Account { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDisabled { get; set; }

        public ICollection<CriteriaTraitModel> CriteriaTraits { get; set; } = new List<CriteriaTraitModel>();

        public ICollection<OpeningCriteriaModel> OpeningCriterias { get; set; } = new List<OpeningCriteriaModel>();
    }
}
