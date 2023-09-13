using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameLibraryApi.DTO.Game;
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
            try
            {
                return Ok(_gameService.getById(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult addGame(AddGameDto newGame){
            try
            {
                return Ok(_gameService.addGame(newGame));

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateGame(int id,[FromBody] UpdateGameDto updatedGame){
            try
            {
                return Ok(_gameService.updateGame(id,updatedGame));

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}