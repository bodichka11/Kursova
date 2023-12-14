namespace OnlineGame.Models
{
    public class Player : Entity<long>
    {
        public string Nickname { get; set; }
        public int Rating { get; set; }
        public int Level { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<GameSession> GameSessions { get; set; }

    }
}
