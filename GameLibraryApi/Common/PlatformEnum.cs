using System.ComponentModel;

namespace GameLibraryApi.Common
{
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