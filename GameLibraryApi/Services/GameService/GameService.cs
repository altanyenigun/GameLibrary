using System;
using System.Collections.Generic;
using System.Linq;
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


        public GameService(DataContext context,IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public List<GetGameDto> getAll()
        {
            var games = _context.Games.ToList();
            List<GetGameDto> data = _mapper.Map<List<GetGameDto>>(games);
            return data;
        }

        public GetGameDto getById(int id)
        {
            var game = _context.Games.Where(p=>p.Id == id).SingleOrDefault();
            if(game is null){
                throw new Exception("Böyle bir id'ye sahip kayıt yok");
            }
            GetGameDto data = _mapper.Map<GetGameDto>(game);
            return data;
        }

        public string addGame(AddGameDto newGame)
        {            
            try
            {
                AddGameDtoValidator validator = new AddGameDtoValidator();
                validator.ValidateAndThrow(newGame);
                var game = _mapper.Map<Game>(newGame);
                _context.Games.Add(game);
                _context.SaveChanges();
                return "Successfull";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string updateGame(int id, UpdateGameDto updatedGame)
        {
            try
            {
                var game = _context.Games.FirstOrDefault(g=>g.Id == id);
                if(game is null)
                    throw new Exception("Böyle idye sahip bir kayıt yok");
                    
                UpdateGameDtoValidator validator = new UpdateGameDtoValidator();
                validator.ValidateAndThrow(updatedGame);
                
                _mapper.Map(updatedGame,game);
                _context.SaveChanges();
                return "Successfull";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}