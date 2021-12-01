namespace Coevent.Entities;

public class OpeningOccurrence : AuditColumns
{
    #region Properties
    public long OpeningId { get; set; }

    public Opening? Opening { get; set; }

    public long EventOccurrenceId { get; set; }

    public EventOccurrence? EventOccurrence { get; set; }

    public OpeningStatus Status { get; set; }

    public ICollection<Application> Applications { get; } = new List<Application>();
    #endregion

    #region Constructors
    protected OpeningOccurrence()
    {
        this.Opening = null!;
        this.EventOccurrence = null!;
    }

    public OpeningOccurrence(Opening opening, EventOccurrence eventOccurrence, string createdBy) : base(createdBy)
    {
        this.Opening = opening ?? throw new ArgumentNullException(nameof(opening));
        this.OpeningId = opening.Id;
        this.EventOccurrence = eventOccurrence ?? throw new ArgumentNullException(nameof(eventOccurrence));
        this.EventOccurrenceId = eventOccurrence.Id;
        this.Status = OpeningStatus.Draft;
    }

    public OpeningOccurrence(long openingId, long eventOccurrenceId, string createdBy) : base(createdBy)
    {
        this.OpeningId = openingId;
        this.EventOccurrenceId = eventOccurrenceId;
        this.Status = OpeningStatus.Draft;
    }
    #endregion
}
