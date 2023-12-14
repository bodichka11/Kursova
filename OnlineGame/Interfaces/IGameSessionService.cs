using OnlineGame.DTO_S;
using OnlineGame.DTO_S.GameSession;

namespace OnlineGame.Interfaces
{
    public interface IGameSessionService
    {
        Task<GameSessionDto> CreateGameSessionForGame(NewGameSessionDto newGameSessionDto);
        Task<IEnumerable<GameSessionDto>> GetAllGameSessions();
        Task<GameSessionFullDto> GetGameSessionById(long id);
        Task UpdateGameSession(GameSessionEditDto gameSessionEditDto);
        Task DeleteGameSession(long id);

        Task<GameSessionDto> AddPlayer(List<long> playerIds, long gameSessionId);
    }
}
