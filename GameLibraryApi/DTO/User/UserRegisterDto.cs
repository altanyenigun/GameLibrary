using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameLibraryApi.DTO.User
{
    public class UserRegisterDto
    {
        public required string Username {get;set;}
        public required string Password {get;set;}
        [JsonIgnore]
        public string Role { get; set; } = "User";
    }
}