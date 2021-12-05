namespace Coevent.Entities;

public class SurveyQuestion : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public long SurveyId { get; set; }

    public Survey? Survey { get; set; }

    public string Question { get; set; }

    public bool IsDisabled { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsRequired { get; set; }
    #endregion

    #region Constructors
    protected SurveyQuestion()
    {
        this.Survey = null!;
        this.Question = null!;
    }

    public SurveyQuestion(string question, Survey survey)
    {
        this.Question = question ?? throw new ArgumentNullException(nameof(question));
        this.Survey = survey ?? throw new ArgumentNullException(nameof(survey));
        this.SurveyId = survey.Id;
        this.IsRequired = true;
    }

    public SurveyQuestion(string question, long surveyId)
    {
        this.Question = question ?? throw new ArgumentNullException(nameof(question));
        this.SurveyId = surveyId;
        this.IsRequired = true;
    }
    #endregion
}
