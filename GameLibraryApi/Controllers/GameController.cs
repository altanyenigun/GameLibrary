using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameLibraryApi.Models;
using GameLibraryApi.Services.GameService;
using Microsoft.AspNetCore.Mvc;

namespace GameLibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService=gameService;
        }

        [HttpGet]
        public ActionResult<List<Game>> getAll(){
            return Ok(_gameService.getAll());
        }

        [HttpGet("{id}")]
        public ActionResult<List<Game>> getById(int id){
            return Ok(_gameService.getById(id));
        }


    }
}