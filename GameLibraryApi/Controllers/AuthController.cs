using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using GameLibraryApi.DTO.User;
using GameLibraryApi.Models;
using GameLibraryApi.Services.AuthService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GameLibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserRegisterDto request)
        {
            return Ok(_authService.Register(request));
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserLoginDto request)
        {
            return Ok(_authService.Login(request));
        }

        [HttpGet("{userId}/games")]
        public ActionResult<IEnumerable<Game>> GetUserGames(int userId)
        {
            return Ok(_authService.GetUserGames(userId));
        }
    }
}