namespace Coevent.Entities;

public class Schedule : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public string Name { get; protected set; }

    public string Description { get; protected set; }

    public long AccountId { get; protected set; }

    public Account Account { get; protected set; }

    public bool IsDisabled { get; protected set; }

    public DateTime StartOnTime { get; protected set; }

    public DateTime EndOnTime { get; protected set; }

    public DaysOfWeek DaysOfWeek { get; protected set; }

    public Months Months { get; protected set; }

    public RepeatType RepeatType { get; protected set; }

    public int RepeatSize { get; protected set; }

    public int DisplayOrder { get; protected set; }

    public ICollection<Event> Events { get; } = new List<Event>();
    #endregion

    #region Constructors
    public Schedule(string name, Account account, DateTime startOnTime, DateTime endOnTime, string createdBy) : base(createdBy)
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
    #endregion
}