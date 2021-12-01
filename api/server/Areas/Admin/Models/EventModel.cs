using Coevent.Entities;

namespace Coevent.Api.Areas.Admin.Models
{
    public class EventModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public EventType EventType { get; set; }

        public bool IsDisabled { get; set; }

        public long AccountId { get; set; }

        public AccountModel? Account { get; set; }

        public EventStatus Status { get; set; }

        public DateTime StartOn { get; set; }

        public DateTime EndOn { get; set; }

        public long? ScheduleId { get; set; }

        public ScheduleModel? Schedule { get; set; }

        public int DisplayOrder { get; set; }

        public ICollection<CalendarModel> Calendars { get; set; } = new List<CalendarModel>();

        public ICollection<EventOccurrenceModel> Occurrences { get; set; } = new List<EventOccurrenceModel>();

        public ICollection<OpeningModel> Openings { get; set; } = new List<OpeningModel>();
    }
}
