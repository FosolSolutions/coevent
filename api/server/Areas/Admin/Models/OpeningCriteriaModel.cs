namespace Coevent.Api.Areas.Admin.Models
{
    public class OpeningCriteriaModel
    {
        public long OpeningId { get; set; }

        public OpeningModel? Opening { get; set; }

        public long CriteriaId { get; set; }

        public CriteriaModel? Criteria { get; set; }

        public long TraitId { get; set; }

        public TraitModel? Trait { get; set; }
    }
}
