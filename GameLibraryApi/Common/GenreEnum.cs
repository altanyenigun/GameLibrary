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
        RolePlaying,
        WesternStyle,
        OpenWorld,
        Shooter,
        ActionAdventure
    }
}