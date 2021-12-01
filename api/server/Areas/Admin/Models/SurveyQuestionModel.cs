namespace Coevent.Api.Areas.Admin.Models
{
    public class SurveyQuestionModel
    {
        public long Id { get; set; }

        public long SurveyId { get; set; }

        public SurveyModel? Survey { get; set; }

        public string Question { get; set; }

        public bool IsDisabled { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsRequired { get; set; }
    }
}
