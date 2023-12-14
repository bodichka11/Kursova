namespace OnlineGame.Models
{
    public class GameSession : Entity<long>
    {
        public long ModeId { get; set; }
        public long GameId { get; set; }
        public Game Game { get; set; }
        public Mode Mode { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();

    }
}
