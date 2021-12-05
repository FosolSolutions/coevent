namespace Coevent.Entities;

public class OpeningCriteria : AuditColumns
{
    #region Properties
    public long OpeningId { get; set; }

    public Opening? Opening { get; set; }

    public long CriteriaId { get; set; }

    public Criteria? Criteria { get; set; }

    public long TraitId { get; set; }

    public Trait? Trait { get; set; }
    #endregion

    #region Constructors
    protected OpeningCriteria()
    {
        this.Opening = null!;
        this.Criteria = null!;
        this.Trait = null!;
    }

    public OpeningCriteria(Opening opening, Criteria criteria, Trait trait)
    {
        this.Opening = opening ?? throw new ArgumentNullException(nameof(opening));
        this.OpeningId = opening.Id;
        this.Criteria = criteria ?? throw new ArgumentNullException(nameof(criteria));
        this.CriteriaId = criteria.Id;
        this.Trait = trait ?? throw new ArgumentNullException(nameof(trait));
        this.TraitId = trait.Id;
    }

    public OpeningCriteria(long openingId, long criteriaId, long traitId)
    {
        this.OpeningId = openingId;
        this.CriteriaId = criteriaId;
        this.TraitId = traitId;
    }
    #endregion
}
