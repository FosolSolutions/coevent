namespace Coevent.Api.Models;

public abstract class AuditColumnsModel
{
    public DateTime CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public string? RowVersion { get; set; }
}
