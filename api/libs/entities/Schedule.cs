namespace Coevent.Entities;

public class Schedule : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long AccountId { get; set; }

    public Account? Account { get; set; }

    public bool IsDisabled { get; set; }

    public TimeSpan StartOnTime { get; set; }

    public TimeSpan EndOnTime { get; set; }

    public DaysOfWeek DaysOfWeek { get; set; }

    public Months Months { get; set; }

    public RepeatType RepeatType { get; set; }

    public int RepeatSize { get; set; }

    public int DisplayOrder { get; set; }

    public ICollection<Event> Events { get; } = new List<Event>();
    #endregion

    #region Constructors
    protected Schedule()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Account = null!;
    }

    public Schedule(string name, Account account, TimeSpan startOnTime, TimeSpan endOnTime, string createdBy) : base(createdBy)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
        this.StartOnTime = startOnTime;
        this.EndOnTime = endOnTime;
        this.DaysOfWeek = DaysOfWeek.None;
        this.Months = Months.None;
        this.RepeatType = RepeatType.Never;
        this.RepeatSize = 0;
    }

    public Schedule(string name, long accountId, TimeSpan startOnTime, TimeSpan endOnTime, string createdBy) : base(createdBy)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.AccountId = accountId;
        this.StartOnTime = startOnTime;
        this.EndOnTime = endOnTime;
        this.DaysOfWeek = DaysOfWeek.None;
        this.Months = Months.None;
        this.RepeatType = RepeatType.Never;
        this.RepeatSize = 0;
    }
    #endregion
}
