using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameLibraryApi.DTO.Auth
{
    public class RegisterDto
    {
        public required string Username {get;set;}
        public required string Password {get;set;}
        [JsonIgnore]
        public string Role { get; set; } = "User";
    }
}