using OnlineGame.Models;

namespace OnlineGame.DTO_S
{
    public class GameDto: Entity<long>
    {
        public string GameName { get; set; }
        public ICollection<GameSessionDto> GameSessions { get; set; }
    }
}
