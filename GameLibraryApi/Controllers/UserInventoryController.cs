using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using GameLibraryApi.DTO.Auth;
using GameLibraryApi.Models;
using GameLibraryApi.Services.AuthService;
using GameLibraryApi.Services.UserInventory;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GameLibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInventoryController : ControllerBase
    {
        private readonly IUserInventory _userInventory;
        public UserInventoryController(IUserInventory userInventory)
        {
            _userInventory = userInventory;
        }

        [HttpGet("{userId}/games")]
        public ActionResult<IEnumerable<Game>> GetUserGames(int userId)
        {
            return Ok(_userInventory.GetUserGames(userId));
        }
    }
}