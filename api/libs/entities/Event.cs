namespace Coevent.Entities;

public class Event : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public EventType EventType { get; set; }

    public bool IsDisabled { get; set; }

    public long AccountId { get; set; }

    public Account? Account { get; set; }

    public EventStatus Status { get; set; }

    public DateTime StartOn { get; set; }

    public DateTime EndOn { get; set; }

    public long? ScheduleId { get; set; }

    public Schedule? Schedule { get; set; }

    public int DisplayOrder { get; set; }

    public ICollection<CalendarEvent> CalendarsManyToMany { get; } = new List<CalendarEvent>();

    public ICollection<Calendar> Calendars { get; } = new List<Calendar>();

    public ICollection<EventOccurrence> Occurrences { get; } = new List<EventOccurrence>();

    public ICollection<Opening> Openings { get; } = new List<Opening>();
    #endregion

    #region Constructors
    protected Event()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Account = null!;
    }

    public Event(string name, Account account)
    {
        this.Name = name;
        this.Description = String.Empty;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
    }

    public Event(string name, long accountId)
    {
        this.Name = name;
        this.Description = String.Empty;
        this.AccountId = accountId;
    }
    #endregion
}
