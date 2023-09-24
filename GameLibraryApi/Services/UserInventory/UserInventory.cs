using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibraryApi.Data;
using GameLibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryApi.Services.UserInventory
{
    public class UserInventory : IUserInventory
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserInventory(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public IEnumerable<Game> GetUserGames(int userId)
        {
            var userGames = _context.UserGames
            .Include(ug => ug.Game)
            .Where(ug => ug.UserId == userId)
            .Select(ug => ug.Game)
            .ToList();
            
            return userGames!;
        }
    }
}