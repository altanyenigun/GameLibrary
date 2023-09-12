using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibraryApi.DTO.Game;
using GameLibraryApi.Models;

namespace GameLibraryApi.Services.GameService
{
    public interface IGameService
    {
        List<GetGameDto> getAll();
        GetGameDto getById(int id);
    }
}