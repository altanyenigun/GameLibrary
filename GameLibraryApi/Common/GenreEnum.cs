using System.ComponentModel;
using System.Text.Json.Serialization;

namespace GameLibraryApi.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenreEnum
    {
        Action=1,
        Adventure,
        Fantasy,
        [Description("Role-Playing")]
        RolePlaying,
        [Description("Western-Style")]
        WesternStyle,
        [Description("Open-World")]
        OpenWorld,
        Shooter,
        [Description("Action-Adventure")]
        ActionAdventure
    }
}