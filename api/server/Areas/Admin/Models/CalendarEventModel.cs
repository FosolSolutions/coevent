namespace Coevent.Api.Areas.Admin.Models
{
    public class CalendarEventModel
    {
        public int CalendarId { get; set; }

        public CalendarModel Calendar { get; set; }

        public long EventId { get; set; }

        public EventModel Event { get; set; }
    }
}
