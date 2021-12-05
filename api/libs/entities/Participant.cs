namespace Coevent.Entities;

public class Participant : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public int CalendarId { get; set; }

    public Calendar? Calendar { get; set; }

    public long UserId { get; set; }

    public User? User { get; set; }

    public long TTL { get; set; }

    public DateTime? StartOn { get; set; }

    public DateTime? EndOn { get; set; }
    #endregion

    #region Constructors
    protected Participant()
    {
        this.Calendar = null!;
        this.User = null!;
    }

    public Participant(Calendar calendar, User user)
    {
        this.Calendar = calendar ?? throw new ArgumentNullException(nameof(calendar));
        this.CalendarId = calendar.Id;
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.UserId = user.Id;
    }

    public Participant(int calendarId, long userId)
    {
        this.CalendarId = calendarId;
        this.UserId = userId;
    }
    #endregion
}
