namespace Coevent.Entities;

public class Calendar : AuditColumns
{
    #region Properties
    public int Id { get; protected set; }

    public string Name { get; protected set; }

    public string Description { get; protected set; }

    public CalendarType CalendarType { get; protected set; }

    public bool IsDisabled { get; protected set; }

    public long AccountId { get; protected set; }

    public Account Account { get; protected set; }

    public CalendarStatus Status { get; protected set; }

    public ICollection<Participant> Participants { get; } = new List<Participant>();
    #endregion

    #region Constructors
    public Calendar(string name, Account account, string createdOn) : base(createdOn)
    {
        this.Name = name;
        this.Description = String.Empty;
        this.CalendarType = CalendarType.Default;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = Account.Id;
        this.Status = CalendarStatus.Draft;
    }
    #endregion
}