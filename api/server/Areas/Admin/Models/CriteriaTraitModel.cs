using Coevent.Entities;

namespace Coevent.Api.Areas.Admin.Models
{
    public class CriteriaTraitModel
    {
        public long CriteriaId { get; set; }

        public CriteriaModel? Criteria { get; set; }

        public long TraitId { get; set; }

        public TraitModel? Trait { get; set; }

        public Formula Formula { get; set; }

        public string Value { get; set; }

        public bool IsRequired { get; set; }

        public bool IsDisabled { get; set; }
    }
}
