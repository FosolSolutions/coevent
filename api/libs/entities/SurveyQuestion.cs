namespace Coevent.Entities;

public class SurveyQuestion : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public long SurveyId { get; protected set; }

    public Survey Survey { get; protected set; }

    public string Question { get; protected set; }

    public bool IsDisabled { get; protected set; }

    public int DisplayOrder { get; protected set; }

    public bool IsRequired { get; protected set; }
    #endregion

    #region Constructors
    public SurveyQuestion(string question, Survey survey, string createdBy) : base(createdBy)
    {
        this.Question = question ?? throw new ArgumentNullException(nameof(question));
        this.Survey = survey ?? throw new ArgumentNullException(nameof(survey));
        this.SurveyId = survey.Id;
        this.IsRequired = true;
    }
    #endregion
}