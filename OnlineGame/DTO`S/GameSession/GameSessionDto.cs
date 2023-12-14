using OnlineGame.Models;

namespace OnlineGame.DTO_S
{
    public class GameSessionDto: Entity<long>
    {
        public long ModeId { get; set; }
        public long GameId { get; set; }
        public GameDto Game { get; set; }
        public ModeDto Mode { get; set; }
        public ICollection<PlayerDto> Players { get; set; }
    }
}
