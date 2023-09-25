using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameLibraryApi.DTO.Game;
using GameLibraryApi.Models;
using GameLibraryApi.Services.GameService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameLibraryApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService; //dependency injection
        }

        [HttpGet]
        public ActionResult<List<Game>> getAll()
        {
            return Ok(_gameService.getAll());
        }

        [HttpGet("{id}")]
        public ActionResult<List<Game>> getById(int id)
        {
            return Ok(_gameService.getById(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult addGame(AddGameDto newGame)
        {
            return Ok(_gameService.addGame(newGame));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult updateGame(int id, [FromBody] UpdateGameDto updatedGame)
        {
            return Ok(_gameService.updateGame(id, updatedGame));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult deleteGame(int id)
        {
            return Ok(_gameService.deleteGame(id));
        }

        [HttpGet("List")]
        public ActionResult<List<GetGameDto>> listByOrder([FromQuery] ListGameDto parameters)
        {
            return Ok(_gameService.listByOrder(parameters));
        }

        [HttpPost("Filter")]
        public ActionResult<List<GetGameDto>> getByFilter([FromQuery] FilterGameDto filters)
        {
            return Ok(_gameService.getByFilter(filters));
        }


    }
}