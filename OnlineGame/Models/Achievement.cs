namespace OnlineGame.Models
{
    public class Achievement : Entity<long>
    {
        public string AchievementName { get; set; }
        public string Description { get; set; }
        public long PlayerId { get; set; }
        public Player Player { get; set; }  
    }
}
