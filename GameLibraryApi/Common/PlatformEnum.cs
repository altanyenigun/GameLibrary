using System.ComponentModel;
using System.Text.Json.Serialization;

namespace GameLibraryApi.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PlatformEnum
    {
        PC=1,
        PS4,
        PS5,
        [Description("Xbox One")]
        XboxOne,
        [Description("Xbox Series X")]
        XboxSeriesX,
        Switch,
    }
}