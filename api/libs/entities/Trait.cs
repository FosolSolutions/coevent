namespace Coevent.Entities;

public class Trait : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public long AccountId { get; set; }

    public Account? Account { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsDisabled { get; set; }

    public ICollection<CriteriaTrait> CriteriaTraits { get; } = new List<CriteriaTrait>();

    public ICollection<OpeningCriteria> OpeningCriterias { get; } = new List<OpeningCriteria>();
    #endregion

    #region Constructors
    protected Trait()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Account = null!;
    }

    public Trait(string name, Account account)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
    }

    public Trait(string name, long accountId)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.AccountId = accountId;
    }
    #endregion
}
