namespace Coevent.Entities;

public class EventOccurrence : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long EventId { get; set; }

    public Event? Event { get; set; }

    public bool IsDisabled { get; set; }

    public EventStatus Status { get; set; }

    public DateTime StartOn { get; set; }

    public DateTime EndOn { get; set; }

    public int DisplayOrder { get; set; }

    public ICollection<OpeningOccurrence> OpeningOccurrences { get; } = new List<OpeningOccurrence>();
    #endregion

    #region Constructors
    protected EventOccurrence()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Event = null!;
    }

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

    public EventOccurrence(long parentId, string name, string createdBy) : base(createdBy)
    {
        this.EventId = parentId;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
    }
    #endregion
}
