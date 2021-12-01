namespace Coevent.Api.Areas.Admin.Models
{
    public class ParticipantModel
    {
        public long Id { get; set; }

        public int CalendarId { get; set; }

        public CalendarModel? Calendar { get; set; }

        public long UserId { get; set; }

        public UserModel? User { get; set; }

        public long TTL { get; set; }

        public DateTime? StartOn { get; set; }

        public DateTime? EndOn { get; set; }
    }
}
