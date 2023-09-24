using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibraryApi.Models
{
    public class UserGame
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int GameId { get; set; }
        public Game? Game { get; set; }
    }
}