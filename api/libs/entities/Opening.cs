namespace Coevent.Entities;

public class Opening : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsDisabled { get; set; }

    public long EventId { get; set; }

    public Event? Event { get; set; }

    public int DisplayOrder { get; set; }

    public OpeningType OpeningType { get; set; }

    public ApplyType ApplyType { get; set; }

    public int Quantity { get; set; }

    public long? SurveyId { get; set; }

    public Survey? Survey { get; set; }

    public ICollection<OpeningCriteria> OpeningCriterias { get; } = new List<OpeningCriteria>();

    public ICollection<OpeningOccurrence> OpeningOccurrences { get; } = new List<OpeningOccurrence>();
    #endregion

    #region Constructors
    protected Opening()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Event = null!;
    }

    public Opening(string name, Event cevent, string createdBy) : base(createdBy)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.Event = cevent ?? throw new ArgumentNullException(nameof(cevent));
        this.EventId = cevent.Id;
        this.OpeningType = OpeningType.Default;
        this.ApplyType = ApplyType.Application;
    }

    public Opening(string name, long eventId, string createdBy) : base(createdBy)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
        this.EventId = eventId;
        this.OpeningType = OpeningType.Default;
        this.ApplyType = ApplyType.Application;
    }
    #endregion
}
