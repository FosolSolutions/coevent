namespace Coevent.Entities;

public class Survey : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long AccountId { get; set; }

    public Account? Account { get; set; }

    public bool IsDisabled { get; set; }

    public ICollection<Opening> Openings { get; } = new List<Opening>();

    public ICollection<SurveyQuestion> Questions { get; } = new List<SurveyQuestion>();
    #endregion

    #region Constructors
    protected Survey()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Account = null!;
    }

    public Survey(string name, Account account)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
    }

    public Survey(string name, long accountId)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.AccountId = accountId;
    }
    #endregion
}
