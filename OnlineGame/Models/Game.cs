namespace OnlineGame.Models
{
    public class Game : Entity<long>
    {
        public string GameName { get; set; }
        public ICollection<GameSession> GameSessions { get; set; }
    }
}
