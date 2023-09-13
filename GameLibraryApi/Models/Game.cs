using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GameLibraryApi.Common;

namespace GameLibraryApi.Models
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public GameMode GameMode {get;set;}
        public GenreEnum Genre {get;set;}
        public PlatformEnum Platform {get; set;}
        public DateTime ReleaseDate {get;set;}
        public string? Developer { get; set; }
        public int Metascore {get;set;}
        public double Userscore {get;set;}
    }
}