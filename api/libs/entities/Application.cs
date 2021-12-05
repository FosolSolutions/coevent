namespace Coevent.Entities;

public class Application : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public long UserId { get; set; }

    public User? User { get; set; }

    public long OpeningId { get; set; }

    public long EventOccurrenceId { get; set; }

    public OpeningOccurrence? OpeningOccurrence { get; set; }

    public ApplicationStatus? Status { get; set; }
    #endregion

    #region Constructors
    protected Application()
    {
        this.User = null!;
        this.OpeningOccurrence = null!;
    }

    public Application(User user, OpeningOccurrence openingOccurrence)
    {
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.UserId = user.Id;
        this.OpeningOccurrence = openingOccurrence ?? throw new ArgumentNullException(nameof(openingOccurrence));
        this.OpeningId = openingOccurrence.OpeningId;
        this.EventOccurrenceId = openingOccurrence.EventOccurrenceId;
        this.Status = ApplicationStatus.Submitted;
    }

    public Application(long userId, long openingId, long eventOccurrenceId)
    {
        this.UserId = userId;
        this.OpeningId = openingId;
        this.EventOccurrenceId = eventOccurrenceId;
        this.Status = ApplicationStatus.Submitted;
    }
    #endregion
}
