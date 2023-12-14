using OnlineGame.Models;

namespace OnlineGame.DTO_S.Game
{
    public class GameFullDto
    {
        public string GameName { get; set; }
        public ICollection<GameSessionDto>? GameSessions { get; set; }
    }
}
