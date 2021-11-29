namespace Coevent.Entities;

public class OpeningOccurrence : AuditColumns
{
    #region Properties
    public long OpeningId { get; protected set; }

    public Opening Opening { get; protected set; }

    public long EventOccurrenceId { get; protected set; }

    public EventOccurrence EventOccurrence { get; protected set; }

    public OpeningStatus Status { get; protected set; }

    public ICollection<Application> Applications { get; } = new List<Application>();
    #endregion

    #region Constructors
    public OpeningOccurrence(Opening opening, EventOccurrence eventOccurrence, string createdBy) : base(createdBy)
    {
        this.Opening = opening ?? throw new ArgumentNullException(nameof(opening));
        this.OpeningId = opening.Id;
        this.EventOccurrence = eventOccurrence ?? throw new ArgumentNullException(nameof(eventOccurrence));
        this.EventOccurrence = eventOccurrence;
        this.Status = OpeningStatus.Draft;
    }
    #endregion
}