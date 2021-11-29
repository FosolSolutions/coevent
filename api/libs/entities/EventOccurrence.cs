namespace Coevent.Entities;

public class EventOccurrence : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public string Name { get; protected set; }

    public string Description { get; protected set; }

    public long EventId { get; protected set; }

    public Event Event { get; protected set; }

    public bool IsDisabled { get; protected set; }

    public EventStatus Status { get; protected set; }

    public DateTime StartOn { get; protected set; }

    public DateTime EndOn { get; protected set; }

    public int DisplayOrder { get; protected set; }

    public ICollection<OpeningOccurrence> OpeningOccurrences { get; } = new List<OpeningOccurrence>();
    #endregion

    #region Constructors
    public EventOccurrence(Event parent, string createdBy) : base(createdBy)
    {
        this.Event = parent ?? throw new ArgumentNullException(nameof(parent));
        this.EventId = parent.Id;
        this.Name = parent.Name;
        this.Description = parent.Description;
        this.IsDisabled = parent.IsDisabled;
        this.Status = parent.Status;
        this.StartOn = parent.StartOn;
        this.EndOn = parent.EndOn;
        this.DisplayOrder = parent.DisplayOrder;
    }
    #endregion
}