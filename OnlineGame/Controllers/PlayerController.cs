using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Player;
using OnlineGame.Interfaces;

namespace OnlineGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayerAsync([FromBody] NewPlayerDto playerDto)
        {
            var createdPlayer = await _playerService.CreatePlayerAsync(playerDto);
            return Ok(createdPlayer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayersAsync()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerByIdAsync([FromRoute] long id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            return Ok(player);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayerAsync(PlayerEditDto playerEditDto)
        {
            if (playerEditDto == null)
            {
                return BadRequest("Not found");
            }

            await _playerService.UpdatePlayerAsync(playerEditDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerAsync([FromRoute] long id)
        {
            await _playerService.DeletePlayerAsync(id);
            return NoContent();
        }
    }
}
