using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using GameLibraryApi.Common;
using GameLibraryApi.Data;
using GameLibraryApi.DTO.Game;
using GameLibraryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GameLibraryApi.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public GameService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetGameDto> getAll()
        {
            var games = _context.Games.ToList();
            List<GetGameDto> data = _mapper.Map<List<GetGameDto>>(games);
            return data;
        }

        public GetGameDto getById(int id)
        {
            var game = _context.Games.Where(p => p.Id == id).SingleOrDefault();
            if (game is null)
            {
                throw new Exception("There is no record with this id.");
            }
            GetGameDto data = _mapper.Map<GetGameDto>(game);
            return data;
        }

        public string addGame(AddGameDto newGame)
        {

            AddGameDtoValidator validator = new AddGameDtoValidator();
            validator.ValidateAndThrow(newGame);
            var game = _mapper.Map<Game>(newGame);
            _context.Games.Add(game);
            _context.SaveChanges();
            return "Successfull";

        }

        public string updateGame(int id, UpdateGameDto updatedGame)
        {

            var game = _context.Games.FirstOrDefault(g => g.Id == id);
            if (game is null)
                throw new Exception("There is no record with this id.");

            UpdateGameDtoValidator validator = new UpdateGameDtoValidator();
            validator.ValidateAndThrow(updatedGame);

            _mapper.Map(updatedGame, game);
            _context.SaveChanges();
            return "Successfull";

        }

        public string deleteGame(int id)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == id);
            if (game is null)
                throw new Exception("There is no record with this id.");
            _context.Games.Remove(game);
            _context.SaveChanges();
            return "Successfull";


        }

        public List<GetGameDto> listByOrder(ListGameDto parameters)
        {
            ListGameDtoValidator validator = new ListGameDtoValidator();
            validator.ValidateAndThrow(parameters);

            //Thanks to the 'System.Linq.Dynamic.Core' package, we can write a query just like writing 'ORDER BY X asc' in a normal SQL query.
            var games = _context.Games.OrderBy($"{parameters.Field} {parameters.OrderBy}");
            List<GetGameDto> gameList = _mapper.Map<List<GetGameDto>>(games);
            return gameList;

        }

        public List<GetGameDto> getByFilter(FilterGameDto filters)
        {
            FilterGameDtoValidator validator = new FilterGameDtoValidator();
            validator.ValidateAndThrow(filters);

            //combined linq query
            //You can see there are a lot of '== 0' or '== null' checks here. 
            //The reason for this is that if these fields are not entered at all, only the filters entered will be active without breaking the filter.
            //For example, if only minUsercore is entered, it will return data according to this filter; if maxMetascore is entered on top of this, it will return data that meets these 2 conditions. 
            //This situation continues by adding in this way.

            var filteredGames = _context.Games.Where(g =>
                (string.IsNullOrEmpty(filters.Name) || g.Name!.Contains(filters.Name)) &&
                (string.IsNullOrEmpty(filters.Developer) || g.Developer!.Contains(filters.Developer)) &&
                (filters.MinMetascore == 0 || g.Metascore > filters.MinMetascore) &&
                (filters.MaxMetascore == 0 || g.Metascore <= filters.MaxMetascore) &&
                (filters.MinUserscore == 0 || g.Userscore > filters.MinUserscore) &&
                (filters.MaxUserscore == 0 || g.Userscore <= filters.MaxUserscore) &&
                (!filters.MinReleaseDate.HasValue || g.ReleaseDate > filters.MinReleaseDate) &&
                (!filters.MaxReleaseDate.HasValue || g.ReleaseDate < filters.MaxReleaseDate) &&
                (filters.Genre == null || filters.Genre.Count == 0 || filters.Genre.Contains(g.Genre)) &&
                (filters.Platform == null || filters.Platform.Count == 0 || filters.Platform.Contains(g.Platform)) &&
                (filters.GameMode == null || filters.GameMode.Count == 0 || filters.GameMode.Contains(g.GameMode))
            );

            List<GetGameDto> data = _mapper.Map<List<GetGameDto>>(filteredGames);
            return data;
        }
    }
}