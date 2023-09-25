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

        [HttpPost("/register")]
        public ActionResult<User> Register(RegisterDto request)
        {
            return Ok(_authService.Register(request));
        }

        [HttpPost("/login")]
        public ActionResult<User> Login(LoginDto request)
        {
            return Ok(_authService.Login(request));
        }
    }
}