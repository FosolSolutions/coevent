namespace Coevent.Entities;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class AuditColumns
{
    #region Properties
    public DateTime CreatedOn { get; protected set; }

    public string CreatedBy { get; protected set; }

    public DateTime UpdatedOn { get; protected set; }

    public string UpdatedBy { get; protected set; }

    public byte[]? RowVersion { get; protected set; }
    #endregion

    #region Constructors
    public AuditColumns(string createdBy)
    {
        this.CreatedOn = new DateTime();
        this.CreatedBy = createdBy;
        this.UpdatedOn = new DateTime();
        this.UpdatedBy = createdBy;
    }
    #endregion
}