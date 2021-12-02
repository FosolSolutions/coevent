namespace Coevent.Api.Configuration;

/// <summary>
/// get/set -
/// </summary>
public class CoeventAuthenticationOptions
{
    #region  Properties
    /// <summary>
    /// get/set -
    /// </summary>
    public string? Salt { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string? Issuer { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string? Audience { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string? Secret { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public CookieOptions? Cookie { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public TimeSpan AccessTokenExpiresIn { get; set; } = new TimeSpan(0, 1, 0);

    /// <summary>
    /// get/set -
    /// </summary>
    public TimeSpan RefreshTokenExpiresIn { get; set; } = new TimeSpan(1, 0, 0);

    /// <summary>
    /// get/set -
    /// </summary>
    public string DefaultScope { get; set; } = "profile";
    #endregion
}
