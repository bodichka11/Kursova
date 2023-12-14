using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Achievement;

namespace OnlineGame.Interfaces
{
    public interface IAchievementService
    {
        Task<AchievementDto> CreateAchievement(NewAchievementDto newAchievementDto);
        Task<IEnumerable<AchievementDto>> GetAllAchievements();
        Task<AchievementFullDto> GetAchievement(long id);
        Task UpdateAchievement(AchievementEditDto achievementEditDto);
        Task DeleteAchievement(long id);
    }
}
