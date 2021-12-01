using Coevent.Entities;

namespace Coevent.Api.Areas.Admin.Models
{
    public class OpeningModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDisabled { get; set; }

        public long EventId { get; set; }

        public EventModel? Event { get; set; }

        public int DisplayOrder { get; set; }

        public OpeningType OpeningType { get; set; }

        public ApplyType ApplyType { get; set; }

        public int Quantity { get; set; }

        public long? SurveyId { get; set; }

        public SurveyModel? Survey { get; set; }

        public ICollection<OpeningCriteriaModel> OpeningCriterias { get; set; } = new List<OpeningCriteriaModel>();

        public ICollection<OpeningOccurrenceModel> OpeningOccurrences { get; set; } = new List<OpeningOccurrenceModel>();
    }
}
