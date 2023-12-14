using OnlineGame.Models;

namespace OnlineGame.DTO_S.GameSession
{
    public class GameSessionEditDto : Entity<long>
    {
        public long ModeId { get; set; }
        public long GameId { get; set; }
        //public long PlayerId { get; set; }
    }
}
