namespace Coevent.Entities;

public class Event : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public string Name { get; protected set; }

    public string Description { get; protected set; }

    public EventType EventType { get; protected set; }

    public bool IsDisabled { get; protected set; }

    public long AccountId { get; protected set; }

    public Account Account { get; protected set; }

    public EventStatus Status { get; protected set; }

    public DateTime StartOn { get; protected set; }

    public DateTime EndOn { get; protected set; }

    public long? ScheduleId { get; protected set; }

    public Schedule? Schedule { get; protected set; }

    public int DisplayOrder { get; protected set; }

    public ICollection<EventOccurrence> Occurrences { get; } = new List<EventOccurrence>();

    public ICollection<Opening> Openings { get; } = new List<Opening>();
    #endregion

    #region Constructors
    public Event(string name, Account account, string createdBy) : base(createdBy)
    {
        this.Name = name;
        this.Description = String.Empty;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
    }
    #endregion
}