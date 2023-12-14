using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineGame.Data;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Achievement;
using OnlineGame.Interfaces;
using OnlineGame.Models;
using System;

namespace OnlineGame.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AchievementService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AchievementDto> CreateAchievement(NewAchievementDto newAchievementDto)
        {
            var achievement = _mapper.Map<Achievement>(newAchievementDto);
            _context.Achievements.Add(achievement);
            await _context.SaveChangesAsync();

            return _mapper.Map<AchievementDto>(achievement);
        }

        public async Task<AchievementFullDto> GetAchievement(long id)
        {
            var achievement = await _context.Achievements.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<AchievementFullDto>(achievement);
        }

        public async Task<IEnumerable<AchievementDto>> GetAllAchievements()
        {
            var achievements = await _context.Achievements.ToListAsync();
            return _mapper.Map<IEnumerable<AchievementDto>>(achievements);
        }

        public async Task UpdateAchievement(AchievementEditDto achievementEditDto)
        {
            var achievement = await _context.Achievements.FirstOrDefaultAsync(x => x.Id == achievementEditDto.Id);
            if (achievement != null)
            {
                _mapper.Map(achievementEditDto, achievement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAchievement(long id)
        {
            var achievement = await _context.Achievements.FirstOrDefaultAsync(x => x.Id == id);
            if (achievement == null)
            {
                return;
            }
            _context.Achievements.Remove(achievement);
            await _context.SaveChangesAsync();

        }
    }
}
