namespace OnlineGame.Models
{
    public class Mode : Entity<long>
    {
        public string ModeName { get; set; }
        public ICollection<GameSession> GameSessions { get; set; }
    }
}
