using Coevent.Entities;

namespace Coevent.Api.Areas.Admin.Models
{
    public class EventOccurrenceModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long EventId { get; set; }

        public EventModel? Event { get; set; }

        public bool IsDisabled { get; set; }

        public EventStatus Status { get; set; }

        public DateTime StartOn { get; set; }

        public DateTime EndOn { get; set; }

        public int DisplayOrder { get; set; }

        public ICollection<OpeningOccurrenceModel> OpeningOccurrences { get; } = new List<OpeningOccurrenceModel>();
    }
}
