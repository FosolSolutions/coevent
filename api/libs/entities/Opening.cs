namespace Coevent.Entities;

public class Opening : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public string Name { get; protected set; }

    public string Description { get; protected set; }

    public bool IsDisabled { get; protected set; }

    public long EventId { get; protected set; }

    public Event Event { get; protected set; }

    public int DisplayOrder { get; protected set; }

    public OpeningType OpeningType { get; protected set; }

    public ApplyType ApplyType { get; protected set; }

    public int Quantity { get; protected set; }

    public long? SurveyId { get; protected set; }

    public Survey? Survey { get; protected set; }

    public ICollection<OpeningCriteria> OpeningCriterias { get; } = new List<OpeningCriteria>();

    public ICollection<OpeningOccurrence> OpeningOccurrences { get; } = new List<OpeningOccurrence>();
    #endregion

    #region Constructors
    public Opening(string name, Event cevent, string createdBy) : base(createdBy)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.Event = cevent ?? throw new ArgumentNullException(nameof(cevent));
        this.EventId = cevent.Id;
        this.OpeningType = OpeningType.Default;
        this.ApplyType = ApplyType.Application;
    }
    #endregion
}