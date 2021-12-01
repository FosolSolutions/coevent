namespace Coevent.Core.Extensions;

public static class BooleanExtensions
{
    public static bool TryParseBoolean(this string value, bool defaultValue = default)
    {
        return Boolean.TryParse(value, out bool result) ? result : defaultValue;
    }
}
