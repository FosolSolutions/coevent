namespace Coevent.Entities;

public class Criteria : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public string Name { get; protected set; }

    public string Description { get; protected set; }

    public long AccountId { get; protected set; }

    public Account Account { get; protected set; }

    public ICollection<CriteriaTrait> CriteriaTraits { get; } = new List<CriteriaTrait>();

    public ICollection<OpeningCriteria> OpeningCriterias { get; } = new List<OpeningCriteria>();
    #endregion

    #region Constructors
    public Criteria(string name, Account account, string createdBy) : base(createdBy)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
    }
    #endregion
}