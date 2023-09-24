using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibraryApi.DTO.User;
using GameLibraryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameLibraryApi.Services.AuthService
{
    public interface IAuthService
    {
        public string Register(UserRegisterDto request);
        public string Login(UserLoginDto request);
        public IEnumerable<Game> GetUserGames(int userId);
    }
}