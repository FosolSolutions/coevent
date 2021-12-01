namespace Coevent.Entities;

using System;

public abstract class AuditColumns
{
    #region Properties
    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; }

    public DateTime UpdatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public byte[]? RowVersion { get; set; }
    #endregion

    #region Constructors
    protected AuditColumns()
    {
        this.CreatedBy = String.Empty;
        this.UpdatedBy = String.Empty;
    }

    public AuditColumns(string createdBy)
    {
        this.CreatedOn = new DateTime();
        this.CreatedBy = createdBy;
        this.UpdatedOn = new DateTime();
        this.UpdatedBy = createdBy;
    }
    #endregion
}
