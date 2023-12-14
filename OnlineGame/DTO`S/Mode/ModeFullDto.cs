using OnlineGame.Models;

namespace OnlineGame.DTO_S.Mode
{
    public class ModeFullDto
    {
        public string ModeName { get; set; }
        public ICollection<GameSessionDto> GameSessions { get; set; }
    }

}

