using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GameLibraryApi.Common.Exceptions;
using GameLibraryApi.Data;
using GameLibraryApi.DTO.Game;
using GameLibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryApi.Services.UserInventory
{
    public class UserInventory : IUserInventory
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;


        public UserInventory(IConfiguration configuration, DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        public List<GetGameDto> GetUserGames()
        {
            var userGames = _context.UserGames
            .Include(ug => ug.Game)
            .Where(ug => ug.UserId == GetUserId())
            .Select(ug => ug.Game)
            .ToList();

            List<GetGameDto> data = _mapper.Map<List<GetGameDto>>(userGames);

            return data;
        }

        public string BuyGame(int gameId)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == gameId);
            if (game is null)
                throw CustomExceptions.NOT_FOUND;

            var userGames = _context.UserGames.FirstOrDefault(ug => ug.UserId == GetUserId() && ug.GameId == gameId);
            if (userGames is not null)
                throw CustomExceptions.ALREADY_OWN_GAME;

            _context.UserGames.Add(new UserGame { UserId = GetUserId(), GameId = gameId });
            _context.SaveChanges();
            return "Successfull";
        }
    }
}