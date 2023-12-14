using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Player;

namespace OnlineGame.Interfaces
{
    public interface IPlayerService
    {
        Task<PlayerDto> CreatePlayerAsync(NewPlayerDto playerDto);
        Task<IEnumerable<PlayerDto>> GetAllPlayersAsync();
        Task<PlayerFullDto> GetPlayerByIdAsync(long playerId);
        Task UpdatePlayerAsync(PlayerEditDto playerEditDto);
        Task DeletePlayerAsync(long playerId);

    }
}
