using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibraryApi.DTO.Auth
{
    public class LoginDto
    {
        public required string Username {get;set;}
        public required string Password {get;set;}
    }
}