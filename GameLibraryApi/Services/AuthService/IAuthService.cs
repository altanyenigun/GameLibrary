using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibraryApi.DTO.Auth;
using GameLibraryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameLibraryApi.Services.AuthService
{
    public interface IAuthService
    {
        public string Register(RegisterDto request);
        public string Login(LoginDto request);
    }
}