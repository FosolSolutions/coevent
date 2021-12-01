namespace Coevent.Api.Areas.Admin.Models
{
    public class SurveyModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long AccountId { get; set; }

        public AccountModel? Account { get; set; }

        public bool IsDisabled { get; set; }

        public ICollection<OpeningModel> Openings { get; set; } = new List<OpeningModel>();

        public ICollection<SurveyQuestionModel> Questions { get; set; } = new List<SurveyQuestionModel>();
    }
}
