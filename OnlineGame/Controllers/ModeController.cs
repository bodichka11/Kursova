using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Mode;
using OnlineGame.Interfaces;

namespace OnlineGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeController : ControllerBase
    {
        private readonly IModeService _modeService;
        public ModeController(IModeService modeService)
        {
            _modeService = modeService; 
        }

        [HttpPost]
        public async Task<IActionResult> CreateModeAsync([FromBody] NewModeDto modeRequestDto)
        {
            var createdMode = await _modeService.CreateModeAsync(modeRequestDto);
            return Ok(createdMode);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModesAsync()
        {
            var modes = await _modeService.GetAllModesAsync();
            return Ok(modes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModeByIdAsync([FromRoute] long id)
        {
            var mode = await _modeService.GetModeByIdAsync(id);
            return Ok(mode);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateModeAsync(ModeEditDto modeEditDto)
        {
            if (modeEditDto == null)
            {
                return BadRequest("Not found");
            }

            await _modeService.UpdateModeAsync(modeEditDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModeAsync([FromRoute] long id)
        {
            await _modeService.DeleteModeAsync(id);
            return NoContent();
        }
    }
}
