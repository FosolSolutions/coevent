namespace Coevent.Entities;

public class Application : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public long UserId { get; protected set; }

    public User User { get; protected set; }

    public long OpeningId { get; protected set; }

    public long EventOccurrenceId { get; protected set; }

    public OpeningOccurrence OpeningOccurrence { get; protected set; }

    public ApplicationStatus Status { get; protected set; }
    #endregion

    #region Constructors
    public Application(User user, OpeningOccurrence openingOccurrence, string createdBy) : base(createdBy)
    {
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.UserId = user.Id;
        this.OpeningOccurrence = openingOccurrence ?? throw new ArgumentNullException(nameof(openingOccurrence));
        this.OpeningId = openingOccurrence.OpeningId;
        this.EventOccurrenceId = openingOccurrence.EventOccurrenceId;
        this.Status = ApplicationStatus.Submitted;
    }
    #endregion
}