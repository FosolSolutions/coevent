namespace Coevent.Entities;

public class Survey : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public string Name { get; protected set; }

    public string Description { get; protected set; }

    public long AccountId { get; protected set; }

    public Account Account { get; protected set; }

    public bool IsDisabled { get; protected set; }

    public ICollection<Opening> Openings { get; } = new List<Opening>();

    public ICollection<SurveyQuestion> Questions { get; } = new List<SurveyQuestion>();
    #endregion

    #region Constructors
    public Survey(string name, Account account, string createdBy) : base(createdBy)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
    }
    #endregion
}