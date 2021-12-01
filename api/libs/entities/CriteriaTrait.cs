namespace Coevent.Entities;

public class CriteriaTrait : AuditColumns
{
    #region Properties
    public long CriteriaId { get; set; }

    public Criteria? Criteria { get; set; }

    public long TraitId { get; set; }

    public Trait? Trait { get; set; }

    public Formula Formula { get; set; }

    public string Value { get; set; }

    public bool IsRequired { get; set; }

    public bool IsDisabled { get; set; }
    #endregion

    #region Constructors
    protected CriteriaTrait()
    {
        this.Criteria = null!;
        this.Trait = null!;
        this.Value = String.Empty;
    }

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

    public CriteriaTrait(long criteriaId, long traitId, Formula formula, string value, string createdBy) : base(createdBy)
    {
        this.CriteriaId = criteriaId;
        this.TraitId = traitId;
        this.Formula = formula;
        this.Value = value;
        this.IsRequired = true;
    }
    #endregion
}
