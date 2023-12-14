using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineGame.Data;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Player;
using OnlineGame.Interfaces;
using OnlineGame.Models;

namespace OnlineGame.Services
{
    public class PlayerService: IPlayerService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PlayerService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlayerDto> CreatePlayerAsync(NewPlayerDto playerDto)
        {
            var player = _mapper.Map<Player>(playerDto);
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<IEnumerable<PlayerDto>> GetAllPlayersAsync()
        {
            var players = await _context.Players.Include(p => p.GameSessions).Include(p => p.Achievements).ToListAsync();
            return _mapper.Map<IEnumerable<PlayerDto>>(players);
        }

        public async Task<PlayerFullDto> GetPlayerByIdAsync(long playerId)
        {
            var player = await _context.Players.Where(x => x.Id == playerId)
                .Include(x => x.GameSessions)
                .Include(x => x.Achievements)
                .FirstOrDefaultAsync();
            return _mapper.Map<PlayerFullDto>(player);
        }

        public async Task UpdatePlayerAsync(PlayerEditDto playerEditDto)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == playerEditDto.Id);
            if (player != null)
            {
                _mapper.Map(playerEditDto, player);
                await _context.SaveChangesAsync();

            }
        }

        public async Task DeletePlayerAsync(long playerId)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == playerId);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }
    }
}
