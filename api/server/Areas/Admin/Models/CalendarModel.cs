using Coevent.Entities;

namespace Coevent.Api.Areas.Admin.Models
{
    public class CalendarModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CalendarType CalendarType { get; set; }

        public bool IsDisabled { get; set; }

        public long AccountId { get; set; }

        public AccountModel? Account { get; set; }

        public CalendarStatus Status { get; set; }

        public ICollection<ParticipantModel> Participants { get; set; } = new List<ParticipantModel>();

        public ICollection<EventModel> Events { get; set; } = new List<EventModel>();
    }
}
