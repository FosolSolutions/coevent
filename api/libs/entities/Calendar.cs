namespace Coevent.Entities;

public class Calendar : AuditColumns
{
    #region Properties
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public CalendarType CalendarType { get; set; }

    public bool IsDisabled { get; set; }

    public long AccountId { get; set; }

    public Account? Account { get; set; }

    public CalendarStatus Status { get; set; }

    public ICollection<Participant> Participants { get; } = new List<Participant>();

    public ICollection<CalendarEvent> EventsManyToMany { get; } = new List<CalendarEvent>();

    public ICollection<Event> Events { get; } = new List<Event>();
    #endregion

    #region Constructors
    protected Calendar()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Account = null!;
    }

    public Calendar(string name, Account account, string createdBy) : base(createdBy)
    {
        this.Name = name;
        this.Description = String.Empty;
        this.CalendarType = CalendarType.Default;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
        this.Status = CalendarStatus.Draft;
    }

    public Calendar(string name, int accountId, string createdBy) : base(createdBy)
    {
        this.Name = name;
        this.Description = String.Empty;
        this.CalendarType = CalendarType.Default;
        this.AccountId = accountId;
        this.Status = CalendarStatus.Draft;
    }
    #endregion
}
