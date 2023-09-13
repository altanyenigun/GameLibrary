using System.Text.Json.Serialization;

namespace GameLibraryApi.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GameMode
    {
        Singleplayer=1,
        Multiplayer
    }
}