using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineGame.Data;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Game;
using OnlineGame.Interfaces;
using OnlineGame.Models;

namespace OnlineGame.Services
{
    public class GameService: IGameService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GameService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GameFullDto> CreateGameAsync(NewGameDto newGameDto)
        {
            var game = _mapper.Map<Game>(newGameDto);
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return _mapper.Map<GameFullDto>(game);
        }

        public async Task<IEnumerable<GameDto>> GetAllGamesAsync()
        {
            var games = await _context.Games.ToListAsync();
            return _mapper.Map<IEnumerable<GameDto>>(games);
        }

        public async Task<GameFullDto> GetGameByIdAsync(long gameId)
        {
            var game = await _context.Games.Where(x => x.Id == gameId)
                .Include(x => x.GameSessions)
                .FirstOrDefaultAsync();
            return _mapper.Map<GameFullDto>(game);
        }

        public async Task UpdateGameAsync(GameEditDto gameEditDto)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == gameEditDto.Id);
            if(game != null)
            {
                _mapper.Map(gameEditDto, game);
                await _context.SaveChangesAsync();

            }
        }

        public async Task DeleteGameAsync(long gameId)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            if(game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

    }
}
