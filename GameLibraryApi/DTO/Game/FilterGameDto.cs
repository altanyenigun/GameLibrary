using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GameLibraryApi.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GameLibraryApi.DTO.Game
{
    public class FilterGameDto
    {
        public string? Name { get; set; }
        public string? Developer { get; set; }
        public List<GameMode>? GameMode {get;set;}
        public List<GenreEnum>? Genre {get;set;}
        public List<PlatformEnum>? Platform {get; set;}
        public DateTime? MinReleaseDate {get;set;}
        public DateTime? MaxReleaseDate {get;set;}
        public int MinMetascore {get;set;}
        public int MaxMetascore {get;set;}
        public double MinUserscore {get;set;}
        public double MaxUserscore {get;set;}

    }
}