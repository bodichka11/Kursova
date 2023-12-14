using OnlineGame.Models;

namespace OnlineGame.DTO_S
{
    public class AchievementDto: Entity<long>
    {
        public string AchievementName { get; set; }
        public string Description { get; set; }
        public long PlayerId { get; set; }
        //public PlayerDto Player { get; set; }
    }
}
