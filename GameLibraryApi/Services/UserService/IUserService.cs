using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibraryApi.DTO.User;
using GameLibraryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameLibraryApi.Services.UserService
{
    public interface IUserService
    {
        public string Register(UserRegisterDto request);
        public string Login(UserLoginDto request);
    }
}