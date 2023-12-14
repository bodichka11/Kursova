using OnlineGame.Models;

namespace OnlineGame.DTO_S
{
    public class ModeDto : Entity<long>
    {
        public string ModeName { get; set; }
        public ICollection<GameSessionDto> GameSessions { get; set; }
    }
}
