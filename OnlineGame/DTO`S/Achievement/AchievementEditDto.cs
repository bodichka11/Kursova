using OnlineGame.Models;

namespace OnlineGame.DTO_S.Achievement
{
    public class AchievementEditDto: Entity<long>
    {
        public string AchievementName { get; set; }
        public string Description { get; set; }
        public long PlayerId { get; set; }
    }
}
