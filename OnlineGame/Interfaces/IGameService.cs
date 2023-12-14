using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Game;

namespace OnlineGame.Interfaces
{
    public interface IGameService
    {
        Task<GameFullDto> CreateGameAsync(NewGameDto newGameDto);
        Task<IEnumerable<GameDto>> GetAllGamesAsync();
        Task<GameFullDto> GetGameByIdAsync(long gameId);
        Task UpdateGameAsync(GameEditDto gameEditDto);
        Task DeleteGameAsync(long gameId);

    }
}
