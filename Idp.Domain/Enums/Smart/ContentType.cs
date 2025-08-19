using Idp.Domain.Enums.Smart.Base;

namespace Idp.Domain.Enums.Smart;

public sealed class ContentType(string value, int index) : SmartEnum<ContentType>(value, index)
{
    public static readonly ContentType Json = new ("application/json", 1);
    public static readonly ContentType Xml = new ("application/xml", 2);
    public static readonly ContentType FormUrlEncoded = new ("application/x-www-form-urlencoded", 2);
}