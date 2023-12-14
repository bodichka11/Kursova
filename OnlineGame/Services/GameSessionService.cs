using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineGame.Data;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.GameSession;
using OnlineGame.Interfaces;
using OnlineGame.Models;

namespace OnlineGame.Services
{
    public class GameSessionService : IGameSessionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GameSessionService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GameSessionDto> CreateGameSessionForGame(NewGameSessionDto newGameSessionDto)
        {
            var gameSession = _mapper.Map<GameSession>(newGameSessionDto);
            _context.GameSessions.Add(gameSession);
            await _context.SaveChangesAsync();
            return _mapper.Map<GameSessionDto>(gameSession);
        }

        public async Task<IEnumerable<GameSessionDto>> GetAllGameSessions()
        {
            var gameSessions = await _context.GameSessions.Include(x => x.Game).Include(x => x.Mode).Include(x => x.Players).ToListAsync();
            return _mapper.Map<IEnumerable<GameSessionDto>>(gameSessions);
        }

        public async Task<GameSessionFullDto> GetGameSessionById(long id)
        {
            var gameSession = await _context.GameSessions.Where(g => g.Id == id)
                .Include(g => g.Players)
                .FirstOrDefaultAsync();

            return _mapper.Map<GameSessionFullDto>(gameSession);
        }

        public async Task UpdateGameSession(GameSessionEditDto gameSessionEditDto)
        {
            var gameSession = await _context.GameSessions.FirstOrDefaultAsync(x => x.Id == gameSessionEditDto.Id);
            if (gameSession != null)
            {
                _mapper.Map(gameSessionEditDto, gameSession);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteGameSession(long id)
        {
            var gameSession = await _context.GameSessions.FirstOrDefaultAsync(x => x.Id == id);
            if (gameSession == null)
            {
                return;
            }
            _context.GameSessions.Remove(gameSession);
            await _context.SaveChangesAsync();

        }

        public async Task<GameSessionDto> AddPlayer(List<long> playerIds, long gameSessionId)
        {
            var gameSession = await _context.GameSessions.Include(x => x.Players).FirstOrDefaultAsync(x => x.Id == gameSessionId);
            var players  = await _context.Players.Where(x => playerIds.Contains(x.Id)).ToListAsync();
            gameSession.Players = gameSession.Players.Concat(players).ToList();
            await _context.SaveChangesAsync();
            return _mapper.Map<GameSessionDto>(gameSession);
        }
    }
}
