namespace Coevent.Dal.Security;

public static class CoeventIssuer
{
    public const string Issuer = "coevent";
    public const string OriginalIssuer = "coevent";

    public static string Account(long id)
    {
        return $"account:{id}";
    }
}
