namespace OnlineGame.DTO_S.Achievement
{
    public class AchievementFullDto
    {
        public string AchievementName { get; set; }
        public string Description { get; set; }
        public long PlayerId { get; set; }
        public PlayerDto Player { get; set; }
    }
}
