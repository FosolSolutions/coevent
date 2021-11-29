namespace Coevent.Entities;

public class Participant : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public long CalendarId { get; protected set; }

    public Calendar Calendar { get; protected set; }

    public long UserId { get; protected set; }

    public User User { get; protected set; }

    public long TTL { get; protected set; }

    public DateTime? StartOn { get; protected set; }

    public DateTime? EndOn { get; protected set; }
    #endregion

    #region Constructors
    public Participant(Calendar calendar, User user, string createdBy) : base(createdBy)
    {
        this.Calendar = calendar ?? throw new ArgumentNullException(nameof(calendar));
        this.CalendarId = calendar.Id;
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.UserId = user.Id;
    }
    #endregion
}