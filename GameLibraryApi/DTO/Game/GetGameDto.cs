using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibraryApi.Common;

namespace GameLibraryApi.DTO.Game
{
    public class GetGameDto
    {
        public string? Name { get; set; }
        public List<GameMode>? GameMode {get;set;}
        public List<GenreEnum>? Genre {get;set;}
        public List<PlatformEnum>? Platform {get; set;}
        public DateTime ReleaseDate {get;set;}
        public string? Developer { get; set; }
        public int Metascore {get;set;}
        public double Userscore {get;set;}
    }
}