using Coevent.Entities;

namespace Coevent.Api.Areas.Admin.Models
{
    public class ScheduleModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long AccountId { get; set; }

        public AccountModel? Account { get; set; }

        public bool IsDisabled { get; set; }

        public TimeSpan StartOnTime { get; set; }

        public TimeSpan EndOnTime { get; set; }

        public DaysOfWeek DaysOfWeek { get; set; }

        public Months Months { get; set; }

        public RepeatType RepeatType { get; set; }

        public int RepeatSize { get; set; }

        public int DisplayOrder { get; set; }

        public ICollection<EventModel> Events { get; } = new List<EventModel>();
    }
}
