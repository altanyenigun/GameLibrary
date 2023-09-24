using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibraryApi.Models;

namespace GameLibraryApi.Services.UserInventory
{
    public interface IUserInventory
    {
        public IEnumerable<Game> GetUserGames(int userId);
    }
}