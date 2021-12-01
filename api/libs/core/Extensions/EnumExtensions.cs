namespace Coevent.Core.Extensions;

public static class EnumExtensions
{
    public static TEnum TryParseEnum<TEnum>(this string value, TEnum defaultValue = default)
         where TEnum : struct
    {
        return Enum.TryParse<TEnum>(value, out TEnum result) ? result : defaultValue;
    }
}
