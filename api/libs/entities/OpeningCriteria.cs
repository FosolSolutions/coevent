namespace Coevent.Entities;

public class OpeningCriteria : AuditColumns
{
    #region Properties
    public long OpeningId { get; protected set; }

    public Opening Opening { get; protected set; }

    public long CriteriaId { get; protected set; }

    public Criteria Criteria { get; protected set; }

    public long TraitId { get; protected set; }

    public Trait Trait { get; protected set; }
    #endregion

    #region Constructors
    public OpeningCriteria(Opening opening, Criteria criteria, Trait trait, string createdBy) : base(createdBy)
    {
        this.Opening = opening ?? throw new ArgumentNullException(nameof(opening));
        this.OpeningId = opening.Id;
        this.Criteria = criteria ?? throw new ArgumentNullException(nameof(criteria));
        this.CriteriaId = criteria.Id;
        this.Trait = trait ?? throw new ArgumentNullException(nameof(trait));
        this.TraitId = trait.Id;
    }
    #endregion
}