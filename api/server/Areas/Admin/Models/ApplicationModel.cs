using Coevent.Entities;

namespace Coevent.Api.Areas.Admin.Models
{
    public class ApplicationModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public UserModel? User { get; set; }

        public long OpeningId { get; set; }

        public long EventOccurrenceId { get; set; }

        public OpeningOccurrenceModel? OpeningOccurrence { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
