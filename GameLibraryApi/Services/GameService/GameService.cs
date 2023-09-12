using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameLibraryApi.Data;
using GameLibraryApi.DTO.Game;
using GameLibraryApi.Models;

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
    }
}