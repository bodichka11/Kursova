using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineGame.Data;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Mode;
using OnlineGame.Interfaces;
using OnlineGame.Models;

namespace OnlineGame.Services
{
    public class ModeService: IModeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ModeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ModeDto> CreateModeAsync(NewModeDto modeRequestDto)
        {
            var mode = _mapper.Map<Mode>(modeRequestDto);
            _context.Modes.Add(mode);
            await _context.SaveChangesAsync();

            return _mapper.Map<ModeDto>(mode);
        }

        public async Task<IEnumerable<ModeDto>> GetAllModesAsync()
        {
            var modes = await _context.Modes.ToListAsync();
            return _mapper.Map<IEnumerable<ModeDto>>(modes);
        }

        public async Task<ModeFullDto> GetModeByIdAsync(long modeId)
        {
            var mode = await _context.Modes.Where(x => x.Id == modeId)
                .Include(x => x.GameSessions)
                .FirstOrDefaultAsync();
            return _mapper.Map<ModeFullDto>(mode);
        }

        public async Task UpdateModeAsync(ModeEditDto modeEditDto)
        {
            var mode = await _context.Modes.FirstOrDefaultAsync(x => x.Id == modeEditDto.Id);
            if (mode != null)
            {
                _mapper.Map(modeEditDto, mode);
                await _context.SaveChangesAsync();

            }
        }

        public async Task DeleteModeAsync(long modeId)
        {
            var mode = await _context.Modes.FirstOrDefaultAsync(x => x.Id == modeId);
            if (mode != null)
            {
                _context.Modes.Remove(mode);
                await _context.SaveChangesAsync();
            }
        }

    }
}
