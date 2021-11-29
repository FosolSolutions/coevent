namespace Coevent.Entities;

public class CriteriaTrait : AuditColumns
{
    #region Properties
    public long CriteriaId { get; protected set; }

    public Criteria Criteria { get; protected set; }

    public long TraitId { get; protected set; }

    public Trait Trait { get; protected set; }

    public Formula Formula { get; protected set; }

    public string Value { get; protected set; }

    public bool IsRequired { get; protected set; }

    public bool IsDisabled { get; protected set; }
    #endregion

    #region Constructors
    public CriteriaTrait(Criteria criteria, Trait trait, Formula formula, string value, string createdBy) : base(createdBy)
    {
        this.Criteria = criteria ?? throw new ArgumentNullException(nameof(criteria));
        this.CriteriaId = criteria.Id;
        this.Trait = trait ?? throw new ArgumentNullException(nameof(trait));
        this.TraitId = trait.Id;
        this.Formula = formula;
        this.Value = value;
        this.IsRequired = true;
    }
    #endregion
}