namespace Coevent.Api.Models.Tokens;

/// <summary>
/// RequestModel class, provides a model that authenticates a participant key.
/// </summary>
public class RequestModel
{
    #region Properties
    /// <summary>
    /// The participant key to identify the user with.
    /// </summary>
    public Guid Key { get; set; }
    #endregion
}
