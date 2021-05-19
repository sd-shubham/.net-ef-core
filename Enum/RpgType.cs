using System.Text.Json.Serialization;

namespace CoreAPIAndEfCore.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgType
    {
        knigrht,
        mage,
        claric
    }
}