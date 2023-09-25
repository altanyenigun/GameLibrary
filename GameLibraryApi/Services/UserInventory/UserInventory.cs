using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;


        public UserInventory(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
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

            var userGame = _context.UserGames.FirstOrDefault(ug => ug.UserId == GetUserId() && ug.GameId == gameId);
            if (userGame is not null)
                throw CustomExceptions.ALREADY_OWN_GAME;

            _context.UserGames.Add(new UserGame { UserId = GetUserId(), GameId = gameId });
            _context.SaveChanges();
            return "Successfull";
        }

        public string RemoveGame(int gameId)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == gameId);
            if (game is null)
                throw CustomExceptions.NOT_FOUND;

            var userGame = _context.UserGames.FirstOrDefault(ug => ug.UserId == GetUserId() && ug.GameId == gameId);
            if (userGame is null)
                throw CustomExceptions.DOESNT_HAVE_GAME;

            _context.UserGames.Remove(userGame);
            _context.SaveChanges();
            return "Successfull";
        }

        public List<GetGameDto> GetByFilterMyGames(FilterGameDto filters)
        {
            FilterGameDtoValidator validator = new FilterGameDtoValidator();
            validator.ValidateAndThrow(filters);

            var userGames = _context.UserGames
            .Include(ug => ug.Game)
            .Where(ug => ug.UserId == GetUserId())
            .Where(g =>
                (string.IsNullOrEmpty(filters.Name) || g.Game!.Name!.Contains(filters.Name)) &&
                (string.IsNullOrEmpty(filters.Developer) || g.Game!.Developer!.Contains(filters.Developer)) &&
                (filters.MinMetascore == 0 || g.Game!.Metascore > filters.MinMetascore) &&
                (filters.MaxMetascore == 0 || g.Game!.Metascore <= filters.MaxMetascore) &&
                (filters.MinUserscore == 0 || g.Game!.Userscore > filters.MinUserscore) &&
                (filters.MaxUserscore == 0 || g.Game!.Userscore <= filters.MaxUserscore) &&
                (!filters.MinReleaseDate.HasValue || g.Game!.ReleaseDate > filters.MinReleaseDate) &&
                (!filters.MaxReleaseDate.HasValue || g.Game!.ReleaseDate < filters.MaxReleaseDate) &&
                (filters.Genre == null || filters.Genre.Count == 0 || filters.Genre.Contains(g.Game!.Genre)) &&
                (filters.Platform == null || filters.Platform.Count == 0 || filters.Platform.Contains(g.Game!.Platform)) &&
                (filters.GameMode == null || filters.GameMode.Count == 0 || filters.GameMode.Contains(g.Game!.GameMode))
            )
            .Select(ug => ug.Game)
            .ToList();

            List<GetGameDto> data = _mapper.Map<List<GetGameDto>>(userGames);

            return data;

        }
    }
}