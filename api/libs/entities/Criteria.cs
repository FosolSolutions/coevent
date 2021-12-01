namespace Coevent.Entities;

public class Criteria : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long AccountId { get; set; }

    public Account? Account { get; set; }

    public ICollection<CriteriaTrait> CriteriaTraits { get; } = new List<CriteriaTrait>();

    public ICollection<OpeningCriteria> OpeningCriterias { get; } = new List<OpeningCriteria>();
    #endregion

    #region Constructors
    protected Criteria()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Account = null!;
    }

    public Criteria(string name, Account account, string createdBy) : base(createdBy)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
    }

    public Criteria(string name, long accountId, string createdBy) : base(createdBy)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.AccountId = accountId;
    }
    #endregion
}
