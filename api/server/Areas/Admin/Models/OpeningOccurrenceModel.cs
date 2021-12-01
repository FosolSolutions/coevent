using Coevent.Entities;

namespace Coevent.Api.Areas.Admin.Models
{
    public class OpeningOccurrenceModel
    {
        public long OpeningId { get; set; }

        public OpeningModel? Opening { get; set; }

        public long EventOccurrenceId { get; set; }

        public EventOccurrenceModel? EventOccurrence { get; set; }

        public OpeningStatus Status { get; set; }

        public ICollection<ApplicationModel> Applications { get; set; } = new List<ApplicationModel>();
    }
}
