using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Game;
using OnlineGame.Interfaces;

namespace OnlineGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService) 
        { 
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameAsync([FromBody] NewGameDto newGameDto)
        {
            var createdGame = await _gameService.CreateGameAsync(newGameDto);
            return Ok(createdGame);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGamesAsync()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameByIdAsync([FromRoute] long id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            return Ok(game);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGameAsync(GameEditDto gameEditDto)
        {
            if (gameEditDto == null)
            {
                return BadRequest("Not found");
            }
       
            await _gameService.UpdateGameAsync(gameEditDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameAsync([FromRoute] long id)
        {
            await _gameService.DeleteGameAsync(id);
            return NoContent();
        }
    }
}
