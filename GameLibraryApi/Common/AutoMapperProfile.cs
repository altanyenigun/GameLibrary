using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameLibraryApi.DTO.Game;
using GameLibraryApi.Models;

namespace GameLibraryApi.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GetGameDto>();
            CreateMap<AddGameDto,Game>();
        }
    }
}