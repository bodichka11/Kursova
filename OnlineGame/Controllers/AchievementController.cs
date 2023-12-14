using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Achievement;
using OnlineGame.Interfaces;
using OnlineGame.Services;

namespace OnlineGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAchievement(NewAchievementDto newAchievementDto)
        {
            var achievement = await _achievementService.CreateAchievement(newAchievementDto);

            return Ok(achievement);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAchievement([FromRoute] long id)
        {
            var response = await _achievementService.GetAchievement(id);
            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAchievementsAsync()
        {
            var achievements = await _achievementService.GetAllAchievements();
            return Ok(achievements);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAchievementAsync([FromBody] AchievementEditDto achievementEditDto)
        {
            if (achievementEditDto == null)
            {
                return BadRequest("Not found");
            }

            await _achievementService.UpdateAchievement(achievementEditDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchievementAsync([FromRoute] long id)
        {
            await _achievementService.DeleteAchievement(id);
            return NoContent();
        }


    }
}
