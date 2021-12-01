namespace Coevent.Entities;

public class CalendarEvent : AuditColumns
{
    #region Properties
    public int CalendarId { get; set; }

    public Calendar? Calendar { get; set; }

    public long EventId { get; set; }

    public Event? Event { get; set; }
    #endregion

    #region Constructors
    protected CalendarEvent()
    {
        this.Calendar = null!;
        this.Event = null!;
    }

    public CalendarEvent(Calendar calendar, Event cevent, string createdBy) : base(createdBy)
    {
        this.Calendar = calendar ?? throw new ArgumentNullException(nameof(calendar));
        this.CalendarId = calendar.Id;
        this.Event = cevent ?? throw new ArgumentNullException(nameof(cevent));
        this.EventId = cevent.Id;
    }

    public CalendarEvent(int calendarId, long ceventId, string createdBy) : base(createdBy)
    {
        this.CalendarId = calendarId;
        this.EventId = ceventId;
    }
    #endregion
}
