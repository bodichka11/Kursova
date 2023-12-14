using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.GameSession;
using OnlineGame.Interfaces;

namespace OnlineGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameSessionController : ControllerBase
    {
        private readonly IGameSessionService _gameSessionService;
        public GameSessionController(IGameSessionService gameSessionService)
        {
            _gameSessionService = gameSessionService;

        }

        [HttpPost]
        public async Task<IActionResult> CreateGameSession(NewGameSessionDto newGameSessionDto)
        {
            var gameSession = await _gameSessionService.CreateGameSessionForGame(newGameSessionDto);
            return Ok(gameSession);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameSessionById([FromRoute] long id)
        {
            var response = await _gameSessionService.GetGameSessionById(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGameSessions()
        {
            var gameSessions = await _gameSessionService.GetAllGameSessions();
            return Ok(gameSessions);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGameSession(GameSessionEditDto gameSessionEditDto)
        {
            if (gameSessionEditDto == null) { return BadRequest(); };

            await _gameSessionService.UpdateGameSession(gameSessionEditDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameSession([FromRoute] long id)
        {
            await _gameSessionService.DeleteGameSession(id);
            return NoContent();
        }

        [HttpPut("AddPlayers/{gameSessionId}")]
        public async Task<IActionResult> AddPlayer([FromBody] AddPlayersDto playersDto, [FromRoute] long gameSessionId)
        {
            var gameSession = await _gameSessionService.AddPlayer(playersDto.PlayerIds, gameSessionId);
            return Ok(gameSession);
        }
    }
}
