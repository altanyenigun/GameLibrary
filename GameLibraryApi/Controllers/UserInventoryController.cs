using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using GameLibraryApi.DTO.Auth;
using GameLibraryApi.DTO.Game;
using GameLibraryApi.Models;
using GameLibraryApi.Services.AuthService;
using GameLibraryApi.Services.UserInventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GameLibraryApi.Controllers
{
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class UserInventoryController : ControllerBase
    {
        private readonly IUserInventory _userInventory;
        public UserInventoryController(IUserInventory userInventory)
        {
            _userInventory = userInventory;
        }

        [HttpGet("/api/MyGames")]
        public ActionResult<IEnumerable<Game>> GetUserGames()
        {
            return Ok(_userInventory.GetUserGames());
        }

        [HttpPost("/api/BuyGame")]
        public ActionResult<IEnumerable<Game>> BuyGame(int gameId)
        {
            return Ok(_userInventory.BuyGame(gameId));
        }

        [HttpPost("/api/RemoveGame")]
        public ActionResult<IEnumerable<Game>> RemoveGame(int gameId)
        {
            return Ok(_userInventory.RemoveGame(gameId));
        }

        [HttpPost("/api/ByFilterMyGames")]
        public ActionResult<List<GetGameDto>> GetByFilterMyGames([FromQuery] FilterGameDto filters)
        {
            return Ok(_userInventory.GetByFilterMyGames(filters));
        }

    }
}