using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibraryApi.DTO.Game;

namespace GameLibraryApi.Services.UserInventory
{
    public interface IUserInventory
    {
        public List<GetGameDto> GetUserGames();
        public string BuyGame(int gameId);
        public string RemoveGame(int gameId);
        List<GetGameDto> GetByFilterMyGames(FilterGameDto filters);

    }
}