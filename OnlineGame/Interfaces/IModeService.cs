using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Mode;

namespace OnlineGame.Interfaces
{
    public interface IModeService
    {
        Task<ModeDto> CreateModeAsync(NewModeDto modeRequestDto);
        Task<IEnumerable<ModeDto>> GetAllModesAsync();
        Task<ModeFullDto> GetModeByIdAsync(long modeId);
        Task UpdateModeAsync(ModeEditDto modeEditDto);
        Task DeleteModeAsync(long modeId);
    }
}
